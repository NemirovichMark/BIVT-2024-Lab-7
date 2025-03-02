using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_6;

namespace ЛР_6
{
    public class Blue_2
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private int[,] _marks;
            


            //свойства// get читать set изменять
            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks => _marks;
            

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            sum += _marks[i, j];
                        }
                    }
                    return sum;
                }
            }


            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
            }


            public void Jump(int[] result)
            {
                if (result.Length != 5 || result == null)
                {
                    return;
                }

                for (int i = 0; i < result.Length; i++)
                {
                    if (i < 5)
                    {
                        _marks[1, i] = result[i];
                    }
                    else
                    {
                        _marks[2, i] = result[i];
                    }
                    
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
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
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
                Console.WriteLine($"{_name} {_surname} {TotalScore}");
            }
        }
    }
}

//Cat.GetNameLength(c) --> static
//c.Rename --> void