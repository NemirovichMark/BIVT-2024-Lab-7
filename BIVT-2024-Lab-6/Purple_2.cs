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

            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public string Surname
            {
                get
                {
                    return _surname;
                }
            }

            public int Distance
            {
                get
                {
                    return _distance;
                }
            }

            public int[] Marks
            {
                get
                {
                    if (_marks is null) return null;
                    int[] marksCopy = new int[_marks.Length];
                    Array.Copy(_marks, marksCopy, marksCopy.Length);
                    return marksCopy;
                }
            }

            public int Result
            {
                get
                {
                    if (_marks is null) return 0;
                    if (_distance == 0) return 0;

                    int result = 0;

                    int maxMarkIdx = 0, minMarkIdx = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] > _marks[maxMarkIdx])
                            maxMarkIdx = i;
                        if (_marks[i] < _marks[minMarkIdx])
                            minMarkIdx = i;
                        result += _marks[i];
                    }
                    result -= _marks[maxMarkIdx];
                    result -= _marks[minMarkIdx];

                    result += 60 + (_distance - 120) * 2;

                    if (result < 0) return 0;

                    return result;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
            }

            public void Jump(int distance, int[] marks)
            {
                if (_marks is null || marks is null || marks.Length != 5) return;

                if (distance < 0) return;

                for (int i = 0; i < 5; i++)
                {
                    if (marks[i] < 1 || marks[i] > 20)
                    {
                        return;
                    }
                }
                _distance = distance;
                for (int i = 0; i < 5; i++)
                {
                    _marks[i] = marks[i];
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length < 2) return;

                int n = array.Length;
                for (int i = 1, j = 2; i < n;)
                {
                    if (i == 0 || array[i].Result < array[i - 1].Result)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        Participant temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        i--;
                    }
                }
            }

            public void Print()
            {
                if (_surname == "" || _name == "")
                {
                    return;
                }

                Console.WriteLine($"{_name} {_surname} {Result}");
            }
        }

        
    }
}
