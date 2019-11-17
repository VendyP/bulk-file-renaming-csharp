using System;
using System.Collections.Generic;
using System.IO;

namespace BulkFileConsoleApp
{
    public static class FileWriter
    {
        public static void Write(string outputPath, List<FileModel> files)
        {
            if (string.IsNullOrWhiteSpace(outputPath))
            {
                throw new ArgumentException("outputPath can not be null or empty", nameof(outputPath));
            }

            if (files is null)
            {
                throw new ArgumentNullException(nameof(files));
            }

            if (files.Count < 1)
            {
                throw new ArgumentException(message: "files at least contains 1");
            }

            // create directory if not exists
            if (!Directory.Exists(path: outputPath))
            {
                Directory.CreateDirectory(path: outputPath);
            }

            foreach (var file in files)
            {
                using (FileStream fileStream = new FileStream(Path.Combine(outputPath, file.NewFilename), FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(file.Data, 0, (int)file.ContentLength);
                }
            }
        }
    }
}