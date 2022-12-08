using System;
using System.IO;
using System.Linq;

namespace ModularMotionUpgradeFix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Assets Folder Path: ");
            var path = Console.ReadLine();
            
            Console.Write("Old GUID: ");
            var oldGuid = Console.ReadLine();
            
            Console.Write("New GUID: ");
            var newGuid = Console.ReadLine();
            
            Fix(path, oldGuid, newGuid);
        }

        private static void Fix(string path, string g1, string g2)
        {
            foreach (var fileInfo in Directory.GetFiles(path,"*.*", SearchOption.AllDirectories))
            {
                if (fileInfo.EndsWith(".unity") || fileInfo.EndsWith(".prefab"))
                {
                    Console.Out.Write($"{fileInfo.Split("/").Last()}");
                    var file = File.ReadAllText(fileInfo);
                    if (!file.Contains(g1))
                    {
                        Console.Out.WriteLine($"    skip");
                        continue;
                    }

                    Console.Out.WriteLine($"    replaced");
                    file = file.Replace(g1, g2);
                    File.WriteAllText(fileInfo, file);
                }
            }
        }
    }
}