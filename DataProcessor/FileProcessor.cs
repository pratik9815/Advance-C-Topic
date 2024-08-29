using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor;

public class FileProcessor
{
    private const string BackupDirectoryName = "backup";
    public string? InputFilePath { get; }
    public FileProcessor(string? inputFilePath)
    {
        InputFilePath = inputFilePath;
    }
    public void Process() 
    {
        Console.WriteLine($"Begin the process of {InputFilePath}");

        //check if the file exists
        if(!File.Exists(InputFilePath))
        {
            Console.WriteLine($"Error: file {InputFilePath} doesnot exists.");
            return;
        }
        //getting the root directory path
        string? rootDirectoryPath = new DirectoryInfo(InputFilePath).Parent?.FullName;

        if(!Directory.Exists(rootDirectoryPath))
        {

        }
    }
}
