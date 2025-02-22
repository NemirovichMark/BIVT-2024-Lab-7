using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
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
                _time = 0;
            }

            public void Run(double time)
            {
                if (_time != 0) return;
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

            public Group(string name)
            { 
                _name = name;
                _sportsmen = new Sportsman[0];
                
            }

            public Group(Group group)
            {

                _name = group.Name;
                if (group.Sportsmen is null)
                {
                    _sportsmen = null;
                    return;
                }
                _sportsmen = new Sportsman[group.Sportsmen.Length];
                Array.Copy(group.Sportsmen, _sportsmen, _sportsmen.Length);
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmen is null)
                    return;
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (_sportsmen is null || sportsmen is null)
                    return;
                int iter = _sportsmen.Length;
                Array.Resize(ref _sportsmen, _sportsmen.Length + sportsmen.Length);
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    _sportsmen[iter++] = sportsmen[i];
                }
            }

            public void Add(Group group)
            {
                if (_sportsmen is null || group.Sportsmen is null)
                    return;
                int iter = group.Sportsmen.Length;
                Array.Resize(ref _sportsmen, _sportsmen.Length + group.Sportsmen.Length);
                for (int i = 0; i < group.Sportsmen.Length; i++)
                {
                    _sportsmen[iter++] = group.Sportsmen[i];
                }
            }


            public void Sort()
            {
                if (_sportsmen is null)
                    return;
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
                if (group1.Sportsmen is null || group2.Sportsmen is null)
                    return new Group("Финалисты");

                Sportsman[] sportsmen = new Sportsman[group1.Sportsmen.Length + group2.Sportsmen.Length];
                int l = 0, r = 0;

                Group final = new Group("Финалисты");

                while (l < group1.Sportsmen.Length && r < group2.Sportsmen.Length)
                {
                    //group1.Sportsmen[l].Print();
                    //group2.Sportsmen[r].Print();
                    if (group1.Sportsmen[l].Time < group2.Sportsmen[r].Time)
                    {
                        final.Add(group1.Sportsmen[l++]);
                    }
                    else
                    {
                        final.Add(group2.Sportsmen[r++]);
                    }
                    
                }

                while (l < group1.Sportsmen.Length)
                {
                    final.Add(group1.Sportsmen[l++]);
                }

                while (r < group2.Sportsmen.Length)
                {
                    final.Add(group2.Sportsmen[r++]);
                }

                //for (int i = 0; i < sportsmen.Length; i++)
                //{
                //    sportsmen[i].Print();
                //}

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
