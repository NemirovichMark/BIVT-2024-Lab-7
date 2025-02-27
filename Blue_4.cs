using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public struct Team
    {
        private string name;
        private int[] scores;

        public string Name => name;

        public int[] Scores => scores.Length == 0 ? null : scores;

        public int TotalScore
        {
            get
            {
                if (scores == null || scores.Length == 0)
                    return 0;
                return scores.Sum();
            }
        }

        public Team(string name)
        {
            this.name = name;
            this.scores = new int[0]; 
        }

        public void PlayMatch(int result)
        {
            Array.Resize(ref scores, scores.Length + 1);
            scores[scores.Length - 1] = result;
        }

        public void Print()
        {
            Console.Write("Name: ");
            Console.WriteLine(name);
            Console.WriteLine(string.Join(" ", scores));
        }
    }

    public struct Group
    {
        private string name;
        private Team[] teams;

        public string Name => name;

        public Team[] Teams => teams.Length == 0 ? null : teams;

        public Group(string name, int size)
        {
            this.name = name;
            this.teams = new Team[size]; 
        }

        public void Add(Team team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].Name == null)
                {
                    teams[i] = team;
                    break;
                }
            }
        }

        public void Print()
        {
            Console.WriteLine($"Группа: {name}");
            foreach (var team in teams)
            {
                if (team.Name != null) 
                {
                    team.Print();
                }
            }
        }
    }
}
