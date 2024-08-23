using System.Diagnostics;

namespace RenameApp;

static class Rename
{
    public static List<string> GetFiles()
    {
        List<string> result = new();

        Process process = new();
        process.StartInfo.FileName = "ls";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;

        process.Start();

        while (!process.StandardOutput.EndOfStream)
        {
            string line = process.StandardOutput.ReadLine() ?? string.Empty;
            result.Add(line);
        }

        process.WaitForExit();

        return result;
    }

    public static string RenameFile(List<string> files, int fileIndex, string newName)
    {

        string oldFile = files[fileIndex];
        Process process = new();
        process.StartInfo.FileName = "mv";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.Arguments = $"{oldFile} {newName}";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.Start();

        string error = process.StandardError.ReadToEnd();

        process.WaitForExit();

        if (!string.IsNullOrEmpty(error))
        {
            return error;
        }

        return "sucess";
    }
}