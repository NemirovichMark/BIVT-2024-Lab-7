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
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Surname: {_surname}");
                Console.WriteLine($"Time: {_time}\n");
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
                    Sportsman[] sportsmen = new Sportsman[_sportsmen.Length];
                    Array.Copy(_sportsmen, sportsmen, _sportsmen.Length);
                    return sportsmen;
                }
            }

            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }
            
            public Group(Group group)
            {
                if (group._sportsmen == null) return;

                _name = group.Name;
                _sportsmen = new Sportsman[group.Sportsmen.Length];
                Array.Copy(group.Sportsmen, _sportsmen, group.Sportsmen.Length);
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
                Add(group.Sportsmen);
            }

            public void Sort()
            {
                if (_sportsmen == null) return;
                Array.Copy(_sportsmen.OrderBy(s => s.Time).ToArray(), _sportsmen, _sportsmen.Length);
            }

            public static Group Merge(Group x, Group y)
            {
                Group group = new Group("Финалисты");
                if (x._sportsmen == null && y._sportsmen == null) return group;
                if (x._sportsmen == null) {
                    Array.Copy(y._sportsmen, group._sportsmen, y._sportsmen.Length);
                    return group;
                }
                if (y._sportsmen == null) {
                    Array.Copy(x._sportsmen, group._sportsmen, x._sportsmen.Length);
                    return group;
                }

                Array.Resize(ref group._sportsmen, x._sportsmen.Length + y._sportsmen.Length);
                int i = 0, j = 0, k = 0;
                while (i != x._sportsmen.Length && j != y._sportsmen.Length) {
                    if (x._sportsmen[i].Time <= y._sportsmen[j].Time) group._sportsmen[k++] = x._sportsmen[i++];
                    else group._sportsmen[k++] = y._sportsmen[j++];
                }

                while (i < x._sportsmen.Length) group._sportsmen[k++] = x._sportsmen[i++];
                while (j < y._sportsmen.Length) group._sportsmen[k++] = y._sportsmen[j++];

                return group;
            }

            public void Print()
            {
                if (_sportsmen == null) return;

                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Sportsmen:\n");
                foreach (Sportsman sportsman in _sportsmen) sportsman.Print();
                Console.WriteLine();
            }

            // public static void PrintTable(Group group)
            // {
            //     Console.WriteLine("Name\tSurname\tTime");
            //     foreach (Sportsman sportsman in group.Sportsmen) Console.WriteLine($"{sportsman.Name}\t{sportsman.Surname}\t{sportsman.Time}");
            // }
        }
    }
}