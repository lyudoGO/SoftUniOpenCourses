namespace _02.TraverseSaveDirectoryContentsTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            string rootFolderName = @"C:\xampp";
            var rootFolder = new Folder(rootFolderName);
            TraverseDirectoryFromGivenRoot(rootFolder);
            long sum = CalculateSubtreeFilesizeSum(rootFolder);

            PrintDirectoryTree(rootFolder, string.Empty);
            Console.WriteLine("File sizes sum in {0} is {1} bytes", rootFolder.Name, sum);

            var subFolder = new Folder(@"C:\xampp\apache");
            TraverseDirectoryFromGivenRoot(subFolder);
            long subSum = CalculateSubtreeFilesizeSum(subFolder);
            Console.WriteLine("File sizes sum in {0} is {1} bytes", subFolder.Name, subSum);

        }

        private static long CalculateSubtreeFilesizeSum(Folder rootFolder)
        {
            long childrenSum = 0;
            long rootSum = rootFolder.Files.Sum(f => f.Size);
            foreach (var folder in rootFolder.ChildFolders)
            {
                childrenSum += CalculateSubtreeFilesizeSum(folder);
            }

            return childrenSum + rootSum;
        }

        private static void TraverseDirectoryFromGivenRoot(Folder rootFolder)
        {
            
            var directories = new DirectoryInfo(rootFolder.Name).GetDirectories();
            var files = new DirectoryInfo(rootFolder.Name).GetFiles();

            foreach (var file in files)
            {
                var currentFile = new File(file.Name, file.Length);
                rootFolder.Files.Add(currentFile);
            }

            foreach (var directory in directories)
            {
                var currentFolder = new Folder(directory.FullName);
                rootFolder.ChildFolders.Add(currentFolder);
                TraverseDirectoryFromGivenRoot(currentFolder);
            }
        }

        private static void PrintDirectoryTree(Folder rootFolder, string spaces)
        {
            Console.WriteLine(spaces + rootFolder.Name);
            foreach (var folder in rootFolder.ChildFolders)
            {
                PrintDirectoryTree(folder, spaces + "  ");
            }
        }
    }
}
