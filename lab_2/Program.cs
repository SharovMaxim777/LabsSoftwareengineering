using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2

    {
    public static class Utils_2
    {
        public static IEnumerable<string> GetFilesAndFolders(string rootPath)
        {
            yield return rootPath;

            foreach (var files in Directory.GetFiles(rootPath))
            {
                yield return files;
            }

            yield return "\n"; // Визуальное разделение разных каталогов

            foreach (var dirs in Directory.GetDirectories(rootPath))
            {
                foreach (var file in GetFilesAndFolders(dirs))
                {
                    yield return file;  // возвращение элементов коллекции
                }
            }

        }
    }
    class Program
    {
        static void Main()
        {
            foreach (string item in Utils_2.GetFilesAndFolders(AppDomain.CurrentDomain.BaseDirectory))
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
