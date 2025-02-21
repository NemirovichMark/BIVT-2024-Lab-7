using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Purple_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;
            private int _result;

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }

            public int Distance { get { return _distance; } }
            public int[] Marks
            {
                get
                {
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, copy.Length);
                    return copy;
                }
            }

            public int Result { get { return _result; } }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j]._result < array[j + 1]._result)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }

                }
            }

            public void Print()
            {
                Console.Write(_name + " ");
                Console.Write(_surname + " ");
                Console.WriteLine(_result + " ");
            }

            public void Jump(int distance, int[] marks)
            {
                if (marks == null || marks.Length != 5) return;
                if (distance < 0) return;
                _distance = distance;

                for (int i = 0; i < marks.Length; i++)
                {
                    _marks[i] = marks[i];
                }

                Array.Sort(marks);

                for (int i = 1; i < marks.Length - 1; i++)
                {
                    
                    _result += marks[i];
                }

                if (distance - 120 >= 0)
                {
                    _result += 60;
                    _result += (distance - 120) * 2;
                }

                else
                {
                    _result += 60;
                    _result -= (120 - distance) * 2;
                    if (_result < 0) _result = 0;
                }
            }
        }

    }
}
