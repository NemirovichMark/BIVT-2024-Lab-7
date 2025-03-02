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
            // поля
            private string _name;
            private string _surname;
            private int[] _penaltytimes;

            // свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                 {
                    if (_penaltytimes == null) return null;
                    int[] copyArr = new int[_penaltytimes.Length];
                    Array.Copy(_penaltytimes, copyArr, _penaltytimes.Length);
                    return copyArr;
                }
            }

            public int TotalTime
            {
                get
                {
                    if (_penaltytimes == null) return 0;
                    int total = 0;                   
                    for (int i = 0; i < _penaltytimes.Length; i++)
                    {
                        total += _penaltytimes[i];
                    }
                    return total;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (_penaltytimes == null || _penaltytimes.Length == 0) 
                    {
                        return false;
                    }
                    for (int i = 0; i < _penaltytimes.Length; i++)
                    {
                        if (_penaltytimes[i] == 10) 
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            // конструктор
            public Participant(string name, string surname)
            {                
                _name = name;
                _surname = surname;
                _penaltytimes = new int[0];
            }

            // методы
            public void PlayMatch(int time)
            {
                if (_penaltytimes == null) { return; }
                Array.Resize(ref _penaltytimes, _penaltytimes.Length + 1); //(ссылка, новый размер)
                _penaltytimes[_penaltytimes.Length - 1] = time; 
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) { return; }
                
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
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
                Console.WriteLine($"Участник: {Name} {Surname}");
                Console.Write("Штрафное время: ");
                for (int i = 0; i < _penaltytimes.Length; i++)
                {
                    Console.Write($"{_penaltytimes[i]} мин "); 
                }
                Console.WriteLine($"\nСуммарное штрафное время: {TotalTime} мин");
                Console.WriteLine();
            }
        }
    }
}
