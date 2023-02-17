using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Framework.Commons;
using Framework.Parser.FASTQs;
using Framework.Utilities;

namespace SangerClient.Handlers
{
    public static class Handler
    {
        public static void Execute(bool flag, string filePath)
        {
            try
            {
                if (flag)
                {
                    GetFASTQSequenceCount(filePath);
                }
                else
                {
                    GetFASTQNucleotidesCount(filePath);
                }
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception.Message);
            }
        }

        private static void GetFASTQSequenceCount(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            var list = new List<FASTQSequence>();
            IParser<FASTQSequence> parser = new FASTQParser();
            using var fs = File.OpenRead(filePath);
            if (fileInfo.Extension.ToLower() == ".gz")
            {
                using var gz = Helper.GZipReader(fs);
                list.AddRange(parser.Parse(gz));
            }
            else
            {
                list = parser.Parse(fs).ToList();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Sequence Count: {list.Count}");
        }

        private static void GetFASTQNucleotidesCount(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            IParser<FASTQSequence> parser = new FASTQParser();
            var list = new List<FASTQSequence>();
            using var fs = File.OpenRead(filePath);
            long count;

            if (fileInfo.Extension.ToLower() == ".gz")
            {
                using var gz = Helper.GZipReader(fs);
                list.AddRange(parser.Parse(gz));
                count = list.Sum(item => Encoding.UTF8.GetString(item.SequenceData).Length);
            }
            else
            {
                list = parser.Parse(fs).ToList();
                count = list.Sum(item => Encoding.UTF8.GetString(item.SequenceData).Length);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Nucleotides Count: {count}");
        }
    }
}