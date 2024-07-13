// <copyright file="Program.cs" company="Paradisus.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

using System;
using System.Collections.Generic;
using CommandLine;

namespace MagiFold
{
    /// <summary>
    /// Main class.
    /// </summary>
    class MainClass
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
               .WithParsed(RunOptions);
        }

        /// <summary>
        /// Runs the options.
        /// </summary>
        /// <param name="options">Options.</param>
        static void RunOptions(Options options)
        {
            // Set last error
            List<string> errorList = new List<string>();

            /* Validate arguments */
        }
    }
}
