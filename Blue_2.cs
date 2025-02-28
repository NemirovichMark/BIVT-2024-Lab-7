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
            // поля
            private string _name;
            private string _surname;
            private int[,] _marks;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) { return null; }
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
            public int TotalScore //если есть только геттер, то свойство только для чтения
            {
                get //возвращает вычисленное значение
                {
                    if (_marks == null) return 0;
                    int total = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            total += _marks[i, j];
                        }
                    }
                    return total;
                }
            }

            //конструктор
            public Participant(string name, string surname)
            {                
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
            }

            //методы
            public void Jump(int[] result)
            {
                if (result == null || result.Length != 5) { return; }

                for (int i = 0; i < 2; i++)
                {
                    bool isJumpEmpty = true;
                    for (int j = 0; j < 5; j++)
                    {
                        if (_marks[i, j] != 0)
                        {
                            isJumpEmpty = false;
                            break;
                        }
                    }

                    if (isJumpEmpty)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            _marks[i, j] = result[j];
                        }
                        return;
                    }
                }
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) { return; }
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            Participant temp = array[j]; //тип temp должен совпадать с типом элементов массива array
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Участник: {Name} {Surname}");
                Console.WriteLine("Оценки судей:");
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
                Console.WriteLine();
            }
        }
    }
}    
