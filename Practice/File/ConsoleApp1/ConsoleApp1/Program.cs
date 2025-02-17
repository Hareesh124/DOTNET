using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace FolderFileChecker
{
    class Program
    {
        static Dictionary<string, FileSystemWatcher> folderWatchers = new Dictionary<string, FileSystemWatcher>();

        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            List<string> folderPaths = config.GetSection("FolderPaths").Get<List<string>>();

            if (folderPaths == null || folderPaths.Count == 0)
            {
                Console.WriteLine("No folder paths found in configuration.");
                return;
            }

            foreach (var folder in folderPaths)
            {
                if (Directory.Exists(folder))
                {
                    FileSystemWatcher watcher = new FileSystemWatcher(folder)
                    {
                        Filter = "*.*",
                        EnableRaisingEvents = true
                    };

                    watcher.Created += OnFileCreated;
                    watcher.Changed += OnFileChanged;
                    watcher.Deleted += OnFileDeleted;
                    watcher.Renamed += OnFileRenamed;

                    folderWatchers[folder] = watcher;

                    Console.WriteLine($"Started monitoring: {folder}");
                    Console.WriteLine($"Checking folder: {folder}");
                    Console.WriteLine("----------------------------------");

                    string[] files = Directory.GetFiles(folder);

                    if (files.Length > 0)
                    {
                        Console.WriteLine($"Files found in {folder}:");
                        Console.WriteLine("----------------------------------");
                        foreach (var file in files)
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            Console.WriteLine($"File: {fileInfo.Name}, Size: {fileInfo.Length} bytes, Last Modified: {fileInfo.LastWriteTime}");
                        }
                        Console.WriteLine("=======================================");
                    }
                    else
                    {
                        Console.WriteLine($"No files found in {folder}");
                    }
                }
                else
                {
                    Console.WriteLine($"Directory not found: {folder}");
                }
            }

            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }

        private static void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File created: {e.FullPath} at {DateTime.Now}");
        }

        private static void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File modified: {e.FullPath} at {DateTime.Now}");
        }

        private static void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File deleted: {e.FullPath} at {DateTime.Now}");
        }

        private static void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"File renamed: {e.OldFullPath} to {e.FullPath} at {DateTime.Now}");
        }
    }
}
