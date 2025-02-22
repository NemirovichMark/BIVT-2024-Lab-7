using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
    public class Purple_4 {
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
            public void Print() {
                Console.WriteLine($"Name: {_name ?? "N/A"}");
                Console.WriteLine($"Surname: {_surname ?? "N/A"}");
                Console.WriteLine($"Time: {_time}");
            }
        }

        public struct Group {
            private string _name;
            private Sportsman[] _sportsmen;
            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen; 

            public Group(string name) {
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public Group(Group group) {
                if (group.Sportsmen == null || _sportsmen == null) 
                    return;

                _name = group.Name;
                Array.Copy(group.Sportsmen, _sportsmen, group.Sportsmen.Length);
            }

            public void Add(Sportsman sportsman) {
                if (_sportsmen == null) return;

                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen) {
                if (sportsmen == null || _sportsmen == null) return;

                int n = _sportsmen.Length;

                Array.Resize(ref _sportsmen, n + sportsmen.Length);
                Array.Copy(sportsmen, 0, _sportsmen, n, sportsmen.Length);
            }

            public void Add(Group group) {
                Add(group.Sportsmen);
            }
            
            public void Sort() {
                if (_sportsmen == null) return;
                
                var sortedSportsmen = _sportsmen.OrderBy(x => x.Time).ToArray(); // stable sort
                Array.Copy(sortedSportsmen, _sportsmen, _sportsmen.Length);
            }

            public static Group Merge(Group group1, Group group2) {
                if (group1.Sportsmen == null && group2.Sportsmen == null) 
                    return new Group("Финалисты");

                if (group1.Sportsmen == null) return group2;
                if (group2.Sportsmen == null) return group1;
                
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

            private void PrintArray(Sportsman[] array, string label) {
                if (array == null) {
                    Console.WriteLine($"{label} N/A");
                    return;
                }

                Console.WriteLine(label);
                for (int i = 0; i < array.Length; i++) {
                    Console.WriteLine($"{i + 1} sportsman:");
                    array[i].Print();
                    Console.WriteLine();
                }
            }

            public void Print() {
                Console.WriteLine($"Name: {_name ?? "N/A"}");
                PrintArray(_sportsmen, "Sportsmen:");
            }
        }
    }
}