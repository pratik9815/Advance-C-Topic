using static System.Console;
namespace DataProcessor;

public class FileProcessor
{
    private const string BackupDirectoryName = "backup";
    private const string InProgressDirectoryName = "processing";
    private const string CompletedDirectoryName = "complete";
    public string InputFilePath { get; }
    public FileProcessor(string inputFilePath)
    {
        InputFilePath = inputFilePath;
    }
    public void Process() 
    {
        WriteLine($"Begin the process of {InputFilePath}");

        //check if the file exists
        if(!File.Exists(InputFilePath))
        {
            WriteLine($"Error: file {InputFilePath} doesnot exists.");
            return;
        }
        //getting the root directory path
        string? rootDirectoryPath = new DirectoryInfo(InputFilePath).Parent?.FullName;

        if (rootDirectoryPath == null)
        {
            throw new InvalidOperationException($"Cannot determine the root directory of the path");
        }
        WriteLine($"Root data path is {rootDirectoryPath}");
        //we can find the root of root data path like this
        string? rootPath = new DirectoryInfo(InputFilePath).Parent?.Parent?.FullName;
        if (rootPath == null)
        {
            throw new InvalidOperationException($"Cannot determine the root directory of the path");
        }
        WriteLine($"Root data path of root path is {rootPath}");

        //check if the backup directory exists
        string backupDirectoryPath = Path.Combine(rootPath, BackupDirectoryName);

        if( !Directory.Exists(backupDirectoryPath) )
        {
            WriteLine($"Creating {backupDirectoryPath}");
            Directory.CreateDirectory(backupDirectoryPath);
        }

        //copy file into the back up dir
        string inputFileName = Path.GetFileName(InputFilePath);
        string backupFilePath = Path.Combine(backupDirectoryPath, inputFileName);
        WriteLine($"Copying {inputFileName} to {backupFilePath}");
        File.Copy(InputFilePath, backupFilePath,true);

        //Move to in progress dir
        //creating a new directory
        Directory.CreateDirectory(Path.Combine(rootPath, InProgressDirectoryName)); // this will not throw exception if the file already exists
        string inProgressFilePath = Path.Combine(rootPath, InProgressDirectoryName,inputFileName);
        if (File.Exists(inProgressFilePath))
        {
            WriteLine($"Error : a file with the name {inProgressFilePath} is already processed.");
            return;
        }
        WriteLine($"Moving {InputFilePath} to {inProgressFilePath}");
        File.Move(InputFilePath, inProgressFilePath);

        string extension = Path.GetExtension(InputFilePath);
        switch(extension)
        {
            case ".txt":
                ProcessTextFile(inProgressFilePath);
                break;
            default:
                WriteLine($"{extension} is an unsupported file type.");
                break;
        }
        //Move the file after processing is complete
        string completeDirectoryPath = Path.Combine(rootPath, CompletedDirectoryName);

        Directory.CreateDirectory(completeDirectoryPath);
        string fileNameWithCompleteExtension = Path.ChangeExtension(inputFileName, ".complete");
        string completedFileName = $"{Guid.NewGuid()}{fileNameWithCompleteExtension}";  
        string completeFilePath = Path.Combine(completeDirectoryPath,completedFileName);
        WriteLine($"Moving {inProgressFilePath} to {completeFilePath}");
        File.Move(inProgressFilePath,completeFilePath);

        string? inprogressDirectoryPath = Path.Combine(rootPath, InProgressDirectoryName);
        WriteLine($"Deleting {inprogressDirectoryPath}");
        Directory.Delete(inprogressDirectoryPath!,true);

    }

    private void ProcessTextFile(string inProgressFilePath)
    {
        WriteLine($"Processing text file {inProgressFilePath}");
        //Read in and process
    }
}
