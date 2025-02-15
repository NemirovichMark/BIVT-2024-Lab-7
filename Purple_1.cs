using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        {
            private string _name, _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _jumpIndex;
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4];
                for (int i = 0; i<4; i++) _coefs[i] = 2.5;
                _marks = new int[4,7];
                _jumpIndex = 0;
            }

            public string Name { get { return _name; } }
            public string Surname => _surname;
            public double[] Coefs { 
                get
                {
                    if (_coefs == null) return null;
                    return (double[])_coefs.Clone();
                } 
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    return (int[,])_marks.Clone();
                }
            }
            public double TotalScore
            {
                get
                {
                    if (_marks == null) return 0;
                    int mn = 1000000, mx = -100000000;
                    double totalsum = 0;
                    for (int jump = 0; jump<4; jump++)
                    {
                        int sum = 0;
                        for (int i = 0; i<7; i++) {
                            mn = Math.Min(mn, _marks[jump,i]);
                            mx = Math.Max(mx, _marks[jump,i]);
                            sum += _marks[jump, i];
                        }
                        sum -= mx; sum -= mn;
                        totalsum += (double)sum * _coefs[jump];
                    }

                    return totalsum;
                }
            }

            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || coefs.Length != 4 || _coefs == null)
                {
                    return;
                }
                for (int i = 0; i < 4; i++) if (coefs[i] > 3.5 || coefs[i] < 2.5) return;
                for (int i = 0; i<4; i++)
                {
                    _coefs[i] = coefs[i];
                }
            }
            public void Jump(int[] marks)
            {
                if (_marks == null) return; 
                if (_jumpIndex >= 4)
                {
                    return;
                }
                if (marks == null || marks.Length != 7)
                {
                    return;
                }
                for (int i = 0; i<7; i++) if (marks[i] > 6 || marks[i] < 0) return;
                for (int i = 0; i<7; i++)
                {
                    _marks[_jumpIndex, i] = marks[i];
                }
                _jumpIndex++;
            }

        }
        public static void Sort(Participant[] array)
        {
            if (array == null)
            {
                return;
            }
            Array.Sort(array, (x,y) => y.TotalScore.CompareTo(x.TotalScore));
        }

    }
}
