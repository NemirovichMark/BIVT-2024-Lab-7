using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;

            private int _curMark;

            public string Name => _name;
            public string Surname => _surname;

            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;

                    var copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int[] Places
            {
                get
                {
                    if (_places == null) return null;

                    var copy = new int[_places.Length];
                    Array.Copy(_places, copy, _places.Length);
                    return copy;
                }
            }

            public int Score => _places == null ? 0 : _places.Sum();

            public Participant(string name, string surname)
            {
                _name = name != null ? name : "-";
                _surname = surname != null ? surname : "-";
                _marks = new double[7];
                _places = new int[7];
                _curMark = 0;
            }

            public void Evaluate(double result)
            {
                if (_curMark >= 7 || result == null || _marks == null) return;

                _marks[_curMark++] = result;
            }

            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;

                var sortedParticipants = participants.Where(x => x._marks != null && x._places != null).ToArray();
                int n = sortedParticipants.Length;
                for (int judge = 0; judge < 7; judge++)
                {
                    SortParticipantsByJudge(sortedParticipants, judge);

                    for (int i = 0; i < n; i++)
                    {
                        sortedParticipants[i]._places[judge] = i + 1;
                    }
                }

                sortedParticipants = sortedParticipants
                    .Concat(participants.Where(x => x._marks == null || x._places == null)).ToArray();
                Array.Copy(sortedParticipants, participants, sortedParticipants.Length);
            }

            private static void SortParticipantsByJudge(Participant[] sortedParticipants, int judge)
            {
                int n = sortedParticipants.Length, i = 1, j = 2;
                while (i < n)
                {
                    if (i == 0 || sortedParticipants[i - 1]._marks[judge] >= sortedParticipants[i]._marks[judge])
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        (sortedParticipants[i - 1], sortedParticipants[i]) =
                            (sortedParticipants[i], sortedParticipants[i - 1]);
                        i--;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                var sortedArray = array.Where(x => x._marks != null && x._places != null).ToArray();
                int n = sortedArray.Length, i = 1, j = 2;
                while (i < n)
                {
                    if (i == 0 || sortedArray[i - 1].Score < sortedArray[i].Score)
                    {
                        i = j;
                        j++;
                    }
                    else if (sortedArray[i - 1].Score == sortedArray[i].Score &&
                             sortedArray[i - 1]._places.Min() <= sortedArray[i]._places.Min() &&
                             sortedArray[i - 1]._marks.Sum() >= sortedArray[i]._marks.Sum())
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        (sortedArray[i - 1], sortedArray[i]) = (sortedArray[i], sortedArray[i - 1]);
                        i--;
                    }
                }

                sortedArray = sortedArray.Concat(array.Where(x => x._marks == null || x._places == null)).ToArray();
                Array.Copy(sortedArray, array, sortedArray.Length);
            }

            public void Print()
            {
                if (_marks == null || _places == null) return;

                Console.WriteLine($"Имя: {_name}");
                Console.WriteLine($"Фамилия: {_surname}");

                Console.Write("Оценки:\t");
                foreach (var mark in _marks)
                {
                    Console.Write($"{mark}\t");
                }

                Console.WriteLine();

                Console.Write("Места:\t");
                foreach (var place in _places)
                {
                    Console.Write($"{place}\t");
                }

                Console.WriteLine();

                Console.WriteLine($"Лучшее место: {_places.Min()}");
                Console.WriteLine($"Сумма оценок: {Math.Round(_marks.Sum(), 2)}");
                Console.WriteLine($"Результат: {Score}");
                Console.WriteLine();
            }
        }
    }
}