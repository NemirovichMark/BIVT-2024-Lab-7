using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_2
    {
        public struct Participant
        {

            // приватные поля
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            private int _result;
            // публичные свойства только для чтения 

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Distance { get { return _distance; } }
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int Result { get { return _result; } }

            //конструктор паблик 
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;

                _distance = 0;
                _marks = new int[5];

                _result = 0;

            }

            //методы 

            public void Jump(int distance, int[] marks)
            {
                if (_marks == null || marks==null ) return;
                _distance = distance;
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = marks[i];
                }

                int[] copy= new int[_marks.Length];
                Array.Copy(_marks, copy, _marks.Length);
                Array.Sort(copy);
                _result += (copy.Sum() - copy[0] - copy[copy.Length - 1]);
                _result += 60;
                if (_distance > 120) _result += (_distance-120)*2;
                else
                {
                    if (_result - (120 - _distance) * 2 < 0) _result = 0;
                    else _result-= (120 - _distance) * 2;
                }

                

            }


            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].Result < array[j + 1].Result)
                        {
                            Participant copy = array[j + 1];
                            array[j + 1] = array[j];
                            array[j] = copy;

                        }
                    }
                }

            }

            public void Print()
            {
                Console.WriteLine($"{this.Name} {this.Surname}: {this.Result}");
            }


        }

    }
}
