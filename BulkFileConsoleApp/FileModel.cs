namespace BulkFileConsoleApp
{
    public class FileModel
    {
        public FileModel()
        {
            NewFilenameWithoutExtension = null;
        }

        public string Filename { get; set; }
        public string FilenameWithoutExtension { get; set; }
        public string Extension { get; set; }
        public byte[] Data { get; set; }
        public long? ContentLength { get; set; }
        public string NewFilenameWithoutExtension { get; set; }
        public string NewFilename { get => string.Concat(string.IsNullOrEmpty(NewFilenameWithoutExtension) ? Filename : NewFilenameWithoutExtension, Extension); }
    }
}