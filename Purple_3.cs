using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_3
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;

            private int _markID;
            private int _placesSum;

            //свойства 
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public double[] Marks
            {
                get 
                {
                    if (_marks == null) return null;
                    double[] copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public double[] Places
            {
                get
                {
                    if (_places == null) return null;
                    double[] copy = new double[_places.Length];
                    Array.Copy(_places, copy, _places.Length);
                    return copy;
                }
            }

            public int Score { get { return _placesSum; } }
     

            //конструктор 
            public Participant(string name,string surname)
            {
                _name = name;
                _surname = surname;

                _marks = new double[7];
                _places = new int[7];

                _markID = 0;
                _placesSum = 0;
            }

            //методы
            public void Evaluate(double result)
            {
                if (_marks == null || _markID==7) return;
                _marks[_markID] = result;
                _markID++;
            }
            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null) return;

                for (int i = 0; i < 7; i++) //интерация по судьям
                {
                    //скопировать оценки одного i-того судьи для всех участников
                    double[] marks_per_judge= new double[participants.Length];
                    int count = 0;
                    for (int j = 0; j < participants.Length; j++)
                    {
                        marks_per_judge[count] = participants[j].Marks[i];
                        count++;
                    }

                    //сортировка
                    Array.Sort(marks_per_judge);

                    // итерация по marks_per_judge/по участникам всем
                    for (int j = 0; j < marks_per_judge.Length; j++)//все оценки у судьи по возрастанию
                    {
                        for (int k = 0; k < participants.Length; k++)
                        {
                            if (marks_per_judge[j] == participants[k].Marks[i])
                            {
                                participants[k]._places[i] = participants.Length - j;
                            }
                        }
                    }
                }
                //ну вроде как места проставили 

                //*проставить сумму мест для каждого партиспанта 
                for (int i = 0; i < participants.Length; i++)
                {
                    participants[i]._placesSum = participants[i]._places.Sum();
                }

                //сортировка participants
                for (int i = 0; i < participants.Length-1; i++)
                {
                    for (int j = 0; j < participants.Length - 1 - i; j++)
                    {
                        if (participants[j]._places[6] > participants[j + 1]._places[6])
                        {
                            Participant copy= participants[j+1];
                            participants[j+1]= participants[j];
                            participants[j]= copy;
                        } 

                    }
                }
            }
            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length-1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].Score > array[j + 1].Score ||
                            ((array[j].Score == array[j + 1].Score) &
                            (array[j]._places.Min() < array[j + 1]._places.Min())) ||
                            ((array[j].Score == array[j + 1].Score) &
                            (array[j]._places.Min() < array[j + 1]._places.Min()) &
                            (array[j]._marks.Sum() < array[j + 1]._marks.Sum())))
                        {
                            Participant copy =array[j+1];
                            array[j+1]=array[j];
                            array[j]=copy;
                        }   
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{this.Name} {this.Surname} {this.Score} {this.Places.Min()} {this.Marks.Sum()}");
            }

        }
    }
}
