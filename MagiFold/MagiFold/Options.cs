using System;
using System.Collections.Generic;
using CommandLine;

namespace MagiFold
{
    public class Options
    {
        [Option('d', "directory", Default = ".", Required = true, HelpText = "The source directory containing the PDF files.")]
        public string Directory { get; set; }
    }
}
