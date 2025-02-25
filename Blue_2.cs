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
                var indexedArray = array.Select((x, index) => new { Value = x, Index = index }).ToArray();

                Array.Sort(indexedArray, (x, y) => {
                    int result = y.Value.TotalScore.CompareTo(x.Value.TotalScore);
                    return result != 0 ? result : x.Index.CompareTo(y.Index);
                });

                var sortedArray = indexedArray.Select(x => x.Value).ToArray();
                array = sortedArray;
            }
        }
    }
}
