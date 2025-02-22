using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                    if (_marks == null) return null;
                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
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
                    if (_marks == null) return 0; 

                    int sum = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
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
                if (result == null || result.Length != 5)
                {
                    Console.WriteLine("Массив оценок должен содержать 5 элементов.");
                    return;
                }

                for (int i = 0; i < 2; i++)
                {
                    if (_marks[i, 0] == 0) 
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            _marks[i, j] = result[j]; 
                        }
                        return;
                    }
                }
                Console.WriteLine("Все прыжки уже заполнены.");
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
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

                if (_marks != null)
                {
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        Console.Write($"Прыжок {i + 1}: ");
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            Console.Write($"{_marks[i, j]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Оценки отсутствуют.");
                }

                Console.WriteLine($"Общий балл: {TotalScore}");
            }
        }
    }
}
