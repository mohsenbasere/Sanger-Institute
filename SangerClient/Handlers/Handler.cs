using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Framework.Commons;
using Framework.Parser.FASTQs;

namespace SangerClient.Handlers
{
    public static class Handler
    {
        public static void Execute(bool flag, string filePath)
        {
            GetFASTQSequenceCount(filePath);
        }

        private static void GetFASTQSequenceCount(string filePath)
        {
            var list = new List<FASTQSequence>();
            IParser<FASTQSequence> parser = new FASTQParser();
            using var fs = File.OpenRead(filePath);
            list = parser.Parse(fs).ToList();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Sequence Count: {list.Count}");
        }
    }
}