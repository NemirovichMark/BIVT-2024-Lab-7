using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_3
    {
        public struct Participant
        {
            //Переменные
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int count = 0;

            //Свойства
            public string Name {
                get
                {
                    return _name;
                }
            }
            public string Surname
            {
                get
                {
                    return _surname;
                }
            }
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    double[] copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, copy.Length);
                    return copy;
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null) return null;
                    int[] copy = new int [_places.Length];
                    Array.Copy(_places, copy, copy.Length);
                    return copy;
                }
            }

            public int Score
            {
                get
                {
                    if (_places == null) return 0;
                    int sc = 0;
                    for (int i = 0; i < _places.Length; i++)
                    {
                        sc += _places[i];
                    }
                    return sc;
                }
            }
            
            private double TotalMark
            {
                get
                {
                    if (_marks == null) return 0;
                    double marks = 0;
                    foreach (double mark in _marks)
                    {
                        marks += mark;
                    }
                    return Math.Round(marks, 2);
                }
            }

            private int TopPlace
            {
                get
                {
                    if (_places == null) return 0;
                    int top = int.MaxValue;
                    foreach (int i in _places)
                    {
                        if (i < top) top = i;
                    }
                    return top;
                }
            }
            //Конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
            }

            //Добавление новой оценки
            public void Evaluate(double result)
            {
                if (_marks == null) return;
                if (count <= 6)
                {
                    _marks[count++] = result;
                }
                else
                {
                    return;
                }
            }

            //Определение мест у судьей
            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;
                //Идем по судьям
                for (int i = 0; i < 7; i++)
                {
                    //Сортируем участников в зависимости от оценок. Итог - массив от самой высокой до самой низкой оценки
                    for (int b = 0; b < participants.Length - 1; b++)
                    {
                        for (int c = 0; c < participants.Length - 1 - b; c++)
                        {
                            if (participants[c]._marks == null || participants[c + 1]._marks == null || participants[c]._places == null || participants[c+1]._places == null) continue;
                            if (participants[c]._marks[i] < participants[c + 1]._marks[i])
                            {
                                (participants[c], participants[c + 1]) = (participants[c + 1], participants[c]);
                            }
                        }
                    }
                    //Теперь мы идем по участникам (отсортированным) и ставим их места у судьи i
                    for (int person = 0; person < participants.Length; person++)
                    {
                        if (participants[person]._places == null || participants[person]._marks == null) continue;
                        participants[person]._places[i] = person + 1;
                    }
                }
            }


            //Условие для сортировки немного не понял, надеюсь, что правильно
            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                //Сначала люди, которые выше всех, далее ниже
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j + 1]._places == null || array[j]._places == null || array[j + 1]._marks == null || array[j]._marks == null) continue;
                        //Если набрал меньше "хороших мест" идет вниз
                        if (array[j].Score > array[j + 1].Score)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                        //Если одинаковая сумма мест
                        else if (array[j].Score == array[j + 1].Score)
                        {
                            bool flag = false;
                            int count_for_1 = 0;
                            int count_for_2 = 0;
                            //Сравниваем всех судей. Считаем у кого более лучших мест больше
                            for (int judge = 0; judge < 7; judge++)
                            {
                                if (array[j + 1]._places[judge] < array[j]._places[judge])
                                {
                                    count_for_2++;
                                    //У второго место более "лучше"
                                }
                                else if(array[j + 1]._places[judge] > array[j]._places[judge])
                                {
                                    count_for_1++;
                                    //У первого место более "лучше"
                                }
                            }
                            //Если у первого человека все места лучше чем у второго - ничего не делаем
                            if (count_for_1 > count_for_2 && count_for_2 == 0)
                            {
                                flag = true;
                            }
                            //Если у второго человека все места лучше чем у второго - меняем местами
                            else if (count_for_2 > count_for_1 && count_for_1 == 0)
                            {
                                flag = true;
                                (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            }
                            //Если не такой случай - идем дальше
                            if (flag == false)
                            {
                                //Считаем сумму очков у первого и второго
                                double sum1 = 0;
                                double sum2 = 0;
                                for (int mark = 0; mark < 7; mark++)
                                {
                                    sum1 += array[j]._marks[mark];
                                    sum2 += array[j + 1]._marks[mark];
                                }
                                //Если у первого очков меньше - меняем местами (он в более проигрышной позиции)
                                if (sum1 < sum2)
                                {
                                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                                }
                            }
                            
                        }
                    }
                }
            }
            public void Print()
            {
                Console.Write(Name + "      ");
                Console.Write(Surname + "        ");
                Console.Write(Score + "       ");
                Console.Write(TopPlace + "       ");
                Console.WriteLine(TotalMark + "       ");
            }
        }
    }
}
