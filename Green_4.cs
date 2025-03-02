using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_4
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private double[] _jumps;


            //свойства
            public string Name  => _name;
            public string Surname  => _surname;
            public int[] Jumps
            {
                get
                {
                    if (_jumps == null) return null;
                    int[] copy = new int[_jumps.Length];
                    Array.Copy(_jumps, copy, _jumps.Length);
                    return copy;
                }
            }
            public double BestJump
            {
                get
                {
                    if (_jumps == null || _jumps.Length == 0) return 0;
                    double best = -1;
                    foreach (double jump in _jumps)
                    {
                        if (jump > best && jump != -1)
                            best = jump;
                    }
                    return best;
                }
            }

            //конструкторы
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _jumps = new double[3] { -1, -1, -1 };
            }

            //остальные методы
            public void Jump(double result)
            {
                if (_jumps == null) return;
                for (int i = 0; i < _jumps.Length; i++)
                {
                    if (_jumps[i] == -1)
                    {
                        _jumps[i] = result;
                        return;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].BestJump < array[j+1].BestJump)
                        {
                            (array[j],array[j+1])=(array[j+1],array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {BestJump}");
            }
            
        }
    }
}
