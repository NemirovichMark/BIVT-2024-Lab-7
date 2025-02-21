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
                    var copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int[] Places
            {
                get
                {
                    var copy = new int[_places.Length];
                    Array.Copy(_places, copy, _places.Length);
                    return copy;
                }
            }

            public int Score => _places.Sum();

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
                if (_curMark >= 7 || result == null) return;

                _marks[_curMark++] = result;
            }

            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;

                int n = participants.Length;
                for (int judge = 0; judge < 7; judge++)
                {
                    int i = 1, j = 2;
                    while (i < n)
                    {
                        if (i == 0 || participants[i - 1]._marks[judge] > participants[i]._marks[judge])
                        {
                            i = j;
                            j++;
                        }
                        else
                        {
                            (participants[i - 1], participants[i]) = (participants[i], participants[i - 1]);
                            i--;
                        }
                    }

                    for (i = 0; i < n; i++)
                    {
                        participants[i]._places[judge] = i + 1;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                int n = array.Length, i = 1, j = 2;
                while (i < n)
                {
                    if (i == 0 || array[i - 1].Score < array[i].Score)
                    {
                        i = j;
                        j++;
                    }
                    else if (array[i - 1].Score == array[i].Score)
                    {
                        bool flag = true;
                        for (int judge = 0; judge < 7; judge++)
                        {
                            if (array[i - 1]._places[judge] > array[i]._places[judge]) flag = false;
                        }

                        if (flag && array[i - 1]._marks.Sum() > array[i]._marks.Sum())
                        {
                            i = j;
                            j++;
                        }
                        else
                        {
                            (array[i - 1], array[i]) = (array[i], array[i - 1]);
                            i--;
                        }
                    }
                    else
                    {
                        (array[i - 1], array[i]) = (array[i], array[i - 1]);
                        i--;
                    }
                }
            }

            public void Print()
            {
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