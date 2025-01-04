namespace Wpf.Loader
{
    /// <summary>
    /// Generator of filename
    /// </summary>
    public interface IFilenameGenerator
    {
        /// <summary>
        /// Generates name of file
        /// </summary>
        /// <param name="ext">The extension</param>
        /// <param name="path">The path</param>
        string GenerateFileName(string ext, out string path);

        /// <summary>
        /// Cleans files
        /// </summary>
        void Clean();
    }
}
