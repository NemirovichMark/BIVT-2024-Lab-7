using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_6;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {

            private string _name;
            private string _surname;
            private int[,] _marks;


            public string Name => _name;
            public string Surname => _surname;

            public int[,] Marks
            {
                get
                {
                    if (_marks == null)
                    {
                        return null;
                    }

                    int[,] copy = new int[2, 5];
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            copy[i, j] = _marks[i, j];
                        }
                    }
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_marks == null)
                    {
                        return 0;
                    }

                    int sum = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            sum += _marks[i, j];
                        }
                    }
                    return sum;
                }
            }


            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
            }


            public void Jump(int[] result)
            {
                if (result == null || result.Length < 5)
                {
                    return;
                }

                int jumpIndex = 0;
                if (_marks[0, 0] != 0)
                {
                    jumpIndex = 1;
                }

                for (int i = 0; i < 5; i++)
                {
                    _marks[jumpIndex, i] = result[i];
                }
            }


            public static void Sort(Participant[] array)
            {
                if (array == null)
                {
                    return;
                }

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }



            public void Print()
            {
                Console.WriteLine($"Участник: {_name} {_surname}");
                Console.WriteLine("Оценки за прыжки:");

                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    Console.Write($"Прыжок {i + 1}: ");
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        Console.Write($"{_marks[i, j]} ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine($"Общий балл: {TotalScore}");
            }

        }
    }
}