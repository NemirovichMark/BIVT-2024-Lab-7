using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BIVT_2024_Lab_6
{
    public class Purple_4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;
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

            public double Time
            {
                get
                {
                    return _time;
                }
            }

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = -1;
            }

            public void Run(double time)
            {
                if (_time != -1) return;
                _time = time;
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {_time}");
            }
        }
        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;
            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen is null) return null;

                    Sportsman[] sportsmenCopy = new Sportsman[_sportsmen.Length];
                    Array.Copy(_sportsmen, sportsmenCopy, sportsmenCopy.Length);
                    return sportsmenCopy;
                }
            }

            public Group(string name, Sportsman[] sportsmen)
            {
                _name = name;
                _sportsmen = new Sportsman[sportsmen.Length];
                Array.Copy(sportsmen, _sportsmen, _sportsmen.Length);
                
            }

            public Group(Group group)
            {
                _name = group.Name;
                _sportsmen = new Sportsman[group.Sportsmen.Length];
                Array.Copy(_sportsmen, group.Sportsmen, _sportsmen.Length);
            }

            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen)
            {
                int iter = _sportsmen.Length;
                Array.Resize(ref _sportsmen, _sportsmen.Length + sportsmen.Length);
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    _sportsmen[iter++] = sportsmen[i];
                }
            }

            public void Add(Group group)
            {
                int iter = group.Sportsmen.Length;
                Array.Resize(ref _sportsmen, _sportsmen.Length + group.Sportsmen.Length);
                for (int i = 0; i < group.Sportsmen.Length; i++)
                {
                    _sportsmen[iter++] = group.Sportsmen[i];
                }
            }


            public void Sort()
            {
                int n = _sportsmen.Length;
                for (int i = 1, j = 2; i < n;)
                {
                    if (i == 0 || _sportsmen[i].Time > _sportsmen[i - 1].Time)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        Sportsman temp = _sportsmen[i];
                        _sportsmen[i] = _sportsmen[i - 1];
                        _sportsmen[i - 1] = temp;
                        i--;
                    }
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                Sportsman[] sportsmen = new Sportsman[group1.Sportsmen.Length + group2.Sportsmen.Length];
                int l = 0, r = 0, k = 0;
                while (l < group1.Sportsmen.Length && r < group2.Sportsmen.Length)
                {
                    //group1.Sportsmen[l].Print();
                    //group2.Sportsmen[r].Print();
                    if (group1.Sportsmen[l].Time < group2.Sportsmen[r].Time)
                    {
                        sportsmen[k++] = group1.Sportsmen[l++];
                    }
                    else
                    {
                        sportsmen[k++] = group2.Sportsmen[r++];
                    }
                    
                }

                while (l < group1.Sportsmen.Length)
                {
                    sportsmen[k++] = group1.Sportsmen[l++];
                }

                while (r < group2.Sportsmen.Length)
                {
                    sportsmen[k++] = group2.Sportsmen[r++];
                }

                //for (int i = 0; i < sportsmen.Length; i++)
                //{
                //    sportsmen[i].Print();
                //}

                Group final = new Group("Финалисты", sportsmen);

                return final;
            }

            public void Print()
            {
                Console.WriteLine(_name);
                if (_sportsmen is null)
                    return;
                for (int i = 0; i < _sportsmen.Length; i++)
                    _sportsmen[i].Print();  
            }
        }
        
    }
}
