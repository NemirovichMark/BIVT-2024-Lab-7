using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;

            public int[] Marks
            {
                get
                {
                    var copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int Result { get; private set; }

            public Participant(string name, string surname)
            {
                _name = name != null ? name : "-";
                _surname = surname != null ? surname : "-";
                _distance = 0;
                _marks = new int[5];
            }

            public void Jump(int distance, int[] marks)
            {
                if (distance == null || marks == null || marks.Length != 5) return;

                _distance = distance;
                Array.Copy(marks, _marks, marks.Length);

                int distancePoints = 60 + (_distance - 120) * 2;
                if (distancePoints < 0) distancePoints = 0;
                Result += marks.Sum() - marks.Max() - marks.Min() + distancePoints;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                int n = array.Length, i = 1, j = 2;
                while (i < n)
                {
                    if (i == 0 || array[i - 1].Result > array[i].Result)
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
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {_name}");
                Console.WriteLine($"Фамилия: {_surname}");
                Console.WriteLine($"Расстояние: {_distance}");

                Console.Write($"Оценки:\t");
                foreach (var mark in _marks)
                {
                    Console.Write($"{mark}\t");
                }

                Console.WriteLine();

                Console.WriteLine($"Результат: {Result}");
                Console.WriteLine();
            }
        }
    }
}