using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Перевод из двоичной в деситичную и обратно

            Console.Write("Введите десятичное число:");
            int _num = Int32.Parse(Console.ReadLine()); // Получаем числа с консоли, Int32.Parse преобразует string в int
            string _binaryNum; // Сюда будут записываться 0 и 1 

            // Обращаюсь к статическому классу Convert чтобы вызвать метод ConvertToBinary() и перевести число _num
            _binaryNum = ConvertSystem.ConvertToBinary(_num);

            Console.WriteLine(_binaryNum);

            Console.WriteLine("Преобразование числа в десятичное");
            Console.Write("Введите двоичное число:");

            string _num2 = Console.ReadLine();

            Console.WriteLine(ConvertSystem.ConvertToDecimal(_num2));

            #endregion

            #region Поиск файлов директории из двоичной в деситичную в CSV

            //C:\Программирование\Lab1\ConsoleApp1\ConsoleApp1\CSV


            //Получаем все файлы с csv 
            Console.Write("Укажите директорию в которой необходимо изменть файлы:");
            string path = Console.ReadLine();


            List<Num> listNum = new List<Num>(); // Тут хранятся экземпляры класа Num
 
            // Перевод в двоичную систему

            /*foreach (var n in GetFilesSystem.GetCSV(path)) // использую класс GetFilesSysem  который вернет все файлы из деректорий (цикл нужен потому что файлов несколько)
            {
                Console.WriteLine(n);
                using (var reader = new StreamReader(n)) //Поток чтений
                {
                    // Парсю файлы CSV c помощью CSVHelper
                    using (CsvReader csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                    {
                        IEnumerable getEnum = csv.GetRecords<Num>(); 
                        IEnumerator getIn = getEnum.GetEnumerator();

                        while (getIn.MoveNext()) 
                        {
                            Num item = (Num)getIn.Current; 
                            listNum.Add(item);
                        }
                    }

                    // Перевожу в двоичную систему

                    listNum.ForEach(item => item.Mask = ConvertSystem.ConvertToBinary(Int16.Parse(item.Mask)));

                    Console.WriteLine($"Файл изменен! {n}");

                    // Записываю результат
                    using (StreamWriter sw = new StreamWriter(n)) // Поток записи
                    {
                        using (CsvWriter cw = new CsvWriter(sw, CultureInfo.CurrentCulture))
                        {
                            cw.WriteHeader<Num>();
                            cw.NextRecord();
                            foreach (var item in listNum)
                            {
                                cw.WriteRecord(item);
                                cw.NextRecord();
                            }
                        }
                    }

                    listNum.Clear();

                }

            }
            */
            // Перевод в десятичную систему


            
            foreach (var n in GetFilesSystem.GetCSV(path)) // используется класс GetFilesSysem, который вернет все файлы из деректорий (цикл нужен потому что файлов несколько)
            {
                Console.WriteLine(n);
                using (var reader = new StreamReader(n)) //Поток чтений
                {
                    // Парсинг файлов CSV c помощью CSVHelper
                    using (CsvReader csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                    {
                        IEnumerable getEnum = csv.GetRecords<Num>(); // 
                        IEnumerator getIn = getEnum.GetEnumerator();

                        while (getIn.MoveNext()) 
                        {
                            Num item = (Num)getIn.Current;  
                            listNum.Add(item);
                        }
                    }

                    // Перевожу в десятичную систему

                    listNum.ForEach(item => item.Mask = Convert.ToString(ConvertSystem.ConvertToDecimal(item.Mask)));

                    Console.WriteLine($"Файл изменен! {n}");

                    // Запись результата
                    using (StreamWriter sw = new StreamWriter(n)) // Поток записи
                    {
                        using (CsvWriter cw = new CsvWriter(sw, CultureInfo.CurrentCulture))
                        {
                            cw.WriteHeader<Num>();
                            cw.NextRecord();
                            foreach (var item in listNum)
                            {
                                cw.WriteRecord(item);
                                cw.NextRecord();
                            }
                        }
                    }

                    listNum.Clear();

                }

            }

            
            #endregion

        }


    }
}
