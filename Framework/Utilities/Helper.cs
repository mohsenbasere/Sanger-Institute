using System.IO;
using System.IO.Compression;

namespace Framework.Utilities
{
    public static class Helper
    {
        public static GZipStream GZipReader(Stream stream)
        {
            return new GZipStream(stream, CompressionMode.Decompress);
        }
    }
}