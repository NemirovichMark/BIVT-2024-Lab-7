using System;
using System.Linq;

namespace Lab_6;

public class Blue_4
{
    public struct Team {
        // поля
        private string _name;
        private int[] _scores;


        // свойства
        public string Name => _name;
        public int[] Scores {
            get {
                if (_scores == null) return new int[0];
                return _scores.ToArray();
            }
        }
        public int TotalScore {
            get {
                int result = 0;
                if (_scores == null) return 0;
                foreach (var item in _scores) {
                    result += item;
                }
                return result;
            }
        }

        // конструктор
        public Team(string name) {
            _name = name;
            _scores = new int[0];
        }
        // методы
        public void PlayMatch(int result) {
            if (_scores == null) _scores = new int[0];
            Array.Resize(ref _scores, _scores.Length + 1);
            _scores[_scores.Length - 1] = result;
        }

        public void Print()
        {
            Console.WriteLine($"Команда: {_name}, Сумма очков: {TotalScore}");
        }
    }

    public struct Group {
        // поля 
        private string _name;
        private Team[] _teams;
        private int _countOfTeams;

        // свойства
        public string Name => _name;
        public Team[] Teams => _teams;

        // конструктор
        public Group(string name)
        {
            _name = name;
            _teams = new Team[12];
            _countOfTeams = 0;
        }

        // методы
        public void Add(Team team) {
            if (_countOfTeams < 12) {
                _teams[_countOfTeams] = team;
                _countOfTeams++;
            }
        }

        public void Add(Team[] newTeams) {
            foreach (var team in newTeams) {
                if (_countOfTeams < 12) {
                    _teams[_countOfTeams++] = team;
                }
            }
        }
        public void Sort() {
            for (int i = 0; i < _countOfTeams - 1; i++) {
                for (int j = 0; j < _countOfTeams - i - 1; j++) {
                    if (_teams[j].TotalScore < _teams[j + 1].TotalScore) {
                        Team tmp = _teams[j];
                        _teams[j] = _teams[j + 1];
                        _teams[j + 1] = tmp;
                    }
                }
            }
        }
        public static Group Merge(Group group1, Group group2, int size) {
            if (size <= 0) return default(Group);
            Group result = new Group("Финалисты");
            int firstIndex = 0;
            int secondIndex = 0;
            while (firstIndex < size / 2 && secondIndex < size / 2) {
                if (group1.Teams[firstIndex].TotalScore >= group2.Teams[secondIndex].TotalScore) {
                    result.Add(group1.Teams[firstIndex]);
                    firstIndex++;
                } else {
                    result.Add(group2.Teams[secondIndex]);
                    secondIndex++;
                }
            }

            while (firstIndex < size / 2) {
                result.Add(group1.Teams[firstIndex++]);
            }

            while (secondIndex < size / 2) {
                result.Add(group2.Teams[secondIndex++]);
            }

            return result;
        }
        public void Print() {
            Console.WriteLine($"Группа: {_name}");
            foreach (var team in _teams) {
                if (team.Name != null) team.Print();
            }
        }


    }
}