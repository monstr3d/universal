using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbxConverter
{

    /// <summary>
    /// Format of file
    /// </summary>
    public enum FileFormat
    {
        Unknown,
        Binary,
        Ascii
    };



    /// <summary>
    /// Performer
    /// </summary>
    public class Performer
    {
        string GetFullPathString(string pPath)
        {
            /*
                    assert(pPath != nullptr && pPath[0] != 0 );

                    char fullpath[256] = { 0 };
                    DWORD length = GetFullPathNameA(pPath, 256, fullpath, nullptr);
                    assert(length != 0 && length != 255 );

                    // We always append the trailing slash to simplify further operations
                    DWORD const result = GetFileAttributesA(fullpath);
                    if (result != INVALID_FILE_ATTRIBUTES && (result & FILE_ATTRIBUTE_DIRECTORY ) && fullpath[length - 1] != '\\' )
                    {
                        fullpath[length] = '\\';
                        fullpath[length + 1] = 0;
                    }
            */

            return pPath;
        }
    }
}