using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6{
    public class Purple_4{
        public struct Sportsman{
            private string _name;
            private string _surname;
            private double _time;

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name, string surname){
                _name = name;
                _surname = surname;
                _time = 0;
            }

            public void Run(double time){
                if (_time != 0) return;
                _time = time;
            }
        }
    
        public struct Group{
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;

            public Group(string name){
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public Group(Group otherGroup){
                _name = otherGroup.Name;
                _sportsmen = new Sportsman[otherGroup.Sportsmen.Length];
                Array.Copy(otherGroup.Sportsmen, _sportsmen, otherGroup.Sportsmen.Length);
            }

            public void Add(Sportsman sportsman){
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length-1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen){
                Array.Resize(ref _sportsmen, _sportsmen.Length + sportsmen.Length);
                for (int i = 0; i < sportsmen.Length; i++){
                    _sportsmen[_sportsmen.Length+i] = sportsmen[i];
                }
            }

            public void Add(Group group){
                for (int i = 0; i < group.Sportsmen.Length; i++){
                    Add(group.Sportsmen[i]);
                }
            }

            public void Sort(){
                for (int i = 1; i < Sportsmen.Length; i++){
                    int k = i, j = k - 1;
                    while (j >= 0){
                        if (Sportsmen[j].Time > Sportsmen[k].Time){
                            Sportsman tmp = Sportsmen[j];
                            Sportsmen[j] = Sportsmen[k];
                            Sportsmen[k] = tmp;
                        }
                        k = j;
                        j--;
                    }
                }
            }

            public static Group Merge(Group group1, Group group2){
                Group newGroup = new Group("Финалисты");
                newGroup.Add(group1);
                newGroup.Add(group2);
                newGroup.Sort();
                return newGroup;
            }
        }
    }
}