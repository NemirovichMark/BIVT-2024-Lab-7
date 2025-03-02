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
            private string name;
            private string surname;
            private int[,] marks;

            public string Name
            {
                get
                {
                    if (name == null)
                        return null;
                    return name;
                }
            }

            public string Surname
            {
                get
                {
                    if (surname == null)
                        return null;
                    return surname;
                }
            }

            public int[,] Marks
            {
                get
                {
                    if (marks == null)
                    {
                        return null;
                    }
                    int[,] marksCopy = new int[marks.GetLength(0), marks.GetLength(1)];
                    Array.Copy(marks, marksCopy, marks.Length);
                    return marksCopy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    if (marks == null || marks.GetLength(0) == 0 || marks.GetLength(1) == 0)
                    {
                        return 0;
                    }

                    // Исправление: перебор массива marks с учетом реальных размеров
                    for (int i = 0; i < marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < marks.GetLength(1); j++)
                        {
                            sum += marks[i, j];
                        }
                    }
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.marks = new int[2, 5];  // 2 строки, 5 столбцов
            }

            public void Jump(int[] result)
            {
                if (marks == null || result.Length != marks.GetLength(1))
                {
                    return;
                }

                int jump = -1; // Изначально jump равен -1
                for (int i = 0; i < marks.GetLength(0); i++)
                {
                    // Проверка на пустые значения в marks для выявления первого ненулевого значения
                    if (marks[i, 0] != 0)
                    {
                        jump = 0;
                        break;
                    }
                }

                if (jump == -1)
                {
                    for (int i = 0; i < marks.GetLength(0); i++)
                    {
                        // Проверка второго столбца для замены
                        if (marks[i, 1] != 0)
                        {
                            jump = 1;
                            break;
                        }
                    }
                }

                // Если нашли подходящий столбец (jump = 0 или 1) и результат имеет нужную длину
                if (jump != -1 && result.Length == marks.GetLength(1))
                {
                    for (int i = 0; i < marks.GetLength(0); i++)
                    {
                        marks[i, jump] = result[i];  // Заполнение marks на найденной позиции
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (x, y) => y.TotalScore.CompareTo(x.TotalScore));
            }

            public void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(name);

                Console.Write("Surname: ");
                Console.WriteLine(surname);

                Console.Write("Marks: ");

                int rows = marks.GetLength(0);
                int columns = marks.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write(marks[i, j]);
                        if (j < columns - 1)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
