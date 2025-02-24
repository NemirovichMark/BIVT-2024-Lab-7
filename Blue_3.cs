using System;
using System.Linq;

namespace Lab_6;

public class Blue_3
{
    public struct Participant {
        // приватные поля
        private string _name;
        private string _surname;
        private int[] _penaltyTimes;
        private int _matchesThisPlayer;
        private bool _isExpelled;


        // публичные свойства
        public string Name => _name;
        public string Surname => _surname;
        public int[] PenaltyTimes => _penaltyTimes;

        public int TotalTime {
            get {
                int result = 0;
                if (_penaltyTimes == null) return 0;
                foreach (var item in _penaltyTimes) {
                    result += item;
                }
                return result;
            }
        }

        public bool IsExpelled => _isExpelled;

        // конструктор
        public Participant(string name, string surname) {
            _name = name;
            _surname = surname;
            _penaltyTimes = new int[1];
            _matchesThisPlayer = 0;
            _isExpelled = true;
        }

        // методы
        public void PlayMatch(int time) {
            if (time == 10) _isExpelled = false;
            if (_matchesThisPlayer < _penaltyTimes.Length) {
                _penaltyTimes[_matchesThisPlayer] = time;
                _matchesThisPlayer++;
            } else {
                Array.Resize(ref _penaltyTimes, _matchesThisPlayer + 1);
                _penaltyTimes[_matchesThisPlayer] = time;
                _matchesThisPlayer++;
            }
        }

        public static void Sort(Participant[] array) {
            if (array == null) return;
            for (int i = 0; i < array.Length-1; i++) {
                for (int j = 0; j < array.Length-i-1; j++) {
                    if (array[j].TotalTime > array[j + 1].TotalTime) {
                        Participant tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                }
            }
        }

        public void Print() {
            if (!_isExpelled) {
                Console.WriteLine($"{_name} {_surname}, Штрафное время: {TotalTime} мин");
            }
        }


    }
}