using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            //поля
            private string name;
            private string surname;
            private int[] penaltyTimes;

            //свойства
            public string Name => name;
            public string Surname => surname;
            public int[] PenaltyTimes => penaltyTimes;

            public int TotalTime
            {
                
                get
                {
                    if (penaltyTimes == null) return 0; // Проверка на инициализацию
                    int total = 0;
                    foreach (int time in penaltyTimes)
                    {
                        total += time;
                    }
                    return total;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (penaltyTimes == null) return false; // Проверка на инициализацию
                    foreach (int time in penaltyTimes)
                    {
                        if (time == 10) // Если игрок получил 10 минут штрафа
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            // Конструктор
            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.penaltyTimes = new int[0]; 
            }

            // Методы
            public void PlayMatch(int time)
            {
                if (penaltyTimes == null) return; // Проверка на инициализацию
                Array.Resize(ref penaltyTimes, penaltyTimes.Length + 1);
                penaltyTimes[penaltyTimes.Length - 1] = time;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return; // Проверка на инициализацию
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i].TotalTime > array[j].TotalTime)
                        {
                            Participant temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.Write($"{Name} {Surname} ");
                foreach (int time in penaltyTimes)
                {
                    Console.Write($"{time} ");
                }
                Console.WriteLine();
                if (IsExpelled)
                {
                    Console.WriteLine("Исключен из списка кандидатов.");
                }
                Console.WriteLine();
            }
        }

    }
}
