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
            //поля
            private string name;
            private string surname;
            private int[,] marks; // Матрица оценок судей (2 прыжка, 5 судей)

            //свойства 
            public string Name => name;
            public string Surname => surname;
            public int[,] Marks
            {
                get
                {
                    if(marks == null) return null;
                    int[,] copyArray = new int[marks.GetLength(0), marks.GetLength(1)];
                    Array.Copy(marks, copyArray, marks.Length);
                    return copyArray;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (marks == null) return 0; // Проверка на инициализацию

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
                if (result == null || result.Length == 0)
                {
                    return;
                }

                //количество оценок для записи (максимум 5)
                int scoresToTake = 0;
                if (result.Length < 5)
                {
                    scoresToTake = result.Length; 
                }
                else
                {
                    scoresToTake = 5; 
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
                        for (int j = 0; j < scoresToTake; j++)
                        {
                            marks[i, j] = result[j];
                        }
                        return;
                    }
                }

                return;
            }


            public static void Sort(Participant[] array)
            {
                if (array == null) return;
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
