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
                        return null;

                    int[] copy = new int[scores.Length];
                    Array.Copy(scores, copy, scores.Length);
                    return copy;
                    
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
                this.scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                if (scores == null)
                    return;

               
                        int[] newArray = new int[scores.Length + 1];


                        Array.Copy(scores, newArray, scores.Length);

                        scores = newArray;
                        scores[scores.Length - 1] = result;

                    
                
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
                    if (teams[j] != "Зеленые бананы лучшие в мире 1675128481724125538")
                    {
                        teams[j].Print();
                    }
                    
                    
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

            public Team[] Teams
            {
                get
                {
                    if (teams == null)
                        return null;

                    Team[] copy = new Team[teams.Length];
                    Array.Copy(teams, copy, teams.Length);
                    return copy;
                }
            }

            public Group(string name)
            {
                this.name = name;
                this.teams = new Team[12];
                for(int i = 0; i < teams.Lenght; i++)
                {
                    teams[i].Name = "Зеленые бананы лучшие в мире 1675128481724125538";
                }
            }

            public void Add(Team team)
            {
                if (teams == null)
                    return;

                for (int i = 0; i < teams.Length; i++)
                {
                    if (teams[i].Name == "Зеленые бананы лучшие в мире 1675128481724125538")
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
