// <copyright file="Program.cs" company="Paradisus.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

using System;
using System.Collections.Generic;
using CommandLine;
using System.IO;
using System.Linq;

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
            // The error list
            List<string> errorList = new List<string>();

            // Set directory in case it's "."
            if (options.Directory == ".")
            {
                // Set to current assembly location
                options.Directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }

            // Set directory path
            string directoryPath = options.Directory;

            // Set pdf files
            List<string> pdfFiles = new List<string>();

            /* Validate arguments */

            // Check directory
            if (!Directory.Exists(directoryPath))
            {
                // Add error
                errorList.Add("Source directory does not exist.");
            }
            else
            {
                // Set pdf files
                pdfFiles = Directory.EnumerateFiles(directoryPath, "*.pdf", SearchOption.TopDirectoryOnly).ToList();

                // Check there are PDF files to work with
                if (!pdfFiles.Any())
                {
                    // Add error
                    errorList.Add("There are no .pdf files to work with.");
                }
            }

            // Check error list 
            if (errorList.Count > 0)
            {
                // Print error(s)
                PrintErrors(errorList);

                // Halt flow
                return;
            }

            /* Folderize and add TXT file */

            // Advise user
            Console.WriteLine($"Processing {pdfFiles.Count()} files...");

            // Error count
            int errorCount = 0;

            // Iterate files
            foreach (var pdfFile in pdfFiles)
            {
                try
                {
                    // Strip file extension
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pdfFile);

                    // Set the subdirectory path
                    string subdirectoryPath = Path.Combine(directoryPath, fileNameWithoutExtension);

                    // Create matching directory 
                    Directory.CreateDirectory(subdirectoryPath);

                    // Move the pdf file 
                    File.Move(pdfFile, Path.Combine(subdirectoryPath, Path.GetFileName(pdfFile)));

                    // Create matching txt file
                    string txtFilePath = Path.Combine(subdirectoryPath, $"{fileNameWithoutExtension}.txt");

                    // Write the name without extension
                    File.WriteAllText(txtFilePath, fileNameWithoutExtension);
                }
                catch (Exception ex)
                {
                    // Raise error count
                    errorCount++;
                }
            }

            // Advise user
            Console.WriteLine($"Files processed with {errorCount} error{(errorCount == 1 ? string.Empty : "s")}.");
        }

        /// <summary>
        /// Prints the errors.
        /// </summary>
        /// <param name="errorList">Error list.</param>
        static void PrintErrors(List<string> errorList)
        {
            // Print errors
            Console.WriteLine($"{Environment.NewLine}ERROR(S):{Environment.NewLine}  {string.Join(Environment.NewLine + "  ", errorList)}");
        }
    }
}
