using System;
using System.Linq;
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

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name, string surname)
            {
                _name = name != null ? name : "-";
                _surname = surname != null ? surname : "-";
                _time = 0;
            }

            public void Run(double time)
            {
                if (time == null || time < 0 || _time != 0) return;

                _time = time;
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {_name}");
                Console.WriteLine($"Имя: {_surname}");
                Console.WriteLine($"Время: {_time}");
                Console.WriteLine();
            }
        }

        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;

            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null) return null;

                    var copy = new Sportsman[_sportsmen.Length];
                    Array.Copy(_sportsmen, copy, _sportsmen.Length);
                    return copy;
                }
            }

            public Group(string name)
            {
                _name = name != null ? name : "-";
                _sportsmen = new Sportsman[0];
            }

            public Group(Group group)
            {
                if (group._sportsmen != null || _sportsmen == null) return;
                
                _name = group._name;
                Array.Copy(group._sportsmen, _sportsmen, group._sportsmen.Length);
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null) return;

                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null || _sportsmen == null) return;

                int n = _sportsmen.Length;
                
                Array.Resize(ref _sportsmen, n + sportsmen.Length);
                Array.Copy(sportsmen, 0, _sportsmen, n, sportsmen.Length);
            }

            public void Add(Group group)
            {
                if (_sportsmen == null) return;
                Add(group._sportsmen);
            }

            public void Sort()
            {
                if (_sportsmen == null) return;

                int n = _sportsmen.Length, i = 1, j = 2;
                while (i < n)
                {
                    if (i == 0 || _sportsmen[i - 1].Time <= _sportsmen[i].Time)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        (_sportsmen[i - 1], _sportsmen[i]) = (_sportsmen[i], _sportsmen[i - 1]);
                        i--;
                    }
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                var group = new Group("Финалисты");
                if (group1._sportsmen == null && group1._sportsmen == null) return group;

                if (group1._sportsmen == null)
                {
                    Array.Copy(group2._sportsmen, group._sportsmen, group2._sportsmen.Length);
                    return group;
                }

                if (group2._sportsmen == null)
                {
                    Array.Copy(group1._sportsmen, group._sportsmen, group1._sportsmen.Length);
                    return group;
                }

                Array.Resize(ref group._sportsmen, group1._sportsmen.Length + group2._sportsmen.Length);
                int i = 0, j = 0, k = 0;
                while (i != group1._sportsmen.Length && j != group2._sportsmen.Length)
                {
                    if (group1._sportsmen[i].Time < group2._sportsmen[j].Time)
                    {
                        group._sportsmen[k++] = group1._sportsmen[i++];
                    }
                    else
                    {
                        group._sportsmen[k++] = group2._sportsmen[j++];
                    }
                }

                while (i < group1._sportsmen.Length)
                {
                    group._sportsmen[k++] = group1._sportsmen[i++];
                }

                while (j < group2._sportsmen.Length)
                {
                    group._sportsmen[k++] = group2._sportsmen[j++];
                }

                return group;
            }

            public void Print()
            {
                if (_sportsmen == null) return;

                Console.WriteLine($"Имя: {_name}");
                Console.WriteLine($"Спортсмены:");
                Console.WriteLine();

                foreach (var sportsman in _sportsmen)
                {
                    sportsman.Print();
                }

                Console.WriteLine();
            }
        }
    }
}