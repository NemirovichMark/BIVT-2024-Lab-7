using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Program //класс доступен везде в рамках неймспейса, internal - по умолчанию 
        // по умолчанию у методов внутри класса; private писать напрямую модификаторы доступа пока что 
    {
        static void Main(string[] args)
        {
            Program p = new Program();// создание экземпляра класса
            //Purple_1 purple_1 = new Purple_1();

            Purple_1.Student s = new Purple_1.Student("Petya", 20); //обращаемся к структуре 
            Console.WriteLine(s.Name);

            s.Marks[0] = 6;//обращаемся по ссылке и можем поменять значения 
            foreach (int mark in s.Marks)
            {
                Console.WriteLine(mark);
            }

            //структура - значимый тип можно без конструктора new
        }
    }
}
