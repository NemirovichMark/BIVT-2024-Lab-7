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
                    return marks;
                }
            }

            public int TotalScore
            {
                get
                {
                    int total = 0;
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
            }

            public void Jump(int[] result)
            {
                if (marks == null)
                {
                    return;
                }

                for (int i = 0; i < marks.GetLength(0); i++)
                {
                    if (marks[i, 0] != 0)
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
                Array.Sort(array, (x, y) => y.TotalScore.CompareTo(x.TotalScore));
            }
        }
    }
}
