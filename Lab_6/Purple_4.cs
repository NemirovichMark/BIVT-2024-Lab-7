using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
    class Purple_4 {
        public struct Sportsman {
            private string _name;
            private string _surname;
            private double _time;

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name, string surname) {
                _name = name;
                _surname = surname;
            }

            public void Run(double time) {
                if (_time == 0) _time = time;
            }
        }

        public struct Group {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen => (Sportsman[])_sportsmen.Clone(); // shallow copy for safety

            public Group(string name) {
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public Group(Group group) {
                _name = group.Name;
                Array.Copy(group.Sportsmen, _sportsmen, group.Sportsmen.Length);
            }

            public void Add(Sportsman sportsman) {
                int n = _sportsmen.Length;
                var newSportsmen = new Sportsman[n + 1];

                Array.Copy(_sportsmen, newSportsmen, n);

                newSportsmen[n] = sportsman;

                _sportsmen = newSportsmen;
            }

            public void Add(Sportsman[] sportsmen) {
                if (sportsmen == null) return;

                int n = _sportsmen.Length;
                var newSportsmen = new Sportsman[n + sportsmen.Length];

                Array.Copy(_sportsmen, newSportsmen, n);
                Array.Copy(sportsmen, 0, newSportsmen, n, sportsmen.Length);

                _sportsmen = newSportsmen;
            }

            public void Add(Group group) {
                Add(group.Sportsmen);
            }

            public void Sort() {
                _sportsmen = _sportsmen.OrderBy(x => x.Time).ToArray(); // stable sort
            }

            public static Group Merge(Group group1, Group group2) {
                group1.Sort();
                group2.Sort();

                int n = group1.Sportsmen.Length;
                int m = group2.Sportsmen.Length;

                var mergedSportsmen = new Sportsman[n + m];

                int i = 0, j = 0, k = 0;

                while (i < n && j < m) {
                    if (group1.Sportsmen[i].Time <= group2.Sportsmen[j].Time)
                        mergedSportsmen[k++] = group1.Sportsmen[i++];
                    else 
                        mergedSportsmen[k++] = group2.Sportsmen[j++];
                }

                while (i < n)
                    mergedSportsmen[k++] = group1.Sportsmen[i++];
                
                while (j < m)
                    mergedSportsmen[k++] = group2.Sportsmen[j++];

                var MergedGroup = new Group("Финалисты");
                MergedGroup.Add(mergedSportsmen);

                return MergedGroup;
            }
        }
    }
}