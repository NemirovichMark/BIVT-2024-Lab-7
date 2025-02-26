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

            public void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(name);

                Console.Write("Surname: ");
                Console.WriteLine(surname);

                Console.Write("Marks: ");
                if (marks == null)
                {
                    return;
                }
                for (int i = 0; i < marks.GetLength(0); i++)
                {
                    for (int j = 0; j < marks.GetLength(1); j++)
                    {
                        Console.Write(marks[i, j]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }

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
                    int[,] copy = new int[marks.GetLength(0), marks.GetLength(1)];
                    Array.Copy(marks, copy, marks.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int total = 0;
                    if (marks == null)
                    {
                        return 0;
                    }
                    for (int i = 0; i < marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < marks.GetLength(1); j++)
                        {
                            total += marks[i, j];
                        }
                    }
                    return total;
                }
            }

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.marks = new int[2, 5];
                for (int i = 0; i < marks.GetLength(0); i++)
                {
                    for (int j = 0; j < marks.GetLength(1); j++)
                    {
                        marks[i, j] = -1;
                    }
                }
               }

            public void Jump(int[] result)
            {
                if (marks == null)
                {
                    return;
                }

                for (int i = 0; i < marks.GetLength(0); i++)
                {
                    if (marks[i, 0] != -1)
                    {
                        continue;
                    }


                    for (int j = 0; j < marks.GetLength(1); j++)
                    {
                        marks[i, j] = result[j];
                    }
                    break;
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
                    bool swapped = false;
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore > array[j + 1].TotalScore)
                        {
                            Student temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }

               
            }
        }
    }
}
