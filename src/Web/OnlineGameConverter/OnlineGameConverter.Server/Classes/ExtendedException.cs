namespace OnlineGameConverter.Server.Classes
{
    public class ExtendedException : Exception
    {
        public IFormFile FormFile { get; set; }

        public IFormFile AdditionalFormFile { get; set; }

        public string Ext { get; set; }

        public string Directory { get; set; }

        public string InputDirectory { get; set; }

        public Exception Exception { get; set; }

        public ExtendedException(IFormFile formFile, IFormFile additionalFormFile, 
            string ext, string directory, string inputDirectory, Exception exception)
        {
            FormFile = formFile;
            AdditionalFormFile = additionalFormFile;
            Ext = ext;
            Directory = directory;
            InputDirectory = inputDirectory;
            Exception = exception;
        }
    }
}
