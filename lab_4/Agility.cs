using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab_4
{
    public class SheduleItem
    {
        public string Time { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }

    public static class Agility
    {
        private static Regex SheduleItem = new Regex(@"href=""(?<link>.*?)"".*?<time[^>]*>(?<time>.*?)<\/.*?channel-schedule__text[^>]*>(?<title>.*?)<\/");
        private static Match GetSheduleItem(string html) => SheduleItem.Match(html);

        public static IEnumerable<SheduleItem> GetShedule(string url)
        {
            var web = new HtmlWeb();//создание экземпляра класса htmlhelp
            var doc = web.Load(url);//принятие ссылки на сайт и возвращение html сайта

            var xPath = "//li[contains(@class,'channel-schedule__event')]";//парсинг html

            if (doc.DocumentNode.SelectNodes(xPath) != null)
            {
                foreach (var link in doc.DocumentNode.SelectNodes(xPath))
                {
                    var sheduleItems = GetSheduleItem(link.InnerHtml);

                    yield return new SheduleItem //вывод элементов коллекции
                    {
                        Time = sheduleItems.Groups["time"].Value,
                        Title = sheduleItems.Groups["title"].Value,
                        Link = "https://tv.yandex.ru" + sheduleItems.Groups["link"].Value
                    };
                }
            }
        }
    }
}
