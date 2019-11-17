using System;
using System.Collections.Generic;
using System.IO;

namespace BulkFileConsoleApp
{
    public static class FileReader
    {
        public static List<FileModel> GetFiles(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Directory can not be null", nameof(path));
            }

            // check if directory exists
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException(message: $"Directory path \"{path}\" not found");
            }

            List<FileModel> files = new List<FileModel>();

            // get all files in path
            string[] filePaths = Directory.GetFiles(path);
            if (filePaths.Length == 0)
            {
                throw new FileNotFoundException(message: $"No file found under this path \"{path}\"");
            }

            foreach (string filePath in filePaths)
            {
                FileModel fileModel = new FileModel();

                using (FileStream file = new FileStream(filePath, FileMode.Open))
                {
                    fileModel.Data = new byte[file.Length];
                    file.Read(fileModel.Data, 0, (int)file.Length);
                }

                fileModel.ContentLength = fileModel.Data.Length;
                fileModel.Filename = Path.GetFileName(filePath);
                fileModel.Extension = Path.GetExtension(filePath);
                fileModel.FilenameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

                files.Add(item: fileModel);
            }

            return files;
        }
    }
}