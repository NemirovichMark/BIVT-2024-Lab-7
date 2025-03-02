using System;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            private string name;
            private string surname;
            private int[,] marks;
            private int ind;

            public string Name => this.name;
            public string Surname => this.surname;

            public int[,] Marks
            {
                get
                {
                    if (this.marks == null || this.marks.GetLength(0) == 0 || this.marks.GetLength(1) == 0)
                    {
                        return null;
                    }
                    int[,] copy = new int[this.marks.GetLength(0), this.marks.GetLength(1)];
                    for (int i = 0; i < this.marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.marks.GetLength(1); j++)
                        {
                            copy[i, j] = this.marks[i, j];
                        }
                    }
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (this.marks == null || this.marks.GetLength(0) == 0 || this.marks.GetLength(1) == 0)
                    {
                        return 0;
                    }

                    int sum = 0;
                    for (int i = 0; i < this.marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.marks.GetLength(1); j++)
                        {
                            sum += this.marks[i, j];
                        }
                    }
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.marks = new int[2, 5];
                this.ind = 0;
            }

            public void Jump(int[] result)
            {
                if (this.marks == null || this.marks.GetLength(0) == 0 || this.marks.GetLength(1) == 0 || result == null || result.Length == 0 || this.ind > 1)
                {
                    return;
                }

                if (this.ind == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        this.marks[0, i] = result[i];
                    }
                    this.ind++;
                }
                else if (this.ind == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        this.marks[1, i] = result[i];
                    }
                    this.ind++;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0)
                {
                    return;
                }

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j + 1].TotalScore > array[j].TotalScore)
                        {
                            (array[j + 1], array[j]) = (array[j], array[j + 1]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine(this.name);
                Console.WriteLine(this.surname);

                if (this.marks != null)
                {
                    for (int i = 0; i < this.marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.marks.GetLength(1); j++)
                        {
                            Console.Write(this.marks[i, j]);
                        }
                        Console.WriteLine();
                    }
                }

                Console.WriteLine(this.TotalScore);
            }
        }
    }
}