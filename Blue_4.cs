using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_4;
using static System.Formats.Asn1.AsnWriter;

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
                    if (_scores == null) { return null; }
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
                if (_scores == null) { return; }
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
            }

            public void Print() {
                Console.Write($"{_name} ");
                if (_scores == null)
                {
                    Console.Write("0");
                }
                else {
                    //foreach (int score in _scores) {
                    //    Console.Write($"{score} ");
                    //}
                    Console.Write($"{TotalScore} ");
                }
                Console.WriteLine();
            }
        }

        public struct Group {
            private string _name;
            private Team[] _teams;

            private int _teams_added;

            public string Name => _name;
            public Team[] Teams => _teams;

            public Group(string name) {
                _name = name;
                _teams = new Team[12];
                _teams_added = 0;
            }

            public void Add(Team team_to_add) {
                if (_teams_added >= 12)
                {
                    //Console.WriteLine("В группе уже есть 12 команд");
                    return;
                }
                else {
                    if (_teams == null) return;
                    _teams[_teams_added++] = team_to_add;
                    //Array.Resize(ref _teams, _teams.Length + 1);
                    //_teams[_teams.Length - 1] = team_to_add;
                }
            }

            public void Add(Team[] teams_to_add)
            {
                if (_teams_added >= 12)
                {
                    // Console.WriteLine("В группе уже есть 12 команд.");
                    return;
                }
                else {
                    if (_teams == null || teams_to_add == null) return;
                    for (int i = 0; i < teams_to_add.Length; i++) {
                        if (_teams_added >= 12) { break; }
                        _teams[_teams_added++] = teams_to_add[i];
                    }
                }
            }

            public void Sort() {
                if (_teams == null) return;
                Team[] sorted_teams = null;
                sorted_teams = _teams.OrderByDescending(t => t.TotalScore).ToArray();
                _teams = sorted_teams;
            }

            public static Group Merge(Group group1, Group group2, int size) {
                Group group = new Group("Финалисты");
                int i = 0, j = 0, k = 0;
                while (i < group1.Teams.Length && j < group2.Teams.Length)
                {
                    if (k == size) return group;
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
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
                    if (k == size) return group;
                    group.Add(group1.Teams[i++]);
                }
                while (j < group2.Teams.Length)
                {
                    if (k == size) return group;
                    group.Add(group2.Teams[j++]);
                }

                return group;
            }

            public void Print()
            {
                Console.WriteLine($"{_name} ");
                foreach (Team team in _teams)
                {
                    team.Print();
                }
                Console.WriteLine();
            }
        }
    }
}
