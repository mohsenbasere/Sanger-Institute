using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using Figgle;
using SangerClient.Handlers;

namespace SangerClient
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(FiggleFonts.Standard.Render("Sanger Institute Test"));
            if (Debugger.IsAttached)
            {
                args = new[] { "--file-path",
                    @"1234.fastq",
                    "--flag", "true" };
                ConfigCommandSystem(args);
                return;
            }
            ConfigCommandSystem(args);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void ConfigCommandSystem(string[] args)
        {
            var rootCommand = new RootCommand
            {
                new Option<string>(
                    "--file-path",
                    "Specify FASTQ file path."
                ),
                new Option<bool>(
                    "--flag",
                    "Specify the flag that means true ===> Sequence Count or  false ===> Nucleotides Count"),
            };
            rootCommand.Description =
                "Client to execute commands for given file path and flag that show information depends on flag";
            rootCommand.Handler = CommandHandler.Create<bool, string>(Handler.Execute);
            rootCommand.Invoke(args);
        }
    }
}
