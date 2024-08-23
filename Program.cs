using RenameApp;


Console.Clear();

List<string> files = Rename.GetFiles();

foreach (string file in files)
{
    Console.WriteLine(files.IndexOf(file) + " " + file);
}


Console.Write("\nEnter the number of the file you want to rename: ");

int choice = Int32.Parse(Console.ReadLine() ?? "-1");

Console.Write("\nEnter the new file name: ");

string newName = Console.ReadLine() ?? "";

string? result = Rename.RenameFile(files, choice, newName);

Console.WriteLine(result);