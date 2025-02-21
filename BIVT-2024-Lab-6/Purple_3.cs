using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIVT_2024_Lab_6
{
    public class Purple_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _curMark;

            public string Name
            {
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
                    if (_marks is null) return null;
                    double[] marksCopy = new double[_marks.Length];
                    Array.Copy(_marks, marksCopy, marksCopy.Length);
                    return marksCopy;
                }
            }

            public int[] Places
            {
                get
                {
                    if (_places is null) return null;
                    int[] placesCopy = new int[_places.Length];
                    Array.Copy(_places, placesCopy, placesCopy.Length);
                    return placesCopy;
                }
            }

            public int Score
            {
                get
                {
                    if (_places is null) return 0;

                    int score = 0;
                    for (int i = 0; i < _places.Length; i++)
                        score += _places[i];

                    return score;
                }
            }

            public double TotalMark
            {
                get
                {
                    if (_marks is null) return 0;

                    double score = 0;
                    for (int i = 0; i < _marks.Length; i++)
                        score += _marks[i];

                    return score;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_places is null) return 0;

                    return _places.Min();
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _curMark = 0;
                for (int i = 0; i < 7; i++)
                {
                    _marks[i] = -1;
                    _places[i] = 0;
                }
            }

            public void Evaluate(double result)
            {
                if (_curMark == 7) return;

                if (result < 0 || result > 6)
                {
                    return;
                }
                _marks[_curMark++] = result;
            }

            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null) return;

                for (int judge = 0; judge < 7; judge++)
                {
                    for (int i = 1, j = 2; i < participants.Length;)
                    {
                        if (i == 0)
                        {
                            i = j;
                            j++;
                        } 
                        else if (participants[i]._marks is null)
                        {
                            i = j;
                            j++;
                        } 
                        else if (participants[i - 1]._marks is null)
                        {
                            Participant tmp = participants[i];
                            participants[i] = participants[i - 1];
                            participants[i - 1] = tmp;
                            i--;
                        } 
                        else if (participants[i].Marks[judge] < participants[i - 1].Marks[judge])
                        {
                            i = j;
                            j++;
                        } 
                        else
                        {
                            Participant tmp = participants[i];
                            participants[i] = participants[i - 1];
                            participants[i - 1] = tmp;
                            i--;
                        }
                    }
                    for (int place = 0; place < participants.Length; place++)
                    {
                        if (participants[place]._places != null)
                            participants[place]._places[judge] = place + 1;
                    }
                    
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length < 2) return;

                for (int i = 1, j = 2; i < array.Length;)
                {
                    if (i == 0)
                    {
                        i = j;
                        j++;
                        continue;
                    }
                    int score1 = array[i].Score, score2 = array[i - 1].Score;
                    if (score1 > score2)
                    {
                        i = j;
                        j++;
                    } else if (score1 < score2)
                    {
                        Participant tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                        i--;
                    }
                    else
                    {
                        if (score1 == score2 && score1 == 0)
                        {
                            i = j;
                            j++;
                            continue;
                        }
                        int isHigher = 0;
                        int[] places1 = array[i].Places, places2 = array[i - 1].Places;
                        for (int k = 0; k < 7; k++)
                        {
                            if (places1[k] < places2[k])
                            {
                                isHigher = 1;
                                break;
                            } else if (places1[k] < places2[k])
                            {
                                isHigher = -1;
                                break;
                            }
                        }
                        if (isHigher == 1)
                        {
                            Participant tmp = array[i];
                            array[i] = array[i - 1];
                            array[i - 1] = tmp;
                            i--;
                            continue;
                        } else if (isHigher == -1)
                        {
                            i = j;
                            j++;
                            continue;
                        }

                        double totalMark1 = array[i].TotalMark, totalMark2 = array[i - 1].TotalMark;
                        if (totalMark1 < totalMark2)
                        {
                            i = j;
                            j++;
                        } else
                        {
                            Participant tmp = array[i];
                            array[i] = array[i - 1];
                            array[i - 1] = tmp;
                            i--;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {Score} {TopPlace} {TotalMark}");
            }

           
        }
        public static void PrintArr(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }

        public static void PrintArr(double[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }

    }
}
