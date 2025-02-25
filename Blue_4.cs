using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_4;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team { 
            private string _name;
            private int[] _scores;

            public string Name => _name;
            public int[] Scores {
                get
                {
                    if (_scores == null) { return new int[0]; }
                    int[] newArr = new int[_scores.Length];
                    Array.Copy(_scores, newArr, _scores.Length);
                    return newArr;
                }
            }

            public int TotalScore {
                get {
                    if (_scores == null) { return 0; }
                    int s = 0;
                    foreach (int i in _scores) { 
                        s += i;
                    }
                    return s;
                }
            }

            public Team(string name) {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result) { 
                //if (_scores == null) { return; }
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
            }

            public void Print() {
                Console.Write($"{_name} ");
                if (_scores == null)
                {
                    Console.WriteLine("0");
                }
                else {
                    foreach (int score in _scores) {
                        Console.Write($"{score} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public struct Group {
            private string _name;
            private Team[] _teams;

            public string Name => _name;
            public Team[] Teams {
                get {
                    if (_teams == null) { return new Team[0]; }
                    else {
                        Team[] newArr = new Team[_teams.Length];
                        Array.Copy(_teams, newArr, _teams.Length);
                        return newArr;
                    }
                }
            }

            public Group(string name) {
                _name = name;
                Team[] _teams = new Team[0];
            }

            public void Add(Team team_to_add) {
                if (_teams.Length >= 12)
                {
                    Console.WriteLine("В группе уже есть 12 команд");
                }
                else {
                    Array.Resize(ref _teams, _teams.Length + 1);
                    _teams[_teams.Length - 1] = team_to_add;
                }
            }

            public void Add(Team[] teams_to_add)
            {
                if (_teams.Length >= 12)
                {
                    Console.WriteLine("В группе уже есть 12 команд.");
                }
                else if (_teams.Length + teams_to_add.Length > 12)
                {
                    Console.WriteLine("Добавьте в группу меньше команд.");
                }
                else {
                    int old_len = _teams.Length;
                    Array.Resize(ref _teams, _teams.Length + teams_to_add.Length);
                    for (int i = 0; i < _teams.Length; i++) {
                        _teams[old_len + i] = teams_to_add[i];
                    }
                }
            }

            public void Sort() {
                for (int i = 0; i < _teams.Length; i++) {
                    for (int j = i; j < _teams.Length; j++) {
                        if (_teams[i].TotalScore < _teams[j].TotalScore) { 
                            Team tmp = _teams[i];
                            _teams[i] = _teams[j];
                            _teams[j] = tmp;
                        }
                    }
                }
            }

            //private static bool CheckSort(Group group1, Group group2) {
            //    for (int i = 0; i < group1.Teams.Length - 1; i++) {
            //        if (group1.Teams[i + 1].TotalScore < group1.Teams[i].TotalScore) { 
            //            return false;
            //        }
            //    }
            //    return true;
            //}

            private static Group Merge(Group group1, Group group2, int size) {
                Group group = new Group("Финалисты");
                int i = 0, j = 0, k = 0;
                while (i < group1.Teams.Length && j < group2.Teams.Length)
                {
                    if (group1.Teams[i].TotalScore < group2.Teams[j].TotalScore)
                    {
                        group.Add(group1.Teams[i++]);
                    }
                    else
                    {
                        group.Add(group2.Teams[j++]);
                    }
                }

                while (i < group1.Teams.Length)
                {
                    group.Add(group1.Teams[i++]);
                }
                while (j < group2.Teams.Length)
                {
                    group.Add(group2.Teams[j++]);
                }

                return group;
            }

            public void Print()
            {
                Console.Write($"{_name} ");
                foreach (Team team in _teams)
                {
                    team.Print();
                }
                Console.WriteLine();
            }
        }
    }
}
