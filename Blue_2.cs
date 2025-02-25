using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_2
    {
        
        public struct Participant 
        {
            private string _name;
            private string _surname;
            private int[,] _marks;

            private int _estimated_jumps;  // вспомогательное поле, не указанное в задании

            public Participant(string name, string surname) { 
                _name = name;
                _surname = surname;
                _marks = new int[2, 5] { {0, 0, 0, 0, 0}, {0, 0, 0, 0, 0} };
                _estimated_jumps = 0;
            }

            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks => _marks;

            public int TotalScore
            {
                get
                {
                    if (_marks == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            sum += _marks[i, j];
                        }
                    }
                    return sum;
                }
            }


            public void Jump(int[] result) {
                if (result == null || result.Length != 5)
                {
                    Console.WriteLine("За прыжок участника должно быть выставлено ровно 5 оценок");
                }
                else {
                    if (_estimated_jumps < 2)
                    {
                        int r = 0;
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            _marks[_estimated_jumps, j] = result[r++];
                        }
                        _estimated_jumps++;
                    }
                }
            }

            public static void Sort(Participant[] array) {
                if (array == null) { return; }
                for (int i = 0; i <= array.Length; i++) {
                    for (int j = i; j < array.Length; j++) {
                        if (array[i].TotalScore < array[j].TotalScore) { 
                            Participant tmp = array[i];
                            array[i] = array[j];
                            array[j] = tmp;
                        }
                    }
                }
            }

            public void Print() {
                Console.WriteLine($"{_name} {_surname} {TotalScore}");
            }
        }
    }
}
