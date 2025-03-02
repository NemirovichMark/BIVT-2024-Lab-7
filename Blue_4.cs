using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string name;
            private int[] scores;

            public string Name => name;
            public int[] Scores
            {
                get
                {
                    if (scores == null) return null;
                    int[] copy = new int[scores.Length];
                    Array.Copy(scores, copy, copy.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (scores == null) return 0;

                    int total = 0;
                    for (int i = 0; i < scores.Length; i++)
                    {
                        total += scores[i];
                    }

                    return total;
                }
            }

            public Team(string name)
            {
                this.name = name;
                this.scores = new int[0];
            }
            public void Print()
            {
            }
            public void PlayMatch(int result)
            {
                if (scores == null) return;

                int[] newScores = new int[scores.Length + 1];

                for (int i = 0; i < scores.Length; i++)
                {
                    newScores[i] = scores[i];
                }
                newScores[newScores.Length - 1] = result;
                scores = newScores;
            }
        }

        public struct Group
        {
            private string name;
            private Team[] teams;
            public string Name => name;
            public Team[] Teams => teams;
           

            public Group(string name)
            {
                this.name = name;
                this.teams = new Team[12];
            }

            public void Add(Team team)
            {
                if (teams == null) return;

                for (int i = 0; i < teams.Length; i++)
                {
                    if (teams[i].Name == null)
                    {
                        teams[i] = team;
                        break;
                    }
                }
            }

            public void Add(params Team[] newTeams)
            {
                if (teams == null) return;

                foreach (var team in newTeams)
                {
                    Add(team);
                }
            }

            public void Sort()
            {
                if (teams == null) return;
                Array.Sort(teams, (x, y) => y.TotalScore.CompareTo(x.TotalScore));
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group finalists = new Group("Финалисты");

                var allTeams = group1.Teams.Concat(group2.Teams)
                                           .OrderByDescending(t => t.TotalScore)
                                           .Take(size);

                foreach (var team in allTeams)
                {
                    finalists.Add(team);
                }

                return finalists;
            }


            public void Print() { }

        }
    }
}
