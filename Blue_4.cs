using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Blue_4
    { public struct Team
    {
        // поля
        private string name;
        private int[] scores; 

        //свойства
        public string Name => name;
        public int[] Scores => scores;

        public int TotalScore
        {
            get
            {
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

        // свойства
        public string Name => name;
        public Team[] Teams => teams;

        // Конструктор
        public Group(string name)
        {
            this.name = name;
            this.teams = new Team[0]; 
        }

        // Методы
        public void Add(Team team)
        {
            if (teams.Length < 12) 
            {
                Array.Resize(ref teams, teams.Length + 1);
                teams[teams.Length - 1] = team;
            }
            else
            {
                Console.WriteLine("Группа уже содержит 12 команд. Добавление невозможно.");
            }
        }

        public void Add(params Team[] newTeams)
        {
            foreach (var team in newTeams)
            {
                if (teams.Length < 12)
                {
                    Array.Resize(ref teams, teams.Length + 1);
                    teams[teams.Length - 1] = team;
                }
                else
                {
                    Console.WriteLine("Группа уже содержит 12 команд. Добавление невозможно.");
                    break;
                }
            }
        }

        public void Sort()
        {
            for (int i = 0; i < teams.Length - 1; i++)
            {
                for (int j = i + 1; j < teams.Length; j++)
                {
                    if (teams[i].TotalScore < teams[j].TotalScore)
                    {
                        Team temp = teams[i];
                        teams[i] = teams[j];
                        teams[j] = temp;
                    }
                }
            }
        }

        public static Group Merge(Group group1, Group group2, int size)
        {
            Group finalists = new Group("Финалисты");

            foreach (var team in group1.Teams)
            {
                if (finalists.Teams.Length < size)
                {
                    finalists.Add(team);
                }
                else
                {
                    break;
                }
            }

            foreach (var team in group2.Teams)
            {
                if (finalists.Teams.Length < size)
                {
                    finalists.Add(team);
                }
                else
                {
                    break;
                }
            }

            return finalists;
        }

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
