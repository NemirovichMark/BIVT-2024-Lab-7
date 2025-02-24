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
            private string _name, _surname;
            private int _distance;
            private int[] _marks;
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
            }
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public double Distance { get { return _distance; } }
            public int[] Marks { 
                get {
                    if (_marks == null) return null;
                    return (int[])_marks.Clone(); 
                } 
            }
            public int Result
            {
                get
                {
                    if (_marks == null) return 0;
                    int mn = 1000000, mx = -100000000;
                    int sum = 0;
                    for (int jump = 0; jump < 5; jump++)
                    {
                        mn = Math.Min(mn, _marks[jump]);
                        mx = Math.Max(mx, _marks[jump]);
                        sum += _marks[jump];
                    }
                    sum -= mx; sum -= mn;

                    sum += 60 + (_distance - 120) * 2;

                    return Math.Max(sum, 0);
                }
            }
            public void Jump(int distance, int[] marks)
            {
                if (_marks == null || marks == null || marks.Length != 5) return;
                _distance = distance;
                for (int i = 0; i<5; i++)
                {
                    _marks[i] = marks[i];
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                Array.Sort(array, (x, y) => y.Result.CompareTo(x.Result));
            }
            public void Print()
            {
                if (_surname == "" || _name == "") return;
                Console.WriteLine("{0} {1} {2}", _name, _surname, this.Result);
            }
        }
    }
}
