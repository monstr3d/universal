using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;


namespace ZipUtils
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionZipUtils
    {

        #region Fields

        static private string unZipDirectory;

        #endregion

        #region Ctor

        static StaticExtensionZipUtils()
        {
            try
            {
                SetExeConfiguration();
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Sets unzip directory
        /// </summary>
        /// <param name="unZipDirectory"></param>
        public static void SetUnzipDirectory(this string unZipDirectory)
        {
            if (StaticExtensionZipUtils.unZipDirectory != null)
            {
                return;
            }
            StaticExtensionZipUtils.unZipDirectory = unZipDirectory;
        }

        /// <summary>
        /// Creates zip buffer from file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>Zip buffer</returns>
        public static ZipBuffer ToZipBuffer(this string fileName)
        {
            return new ZipBuffer(fileName, unZipDirectory);
        }

        /// <summary>
        /// Unzip directory
        /// </summary>
        static public string UnZipDirectory
        {
            get { return unZipDirectory; }
        }

        /// <summary>
        /// Unzips to dictionary
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, byte[]> UnZipDictionary(this string fileName)
        {
               Dictionary<string, byte[]> d = new Dictionary<string, byte[]>();
               byte[] buffer = new byte[4096];
               using (ZipArchive  zf =  ZipFile.OpenRead(fileName))
               {
                   foreach (ZipArchiveEntry ze in zf.Entries)
                   {
                       using (var stream = ze.Open())
                       {
                           using (MemoryStream ms = new MemoryStream())
                           {
                               // Using a fixed size buffer here makes no noticeable difference for output
                               // but keeps a lid on memory usage.
                               int sourceBytes;
                               do
                               {
                                   sourceBytes = stream.Read(buffer, 0, buffer.Length);
                                   ms.Write(buffer, 0, sourceBytes);
                               }
                               while (sourceBytes > 0);
                               d[ze.Name] = ms.GetBuffer();
                           }
                       }
                   }
               }
               return d;
          }

        /// <summary>
        /// Creates ZIP
        /// </summary>
        /// <param name="buff">Buffer</param>
        /// <param name="outFile">File name</param>
        /// <param name="name">Entry</param>
        public static void CreateDefaultZip(this byte[] buff, string outFile, string name)
        {
            buff.CreateZip(unZipDirectory + outFile, name);
        }


        /// <summary>
        /// Crates default zip buffer
        /// </summary>
        /// <param name="buff">Buffer</param>
        /// <param name="outFile">Ouptut file</param>
        /// <param name="name">Name of entry</param>
        /// <returns>Zip</returns>
        public static byte[] CreateDefaultZipBuffer(this byte[] buff, string outFile, string name)
        {
            string fn = unZipDirectory + outFile;
            buff.CreateZip(fn, name);
            byte[] b = [];
            using (Stream stream = File.OpenRead(fn))
            {
                b = new byte[stream.Length];
                stream.Read(b, 0, b.Length);
            }
            try
            {
                File.Delete(fn);
            }
            catch
            {

            }
            return b;
        }

        /// <summary>
        /// Zips files of the directory 
        /// </summary>
        /// <param name="directory">Zips files of the directory</param>
        /// <param name="searchPattern">Search pattern</param>
        /// <param name="deleteFiles">Delete files sign</param>
        public static void ZipDirectoryFiles(this string directory, string searchPattern, bool deleteFiles = true)
        {
            string[] files = Directory.GetFiles(directory, searchPattern);
            string d = directory;
            if (d[d.Length - 1] != Path.DirectorySeparatorChar)
            {
                d += Path.DirectorySeparatorChar;
            }
            foreach (string file in files)
            {
                string fn = Path.GetFileNameWithoutExtension(file) + ".zip";
                file.CreateZip(d + fn, Path.GetFileName(file));
                if (deleteFiles)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch
                    {

                    }
                }
            }
        }

        /// <summary>
        /// Creates ZIP
        /// </summary>
        /// <param name="inFile">Input File</param>
        /// <param name="outFile">File name</param>
        /// <param name="name">Entry</param>
        public static void CreateZip(this string inFile, string outFile, string name)
        {
            if (File.Exists(outFile))
            {
                try
                {
                    File.Delete(outFile);
                }
                catch
                {

                }
            }
   /*         using (ZipOutputStream s = new ZipOutputStream(File.Create(outFile)))
            {
                s.SetLevel(9); // 0 - store only to 9 - means best compression

                byte[] buffer = new byte[4096];
                ZipEntry entry = new ZipEntry(name);


                // Setup the entry data as required.

                // Crc and size are handled by the library for seakable streams
                // so no need to do them here.

                // Could also use the last write time or similar for the file.
                entry.DateTime = DateTime.Now;
                s.PutNextEntry(entry);


                using (Stream ins = File.OpenRead(inFile))
                {

                    // Using a fixed size buffer here makes no noticeable difference for output
                    // but keeps a lid on memory usage.
                    int sourceBytes;
                    do
                    {
                        sourceBytes = ins.Read(buffer, 0, buffer.Length);
                        s.Write(buffer, 0, sourceBytes);
                    }
                    while (sourceBytes > 0);
                }
                s.Finish();
                s.Close();
            }*/
        }



        /// <summary>
        /// Creates ZIP
        /// </summary>
        /// <param name="buff">Buffer</param>
        /// <param name="outFile">File name</param>
        /// <param name="name">Entry</param>
        public static void CreateZip(this byte[] buff, string outFile, string name)
        {
            if (File.Exists(outFile))
            {
                try
                {
                    File.Delete(outFile);
                }
                catch
                {
                    
                }
            }
   /*         using (ZipOutputStream s = new ZipOutputStream(File.Create(outFile)))
            {
                s.SetLevel(9); // 0 - store only to 9 - means best compression

                byte[] buffer = new byte[4096];
                ZipEntry entry = new ZipEntry(name);


                // Setup the entry data as required.

                // Crc and size are handled by the library for seakable streams
                // so no need to do them here.

                // Could also use the last write time or similar for the file.
                entry.DateTime = DateTime.Now;
                s.PutNextEntry(entry);


                using (Stream ms = new MemoryStream(buff))
                {

                    // Using a fixed size buffer here makes no noticeable difference for output
                    // but keeps a lid on memory usage.
                    int sourceBytes;
                    do
                    {
                        sourceBytes = ms.Read(buffer, 0, buffer.Length);
                        s.Write(buffer, 0, sourceBytes);
                    }
                    while (sourceBytes > 0);
                }
                s.Finish();
                s.Close();
            }*/
        }

        /// <summary>
        /// Creates ZIP from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary</param>
        /// <param name="outFile">Output file</param>
        public static void CreateZip(this Dictionary<string, byte[]> dictionary, string outFile)
        {
            /*
            using (ZipOutputStream s = new ZipOutputStream(File.Create(outFile)))
            {
                s.SetLevel(9); // 0 - store only to 9 - means best compression

                byte[] buffer = new byte[4096];
                foreach (string key in dictionary.Keys)
                {
                    ZipEntry entry = new ZipEntry(key);


                    // Setup the entry data as required.

                    // Crc and size are handled by the library for seakable streams
                    // so no need to do them here.

                    // Could also use the last write time or similar for the file.
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);

                    using (Stream ms = new MemoryStream(dictionary[key]))
                    {

                        // Using a fixed size buffer here makes no noticeable difference for output
                        // but keeps a lid on memory usage.
                        int sourceBytes;
                        do
                        {
                            sourceBytes = ms.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        }
                        while (sourceBytes > 0);
                    }
                }
                s.Finish();
                s.Close();
            }
            */
        }

        public static void CreateZipFromDirectory(this string dir, string outFile)
        {

            try
            {
                ZipFile.CreateFromDirectory(dir, outFile);
             /* !!!  // Depending on the directory this could be very large and would require more attention
                // in a commercial package.
                // string[] filenames = Directory.GetFiles(dir);

                // 'using' statements guarantee the stream is closed properly which is a big source
                // of problems otherwise.  Its exception safe as well which is great.
                using (ZipOutputStream s = new ZipOutputStream(File.Create(outFile)))
                {

                    s.SetLevel(9); // 0 - store only to 9 - means best compression

                    byte[] buffer = new byte[4096];

                    ProcessDir(s, dir, dir, buffer);

                    // Finish/Close arent needed strictly as the using statement does this automatically

                    // Finish is important to ensure trailing information for a Zip file is appended.  Without this
                    // the created file would be invalid.
                    s.Finish();

                    // Close is important to wrap things up and unlock the file.
                    s.Close();
                }*/
            }
            catch (Exception)
            {
            }
             
        }

        /// <summary>
        /// Clears content of directory
        /// </summary>
        /// <param name="directory">The directory</param>
        public static void ClearDirectory(this string directory)
        {
            string[] files = Directory.GetFiles(directory);
            foreach (string f in files)
            {
                File.Delete(f);
            }
            string[] dirs = Directory.GetDirectories(directory);
            foreach (string d in dirs)
            {
                d.ClearDirectory();
                Directory.Delete(d);
            }
        }


        /// <summary>
        /// Unzips file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>Unzipped files</returns>
        public static string UnZip(this string filename)
        {
            filename.UnZip(unZipDirectory);
            string f = null;
         /// !!!  
            return unZipDirectory + filename;
        } 


        /// <summary>
        /// UnZips file to directory
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="directory">Directory</param>
        public static void UnZip(this string fileName, string directory)
        {
            ZipFile.ExtractToDirectory(fileName, directory);
        }

/*!!!
        /// <summary>
        /// Writes zip file
        /// </summary>
        /// <param name="file">File</param>
        /// <param name="entry">Entry</param>
        /// <param name="dir">Directory</param>
        public static void Write(this ZipFile file, ZipEntry entry, string dir)
        {
            string rp = entry.Name.Replace('/', Path.DirectorySeparatorChar);
            string outPath = dir + rp;
            int n = 0;
            while (true)
            {
                n = outPath.IndexOf(Path.DirectorySeparatorChar + "", n + 1);
                if (n < 0)
                {
                    break;
                }
                string p = outPath.Substring(0, n);
                if (!Directory.Exists(p))
                {
                    Directory.CreateDirectory(p);
                }
            }
            using (Stream input = file.GetInputStream(entry))
            {
                using (Stream output = File.OpenWrite(outPath))
                {
                    input.CopyTo(output);
                }
            }
        }
*/

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="inPath">Input path</param>
        /// <param name="outPath">Output path</param>
        public static void Copy(string inPath, string outPath)
        {
            int n = 0;
            while (true)
            {
                n = outPath.IndexOf(Path.DirectorySeparatorChar + "", n + 1);
                if (n < 0)
                {
                    break;
                }
                string p = outPath.Substring(0, n);
                if (!Directory.Exists(p))
                {
                    Directory.CreateDirectory(p);
                }
            }
            if (!File.Exists(outPath) & File.Exists(inPath))
            {
                File.Copy(inPath, outPath);
            }
        }

        /// <summary>
        /// Sets exe configuration
        /// </summary>
        public static void SetExeConfiguration()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            string path = config.FilePath;
            string p = Path.GetDirectoryName(path);
            char s = Path.DirectorySeparatorChar;
            if (p[p.Length - 1] != s)
            {
                p += s;
            }
            string dir = p + "Zip" + s;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            dir.SetUnzipDirectory();
        }

        #endregion

        #region Private Members

        /*
        static void ProcessDir(ZipOutputStream s, string baseDir, string dir, byte[] buffer)
        {
           
            string pr = dir.Substring(baseDir.Length);
            pr = pr.Replace("\\", "/");
            if (pr.Length > 0)
            {
                if (pr[pr.Length - 1] != '/')
                {
                    pr += '/';
                }
            }
            string[] filenames = Directory.GetFiles(dir);
            foreach (string file in filenames)
            {

                // Using GetFileName makes the result compatible with XP
                // as the resulting path is not absolute.
                ZipEntry entry = new ZipEntry(pr + Path.GetFileName(file));

                // Setup the entry data as required.

                // Crc and size are handled by the library for seakable streams
                // so no need to do them here.

                // Could also use the last write time or similar for the file.
                entry.DateTime = DateTime.Now;
                s.PutNextEntry(entry);

                using (FileStream fs = File.OpenRead(file))
                {

                    // Using a fixed size buffer here makes no noticeable difference for output
                    // but keeps a lid on memory usage.
                    int sourceBytes;
                    do
                    {
                        sourceBytes = fs.Read(buffer, 0, buffer.Length);
                        s.Write(buffer, 0, sourceBytes);
                    }
                    while (sourceBytes > 0);
                }
            }

            string[] dirs = Directory.GetDirectories(dir);
            foreach (string d in dirs)
            {
                ProcessDir(s, baseDir, d, buffer);
            }


        }
        */

        #endregion

    }
}
