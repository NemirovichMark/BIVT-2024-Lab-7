using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{

    public class Blue_4
    {
        public struct Team
        {
            private string name;
            private int[] scores;

            public void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(name);


                for (int j = 0; j < scores.Length; j++)
                {
                    Console.Write(scores[j]);
                    Console.Write(" ");
                }
            }
            public string Name
            {
                get
                {
                    if (name == null)
                        return null;
                    return name;
                }
            }

            public int[] Scores
            {
                get
                {
                    if (scores == null)
                        return new int[0];
                    return scores;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (scores == null)
                        return 0;

                    int total = 0;
                    foreach (int score in scores)
                    {
                        total += score;
                    }
                    return total;
                }
            }

            public Team(string name)
            {
                this.name = name;
                this.scores = new int[30];
            }

            public void PlayMatch(int result)
            {
                if (scores == null)
                    return;

                for (int i = 0; i < scores.Length; i++)
                {
                    if (scores[i] == 0)
                    {
                        scores[i] = result;
                        break;
                    }
                }
            }
        }

        public struct Group
        {
            private string name;
            private Team[] teams;

            public void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(name);


                for (int j = 0; j < teams.Length; j++)
                {
                    teams[j].Print();
                    
                }
            }

            public string Name
            {
                get
                {
                    if (name == null)
                        return "";
                    return name;
                }
            }

            public Team[] Teams
            {
                get
                {
                    if (teams == null)
                        return new Team[0];
                    return teams;
                }
            }

            public Group(string name)
            {
                this.name = name;
                this.teams = new Team[12];
            }

            public void Add(Team team)
            {
                if (teams == null)
                    return;

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
                if (teams == null)
                    return;

                foreach (var team in newTeams)
                {
                    Add(team);
                }
            }

            public void Sort()
            {
                if (teams == null)
                    return;

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
        }

    }
}
