using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    class Program
    {
        static Dictionary<string, dynamic> afisha = new Dictionary<string, dynamic>
        {
            {"1",  new {title = "Первый",       link = "https://tv.yandex.ru/channel/pervyy-16" } },
            {"2",  new {title = "Россия 1",     link = "https://tv.yandex.ru/channel/rossiya-1-31" } },
            {"3",  new {title = "Матч!",        link = "https://tv.yandex.ru/channel/match-tv-49" } },
            {"4",  new {title = "НТВ",          link = "https://tv.yandex.ru/channel/ntv-11" } },
            {"5",  new {title = "Культура",     link = "https://tv.yandex.ru/channel/kultura-14" } },
            {"6",  new {title = "Россия 24",    link = "https://tv.yandex.ru/channel/rossiya-24-3" } },
            {"7",  new {title = "ТВ Центр",     link = "https://tv.yandex.ru/channel/tv-centr-32" } },
            {"8",  new {title = "Рен ТВ",       link = "https://tv.yandex.ru/channel/ren-30" } },
            {"9",  new {title = "СТС",          link = "https://tv.yandex.ru/channel/sts-8" } },
            {"10", new {title = "ТВ-3",         link = "https://tv.yandex.ru/channel/tv-3-17" } },
            {"11", new {title = "Пятница",      link = "https://tv.yandex.ru/channel/pyatnica-42" } }
        };

        static void Main(string[] args)
        { 
            //выводим каналы, выводим содержимое словаря
            Console.Write("Выберите предпочтительный канал:\n" +
                $"{string.Join("\n", afisha.Select(x => $"{x.Key} - {x.Value.title}"))}\n\n" +
                 "> ");
            var channel = Console.ReadLine();//считываем данные, которые вводим
            var link = afisha[channel].link;//получаем необходимую ссылку через обращение в словарь по индексу

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, afisha[channel].title + ".md");//создаем путь, где сохраняются каналы, объединяем путь из 2 в один в строку

            using (StreamWriter sw = new StreamWriter(path))// сохраняем расписание
            {
                sw.WriteLine($"## {afisha[channel].title}");
                sw.WriteLine($"#### {DateTime.Now.ToLongDateString()}");
                foreach (SheduleItem item in Agility.GetShedule(link))//выводит расписание каналов
                {
                    Console.WriteLine($"{item.Time} - {item.Title}");
                    sw.WriteLine($"[{item.Time} - {item.Title}]({item.Link})\n");
                }
            }

            Console.WriteLine($"\nДанные успешно записаны в файл\n{path}");
            Console.ReadKey();
        }
    }
}
