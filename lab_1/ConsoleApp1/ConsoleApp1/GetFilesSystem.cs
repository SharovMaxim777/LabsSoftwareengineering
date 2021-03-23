using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    static class GetFilesSystem
    {

        static public List<string> GetCSV(string path)
        {
            List<string> Fulldirs = new List<string>(); // Тут сохраняются все директории
            List<string> Updirs; //Тут будут храниться дачерние директории которые находятся выше
            List<string> Downdirs = new List<string>(); // Тут будут храниться дачерние директории которое ниже
            List<string> PathCSVFiles = new List<string>(); // Пути к файлам

            Fulldirs.Add(path);
            Updirs = Directory.GetDirectories(path).ToList();

            /*Ищет все поддиректории*/
            for (; ; )
            {
                if (Updirs.Count == 0)
                {
                    break;
                }

                foreach (var n in Updirs)
                {
                    Fulldirs.Add(n);

                    foreach (var j in Directory.GetDirectories(n).ToList())
                    {
                        Downdirs.Add(j);
                    }

                }
                Updirs.Clear(); // Чистка списка
                Updirs.AddRange(Downdirs.ToArray()); //Копирование элемента из одного списка в другой
                Downdirs.Clear();
            }

            /*Поиск всех CSV файлов*/

            foreach (var n in Fulldirs)
            {
                foreach (var j in Directory.GetFiles(n))
                {
                    // проверяем является ли файл csv
                    if (j.Contains(".csv"))
                    {
                        PathCSVFiles.Add(j);
                    }
                }
            }
            
            return PathCSVFiles;
        }

    }
}
