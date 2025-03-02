using System;


namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string _name;
            private int[] _score;

            public string Name=>_name;
            public int[] Scores
            {
                get
                {
                    if(_score==null) return default(int[]);
                    int[] res = new int[_score.Length];
                    for(int i =0; i < _score.Length; i++) res[i] = _score[i];
                    return res;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_score == null) return 0;
                    int sum = 0;
                    for(int i = 0; i < _score.Length; i++) sum += _score[i];
                    return sum;
                }
            }

            public Team(string name)
            {
                _name = name;
                _score = new int[0];
            }

            public void PlayMatch(int result)
            {
                if(_score == null) return;
                int[] newmas = new int[_score.Length+1];
                for(int i = 0;i < newmas.Length; i++)
                {
                    if(i==_score.Length)
                        newmas[i] = result;
                    else
                        newmas[i] = _score[i];

                }
                _score = newmas;
            }
            public void Print()
            {
                Console.WriteLine("{0,-20}", Name);
            }

        }


        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int _index;
            public string Name => _name;
            public Team[] Teams => _teams;
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _index = 0;
            }

            public void Add(Team team)
            {
                if (_teams == null) return;
                if (_index < 12)
                {
                    _teams[_index++] = team;
                }
            }
            public void Add(Team[] teams)
            {
                if (_teams == null || teams==null) return;
                
                for (int i = 0; i < 12; i++) { 
                   Add(teams[i]);
                }
               
            }
            public void Sort() {

                if (_teams == null) return;
                for (int i = 0; i < _teams.Length - 1; i++)
                {
                    for (int j = 0; j < _teams.Length - i - 1; j++)
                    {
                        if (_teams[j + 1].TotalScore > _teams[j].TotalScore)
                        {
                            (_teams[j + 1], _teams[j]) = (_teams[j], _teams[j + 1]);
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                if (group1.Teams == null || group2.Teams == null) return default(Group);
                if (size <= 0) return default(Group);
                Group group = new Group("Финалисты");
                group1.Sort();
                group2.Sort();
                int index1 = 0, index2 = 0;

                while (index1 < size/2 && index2< size/2)
                {
                    if (group1.Teams[index1].TotalScore >= group2.Teams[index2].TotalScore)
                    {
                        group.Add(group1.Teams[index1]);
                        index1++;
                    }
                    else
                    {
                        group.Add(group2.Teams[index2]);
                        index2++;
                    }
                    
                }

                while (index1<size/2)
                {
                    group.Add(group1.Teams[index1]);
                    index1++;
                    
                }

                while (index2<size/2)
                {
                    group.Add(group2.Teams[index2]);
                    index2++;
                    
                }

                return group;
            }

            public void Print()
            {
                Console.WriteLine("{0,-20}", Name);
            }
        }
    }
}
