using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Purple_3
    {
        public struct Participant
        {
            private string _name, _surname;
            private double[] _marks;
            private int[] _places;
            private int _indexJudge;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    return (double[])_marks.Clone();
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null) return null;
                    return (int[])_places.Clone();
                }
            }
            public Participant(string name, string surname) {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _indexJudge = 0;
            }
            public void Evaluate(double result)
            {
                if (_indexJudge >= 7) return;
                if (_marks == null) return;
                _marks[_indexJudge++] = result;
            }
            public int Score
            {
                get
                {
                    if (_places is null) return 0;
                    int s = 0;
                    for (int i = 0; i < _places.Length; i++) s += _places[i];
                    return s;
                }
            }

            private double TotalMark
            {
                get
                {
                    if (_marks is null) return 0;

                    double s = 0;
                    for (int i = 0; i < _marks.Length; i++) s += _marks[i];

                    return s;
                }
            }

            private int TopPlace
            {
                get
                {
                    if (_places == null) return 0;
                    return _places.Min();
                }
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
                            i = j++;
                        }
                        else if (participants[i]._marks == null)
                        {
                            i = j++;
                        }
                        else if (participants[i - 1]._marks == null)
                        {
                            Participant tmp = participants[i];
                            participants[i] = participants[i - 1];
                            participants[i - 1] = tmp;
                            i--;
                        }
                        else if (participants[i].Marks[judge] < participants[i - 1].Marks[judge])
                        {
                            i = j++;
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
                        if (participants[place]._places != null) participants[place]._places[judge] = place + 1;
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
                    }
                    else if (score1 < score2)
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
                            }
                            else if (places1[k] < places2[k])
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
                        }
                        else if (isHigher == -1)
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
                        }
                        else
                        {
                            Participant tmp = array[i];
                            array[i] = array[i - 1];
                            array[i - 1] = tmp;
                            i--;
                        }
                    }
                }
            }
        }
    }
}
