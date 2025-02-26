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
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks 
            {
                get
                {
                    if (_marks == null) return default(int[]);
                    int[] marks = new int[_marks.Length];
                    Array.Copy(_marks, marks, marks.Length);
                    return marks;
                }
            }
            public int Result
            {
                get
                {
                    if (_marks == null) return default(int);
                    int sum = 0, min = 21, max = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if( _marks[i] < min) min = _marks[i];
                        if( _marks[i] > max) max = _marks[i];
                        sum += _marks[i];
                    }
                    sum -= (max + min);
                    sum += _distance < 120 ? 60 - 2 * ((120 - _distance) / 2) : 60 +- 2 * ((_distance - 120) / 2);
                    return sum;
                }
            }

            public Participant (string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
            }

            public void Jump(int distance, int[] marks)
            {
                if (marks == null || _marks == null) return;

                _distance = distance;
                for (int i = 0; i < _marks.Length; i++) _marks[i] = marks[i];
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                for (int i = 1, j = 2; i < array.Length;)
                {
                    if (i == 0 || array[i - 1].Result > array[i].Result)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        var temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                        i--;
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine("Name: " + _name);
                Console.WriteLine("Surname: " + _surname);
                Console.WriteLine("Marks:");

                foreach (double item in _marks)
                {
                    Console.Write($"{item, 4}");
                }
                Console.WriteLine();

                
                
            }
        }
    }
}
