using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using vic_qsrank.Core;
using Console = Colorful.Console;

namespace vic_qsrank.ConsoleApp
{
    class Program
    {
        public class Options
        {
            //[Option('c', "number-of-cores", Default = 1, Required = true, HelpText = "Number of cores that might be used.")]
            //public int Cores { get; set; }

            [Option('f', "input-file", Required = true, HelpText = "Arff file.")]
            public string InputFile { get; set; }

            //[Option('o', "output-directory", Required = true, HelpText = "Output directory where all results shall be written.")]
            //public string OutputDirectory { get; set; }

            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }

            [Usage(ApplicationAlias = "vic-qsrank")]
            public static IEnumerable<Example> Examples
            {
                get
                {
                    return new List<Example>() {
                        new Example("Analize arff file", new Options {
                            InputFile="C:\\Users\\{user}\\Desktop\\list.csv",
                            //OutputDirectory="C:\\Users\\{user}\\Desktop\\Output",
                            Verbose=false
                        })
                    };
                }
            }

        }

        static void Main(string[] args)
        {
            string title = string.Format("VIC QS ranking V{0}", Assembly.GetExecutingAssembly().GetName().Version);
            int width = title.Length + 10;
            Console.WriteLine(new string('#', width), color: Color.Green);
            Console.Write("#" + new string(' ', 4), color: Color.Green);
            Console.Write(title);
            Console.WriteLine(new string(' ', 4) + "#", color: Color.Green);
            Console.WriteLine(new string('#', width), color: Color.Green);

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(options =>
                {
                    try
                    {
                        ArffHandler arffHandler = new ArffHandler("C:\\Users\\jrenewhite\\source\\repos\\ScopusScrapper\\Datasets\\QSRanking.arff", verbose: true);
                        ClassifierHandler.GetCommands("C:\\Users\\jrenewhite\\source\\repos\\vic-classifiers");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message, color: Color.OrangeRed);
                    }

                });
            Console.Read();
        }
    }
}
