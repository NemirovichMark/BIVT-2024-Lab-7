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
        public Blue_4()
        {
        }
    }

    public class Team
    {
        private string name;
        private int[] scores;

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
                return scores.Length == 0 ? null : scores;
            }
        }

        public int TotalScore
        {
            get
            {
                if (scores == null || scores.Length == 0)
                    return 0;
                int sum = 0;
                foreach (int v in scores)
                {
                    sum += v;
                }
                return sum;
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

            for (int i = 0; i < scores.Length; i++)
            {
                Console.Write(scores[i]);
                Console.Write(" ");
            }
        }
    }

    public struct Group
    {
        private string name;
        private Team[] teams;

        public string Name
        {
            get
            {
                if (name == null)
                    return string.Empty;
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
            this.teams = new Team[0];
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

            for (int i = 0; i < newTeams.Length; i++)
            {
                Add(newTeams[i]);
            }
        }

        public void Sort()
        {
            if (teams == null)
                return;

            int n = teams.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (teams[j].TotalScore < teams[j + 1].TotalScore)
                    {
                        Team temp = teams[j];
                        teams[j] = teams[j + 1];
                        teams[j + 1] = temp;
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
            Console.WriteLine($"Группа: {name}");
            foreach (var team in teams)
            {
                team.Print();
            }
        }
    }
}
