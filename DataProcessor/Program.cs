
using DataProcessor;
//using static System.Console;


//WriteLine("Parsing command line options ");

//var directoryToWatch = args[0];

//if(!Directory.Exists(directoryToWatch))
//{
//    WriteLine($"Error : The directory {directoryToWatch} does not exists.");
//    WriteLine("Press enter to quit.");
//    ReadLine();
//    return;
//}
//WriteLine($"Watching directory {directoryToWatch} for changes");

//using var inputFileWatcher = new FileSystemWatcher(directoryToWatch);

//inputFileWatcher.IncludeSubdirectories = false;
//inputFileWatcher.InternalBufferSize = 32_768; // 32kb
//inputFileWatcher.Filter = "*.*"; //this is deafult beahaviour
//inputFileWatcher.NotifyFilter = NotifyFilters.FileName;

//inputFileWatcher.Created += FileCreated;
//inputFileWatcher.Changed += FileChanged;
//inputFileWatcher.Deleted += FileDeleted;
//inputFileWatcher.Renamed += FileRenamed;
//inputFileWatcher.Error += WatcherError;

//inputFileWatcher.EnableRaisingEvents = true;

//WriteLine("Press enter to quit.");
//ReadLine();


//static void FileCreated(object sender, FileSystemEventArgs e)
//{
//    WriteLine($"* File Created : {e.Name} - type: {e.ChangeType}");
//}
//static void FileChanged(object sender, FileSystemEventArgs e)
//{
//    WriteLine($"* File changed : {e.Name} - type: {e.ChangeType}");
//}
//static void FileDeleted(object sender, FileSystemEventArgs e)
//{
//    WriteLine($"* File deleted : {e.Name} - type: {e.ChangeType}");
//}

//static void FileRenamed(object sender, RenamedEventArgs e)
//{
//    WriteLine($"* File renamed : {e.OldName} to {e.Name} - type: {e.ChangeType}");
//}
//static void WatcherError(object sender, ErrorEventArgs e)
//{
//    WriteLine($"*Error : file system watching may no longer be active: {e.GetException()}");
//}

//static void ProcessSingleFile(string filePath)
//{
//    var fileProcessor = new FileProcessor(filePath);
//    fileProcessor.Process();
//}




////string filePath = @"C:\Photos\bard.jpg";

////byte[] data = File.ReadAllBytes(filePath);
////utf 8 string
////string textData = Encoding.UTF8.GetString(data);

////hexadecimal string
////string textData = BitConverter.ToString(data).Replace("\r\n", "\n");

////Console.WriteLine(textData);


////print as byte value directly 
////foreach  (byte b in data)
////{
////    Console.WriteLine(b);
////}


////ByteArrayContent byteArrayContent = new ByteArrayContent(data);


////byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");


DocumentGenerator.CreatePdfMemStream();
