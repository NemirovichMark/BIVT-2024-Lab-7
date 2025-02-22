using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Blue_2
    {
        public struct Participant
        {
            //поля
            private string name;
            private string surname;
            private int[,] marks; // Матрица оценок судей (2 прыжка, 5 судей)

            //свойства 
            public string Name => name;
            public string Surname => surname;
            public int[,] Marks => marks;

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

            // Конструктор
            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.marks = new int[2, 5]; 
            }

            // Методы
            public void Jump(int[] result)
            {
                if (result.Length != 5)
                {
                    throw new ArgumentException("Массив оценок должен содержать 5 элементов.");
                }

                for (int i = 0; i < marks.GetLength(0); i++)
                {
                    bool isEmpty = true;
                    for (int j = 0; j < marks.GetLength(1); j++)
                    {
                        if (marks[i, j] != 0)
                        {
                            isEmpty = false;
                            break;
                        }
                    }

                    if (isEmpty)
                    {
                        for (int j = 0; j < marks.GetLength(1); j++)
                        {
                            marks[i, j] = result[j];
                        }
                        return; 
                    }
                }

            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i].TotalScore < array[j].TotalScore)
                        {
                            // Меняем местами участников
                            Participant temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {TotalScore}");
                
            }
        }
    }
}
