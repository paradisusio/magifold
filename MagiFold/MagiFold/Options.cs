// <copyright file="Options.cs" company="Paradisus.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

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
