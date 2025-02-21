using System;
using System.Collections.Generic;
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
                _marks[_curMark] = result;
            }

            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null) return;

                for (int j = 0; j < 7; j++)
                {
                    for (int i = 1, k = 2; i < participants.Length;)
                    {
                        if (participants[i - 1]._marks == null || participants[i]._marks == null)
                            continue;
                        if (i == 0 || participants[i - 1].Marks[j] > participants[i - 1].Marks[j])
                        {
                            i = k;
                            k++;
                        }
                        else
                        {
                            Participant tmp = participants[k];
                            participants[k] = participants[j];
                            participants[j] = tmp;
                            i--;
                        }
                    }

                    for (int place = 0; place < participants.Length; place++)
                    {
                        participants[place]._places[j] = place + 1;
                    }
                }
            }
        }
    }
}
