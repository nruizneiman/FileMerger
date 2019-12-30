using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMerger
{
    class Program
    {
        private static Random _random = new Random();

        static void Main(string[] args)
        {
            Console.Title = "FILE MERGER";

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"  ______ _____ _      ______   __  __ ______ _____   _____ ______ _____  ");
            Console.WriteLine(@" |  ____|_   _| |    |  ____| |  \/  |  ____|  __ \ / ____|  ____|  __ \ ");
            Console.WriteLine(@" | |__    | | | |    | |__    | \  / | |__  | |__) | |  __| |__  | |__) |");
            Console.WriteLine(@" |  __|   | | | |    |  __|   | |\/| |  __| |  _  /| | |_ |  __| |  _  / ");
            Console.WriteLine(@" | |     _| |_| |____| |____  | |  | | |____| | \ \| |__| | |____| | \ \ ");
            Console.WriteLine(@" |_|    |_____|______|______| |_|  |_|______|_|  \_\\_____|______|_|  \_\");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(@"Source Path [example: 'C:\Scripts']: ");
            string filepath = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("File extension [example: '.txt']: ");
            string extension = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("Output File Name (It will be created at you Desktop folder) [example: 'MergedFinalFile']: ");
            string bigFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + Console.ReadLine() + extension;

            if (!string.IsNullOrEmpty(filepath) && !string.IsNullOrEmpty(bigFilePath))
            {
                DirectoryInfo baseDir = new DirectoryInfo(filepath);

                foreach (var file in baseDir.GetFiles("*" + extension))
                {
                    //Console.ForegroundColor = GetRandomConsoleColor();
                    //Console.BackgroundColor = GetRandomConsoleColor();

                    Console.ForegroundColor = ConsoleColor.Green;

                    FileStream f = new FileStream(file.FullName, FileMode.Open);
                    StreamReader s = new StreamReader(f);

                    string line = string.Empty;
                    while ((line = s.ReadLine()) != null)
                    {
                        Console.WriteLine(line);

                        StreamWriter file2 = new StreamWriter(bigFilePath, true);

                        file2.WriteLine(line);

                        file2.Close();

                    }

                    StreamWriter masterFile = new StreamWriter(bigFilePath, true);
                    masterFile.WriteLine();
                    masterFile.WriteLine("-------------------------------------------------------------------------------------------------");
                    masterFile.WriteLine("------------------------------------------- DIVIDER ---------------------------------------------");
                    masterFile.WriteLine("-------------------------------------------------------------------------------------------------");
                    masterFile.WriteLine();
                    masterFile.Close();
                }

                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Ready! Press any key to exit.");
                Console.ReadKey();
            }
        }

        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }
    }
}
