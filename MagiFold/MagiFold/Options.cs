using System;
using System.Collections.Generic;
using CommandLine;

namespace MagiFold
{
    public class Options
    {
        [Option('d', "directory", Default = ".", Required = true, HelpText = "The destination directory for the generated 'matches.txt', 'unmatched.txt' and 'collisions.txt' files.")]
        public string directory { get; set; }
    }
}
