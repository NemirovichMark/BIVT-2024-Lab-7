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
            // поля
            private string name;
            private int[] scores; 

            //свойства
            public string Name => name;
            public int[] Scores 
            { 
                get
                {
                    if (scores == null) return null;
                    int[] copyArray = new int[scores.Length];
                    Array.Copy(scores, copyArray, scores.Length);
                    return copyArray;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (scores == null) return 0; // Проверка на инициализацию
                    int total = 0;
                    foreach (int score in scores)
                    {
                        total += score;
                    }
                    return total;
                }
            }

            // Конструктор
            public Team(string name)
            {
                this.name = name;
                this.scores = new int[0]; 
            }

            // Методы
            public void PlayMatch(int result)
            {
                if(scores == null) return; // Проверка на инициализацию
                Array.Resize(ref scores, scores.Length + 1);
                scores[scores.Length - 1] = result;
            }
            public void Print()
            {
                Console.Write($"{Name} ");
                foreach (int score in scores)
                {
                    Console.Write($"{score} ");
                }
                Console.WriteLine();
            }
        }

        public struct Group
        {
            // поля
            private string name;
            private Team[] teams;
            private int index;

            // свойства
            public string Name => name;
            public Team[] Teams => teams;

            // Конструктор
            public Group(string name)
            {
                this.name = name;
                this.teams = new Team[12]; 
                this.index = 0;
            }

            // Методы
            public void Add(Team team)
            {
                if (teams == null) return; // Проверка на инициализацию
                if (index < teams.Length) 
                {
                    teams[index] = team;
                    index++;
                }
            }

            public void Add(params Team[] newTeams)
            {
                if (teams == null) return; // Проверка на инициализацию
                foreach (var team in newTeams)
                {
                    Add(team);
                }
            }

            public void Sort()
            {
                if (teams == null) return ; // Проверка на инициализацию
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length-1-i; j++)
                    {
                        if (teams[j].TotalScore < teams[j+1].TotalScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j+1];
                            teams[j+1] = temp;
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group finalists = new Group("Финалисты");

                Team[] allTeams = new Team[group1.Teams.Length + group2.Teams.Length];
                int index = 0;

                for (int i = 0; i < group1.Teams.Length; i++)
                {
                    allTeams[index] = group1.Teams[i];
                    index++;
                }

                for (int i = 0; i < group2.Teams.Length; i++)
                {
                    allTeams[index] = group2.Teams[i];
                    index++;
                }

                for (int i = 0; i < allTeams.Length - 1; i++)
                {
                    for (int j = 0; j < allTeams.Length - 1 - i; j++)
                    {
                        if (allTeams[j].TotalScore < allTeams[j + 1].TotalScore)
                        {
                            Team temp = allTeams[j];
                            allTeams[j] = allTeams[j + 1];
                            allTeams[j + 1] = temp;
                        }
                    }
                }

                for (int i = 0; i < size && i < allTeams.Length; i++)
                {
                    finalists.Add(allTeams[i]);
                }

                return finalists;
            }

            // Метод
            public void Print()
            {
                Console.Write($"{Name}");
                foreach (var team in teams)
                {
                    team.Print();
                }
                Console.WriteLine();
            }
        }
    }
}
