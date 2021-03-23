using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    static class ConvertSystem
    {
       
        public static string ConvertToBinary(int _num)
        {
            string binaryNum = "";
            int num = _num;

            for (; ; ) // for (;;) бесконечный цикл 
                if (num >= 2) // если число больше основания системы счисления 
                {
                    // деление на основание системы счисления
                    if (num % 2 == 0)
                        binaryNum += "0"; // Есле нет остатка от деления, то добавить к строке 0
                    else
                        binaryNum += "1"; // Есле есть остаток от деления то добавить к строке 1
                    num /= 2;
                }
                else
                {
                    binaryNum += "1"; // когда число меньше 2 еще добавить 1
                    // Когда число станет меньше основания системы счисления, то 2 цикл завершится
                    break;
                }

            return binaryNum;
        }

        public static int ConvertToDecimal(string _num)
        {
            int decimalNum = 0;
            string num = _num;

            List<int> NumsList = num.ToCharArray().Select(item => item - 48).ToList(); //Преобразование строки в массив чисел 1 и 0 

            for(int i = 0; i < NumsList.Count(); i++)
                if(NumsList[i] == 1)
                    decimalNum += (int)Math.Pow(2, i);// Чтобы перевести в десятичное число, двоичное число нужно умножить на 2 встепени равной его поизции
                

            return decimalNum;
        }
    }
}
