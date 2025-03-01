using System;
using System.Linq;


namespace Lab_6
{
    public class Green_4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _jumps;

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

            public double[] Jumps
            {
                get
                {
                    return (double[])_jumps.Clone(); 
                }
            }


            public double BestJump
            {
                get
                {
                    if (_jumps != null && _jumps.Length > 0)
                    {
                        return _jumps.Max();
                    }
                    return 0;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _jumps = new double[3];
            }

            public void Jump(double result)
            {
                if (_jumps == null) return;
                if (_jumps != null)
                {
                    for (int i = 0; i < _jumps.Length; i++)
                    {
                        if (_jumps[i] == 0)
                        {
                            _jumps[i] = result;
                            return;
                        }
                    }
                }
                
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 1, j = 2; i < array.Length;)
                {
                    if (i == 0 || array[i].BestJump <= array[i - 1].BestJump)
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
                Console.WriteLine($" {Name} {Surname} {BestJump}");
            }

        }
    }

}
