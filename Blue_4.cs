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
            //поля
            private string _name;
            private int[] _scores;

            //свойства
            public string Name => _name;
            public int[] Scores => _scores;
           
            public int TotalScore
            {
                get
                {
                    if (_scores == null || _scores.Length == 0)
                    {
                        return 0;
                    }
                    int total = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        total += _scores[i];
                    }
                    return total;
                }               
            }

            //конструктор
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            //метод
            public void PlayMatch(int result)
            {
                if (_scores == null) 
                {
                    _scores = new int[0];
                }
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
            }
            
            public void Print()
            {
                Console.WriteLine($"Команда: {Name}, Очки: {string.Join(", ", Scores)}, Всего очков: {TotalScore}");
            }

        }

        public struct Group
        {
            private string _name;        //название группы
            private Team[] _teams;       //массив команд (где каждый элемент является объектом типа Team!)

            public string Name => _name;
            public Team[] Teams => _teams;            
            
            public Group(string name)
            {
                _name = name;
                _teams = new Team[0];
            }

            public void Add(ref Team team)
            {
                if (_teams.Length < 12) 
                {
                    Array.Resize(ref _teams, _teams.Length + 1);
                    _teams[_teams.Length - 1] = team;
                }
                else
                {
                    Console.WriteLine("12 команд набрано.");
                }
            }
            public void Add(params Team[] teams)
            {
                for (int i = 0; i < teams.Length; i++)
                {
                    if (_teams.Length < 12)
                    {
                        Add(ref teams[i]); // Передача элемента массива по ссылке
                    }
                    else
                    {
                        Console.WriteLine("12 команд набрано.");
                        break;
                    }
                }
            }
            public void Sort()
            {
                for (int i = 0; i < _teams.Length - 1; i++)
                {
                    for (int j = 0; j < _teams.Length - 1 - i; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {                            
                            Team temp = _teams[j];
                            _teams[j] = _teams[j + 1];
                            _teams[j + 1] = temp;
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group finalists = new Group("Финалисты");

                int index1 = 0;
                int index2 = 0;

                // Объединяем команды до достижения максимального размера
                while (index1 < group1._teams.Length && index2 < group2._teams.Length && finalists._teams.Length < size)
                {
                    if (group1._teams[index1].TotalScore >= group2._teams[index2].TotalScore)
                    {
                        finalists.Add(ref group1._teams[index1]);
                        index1++;
                    }
                    else
                    {
                        finalists.Add(ref group2._teams[index2]);
                        index2++;
                    }
                }

                // Если остались команды в первой группе
                while (index1 < group1._teams.Length && finalists._teams.Length < size)
                {
                    finalists.Add(ref group1._teams[index1]);
                    index1++;
                }

                // Если остались команды во второй группе
                while (index2 < group2._teams.Length && finalists._teams.Length < size)
                {
                    finalists.Add(ref group2._teams[index2]);
                    index2++;
                }

                return finalists;
            }
            public void Print()
            {
                Console.WriteLine($"Группа: {_name}");
                Console.WriteLine("Команды:");
                foreach (var team in _teams)
                {
                    team.Print();
                }
            }

        }
    }
  
    
}
