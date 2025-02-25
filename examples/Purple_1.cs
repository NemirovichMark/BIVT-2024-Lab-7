using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_1 //обязательно публичный класс при выполнении заданий 
    {
        public struct Student
        {
            //поля характеристики все поля - приватные дальше будем опускать мод доступа 
            private string _name; //инициализируются дефолтные значения каким-то там конструктором типа встроенным 
            private int _age;
            private int[] _marks; //Дефолтное значение для ссылочных типов - None  

            // свойства (что разрешено делать с полями вручную прописываем) публинчые узнать имя, для чтения полей
            public string Name { get { return _name; } } //название свойства (также как переменную но с большой буквы) 
            //геттер - получение данных 
            public int Age => _age; //only read возвращаем только значение переменной -  тогда можно такую форму использовать, она эквивалетна записи выше 

          // public int[] Marks => _marks; //выдаем ссылку на _marks - так нельзя вместо этого 

            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null; //если обращаемся к свойству до запуска конструктора 

                    int[] copy = new int[_marks.Length];
                    // Array.Copy (откуда, куда,длина)
                    Array.Copy(_marks, copy, Marks.Length);
                    return copy;//отдаем ссылку на copy 
                }
            }
            public int MarksSum
            {
                get
                {
                    if (_marks == null) return 0; 
                    return _marks.Sum();
                }
            }
                                          

            //конструктор - специальные методы
            public Student(string name, int age) //в публичном конструкторе изменяем приватные переменные 
                // без типа возвращемого значения, совпадает с названием структуры 
            {
                _name = name;
                _age = age;
                _marks = new int[1];
            }

            //остальные методы 
            public void AddMark(int mark)
            {
                //добавляем новый массив на единицу больше 
                // меняем _marks = новый массив 
            }



        }
    }
}
