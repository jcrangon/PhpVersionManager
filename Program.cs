using HtmlAgilityPack;
using System;

namespace PhpVersionManager
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (!Convert.ToBoolean(args.Length))
            {
                Console.ReadKey(true);

            } else
            {
                switch (args[0])
                {
                    case "list":
                        if (args[1].Length != 0 && args[1] == "available")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Listing all available versions");
                            Web.Harvester();

                        }
                        break;
                    case "ls":
                        Console.WriteLine("");
                        Console.WriteLine("Listing all installed versions...");
                        await Utils.ListVersions();   
                        break;
                    case "install":
                        if (args[1].Length != 0)
                        {
                            string version = args[1];
                            Console.WriteLine("");
                            Console.WriteLine($"Installing version {version}");
                             await Downloader.PhpDownload(version);
                        }
                        break;
                    case "use":
                        if (args[1].Length != 0)
                        {
                            Console.WriteLine("");
                            string version = args[1];
                            Console.WriteLine($"Activating version {version}...");
                            await Utils.setActiveVersion(version);
                        }
                        break;
                    case "remove":
                        if (args[1].Length != 0)
                        {
                            Console.WriteLine("");
                            string version = args[1];
                            Console.WriteLine($"Removing version {version}...");
                            await Utils.RemoveVersion(version);
                        }
                        break;

                    case "display":
                        if (args[1].Length != 0 && args[1] == "ini")
                        {
                            Console.WriteLine("");
                            string version = args[1];
                            Console.WriteLine($"Displaying php.ini...");
                            await Utils.DisplayIni();
                        }
                        break;

                    case "-help":
                        Console.WriteLine("");
                        Console.WriteLine("Printing PVM help...");
                        Utils.DisplayHelp();
                        break;

                    case "-h":
                        Console.WriteLine("");
                        Console.WriteLine("Printing PVM help...");
                        Utils.DisplayHelp();
                        break;
                }
            }
            
        }
    }
}