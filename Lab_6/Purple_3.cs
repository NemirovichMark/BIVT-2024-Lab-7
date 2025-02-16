using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
    class Purple_3 {
        public struct Participant {
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _markCount;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks => (double[])_marks.Clone(); // shallow copy for safety
            public int[] Places => (int[])_places.Clone();
            public int Score {
                get { return _places.Sum(); } 
            }

            public Participant(string name, string surname) {
                _name = name;
                _surname = surname;

                _marks = new double[7];
                _places = new int[7];
            }

            public void Evaluate(double result) {
                if (_markCount >= 7) return;

                _marks[_markCount++] = result;
            }

            public static void SetPlaces(Participant[] participants) {
                if (participants == null) return;
                
                for (int judge = 0; judge < 7; judge++) {
                    participants = participants.OrderByDescending(x => x.Marks[judge]).ToArray(); // stable sort

                    int curPlace = 0;
                    double lastScore = -1;

                    foreach (var p in participants) {
                        if (p.Marks[judge] != lastScore)
                            curPlace++;

                        p.Places[judge] = curPlace;
                        lastScore = p.Marks[judge];
                    }
                }
            }

            public static void Sort(Participant[] array) {
                if (array == null) return;

                array = array.OrderBy(x => x, Comparer<Participant>.Create((a, b) => { // stable complex sort
                            int result = a.Score.CompareTo(b.Score);

                            if (result != 0) return result;

                            int aSecondCriteria = 0, bSecondCriteria = 0;

                            for (int judge = 0; judge < 7; judge++) {
                                if (a.Places[judge] < b.Places[judge]) // check for Places and Marks nullability?
                                    aSecondCriteria = 1;
                                else if (b.Places[judge] < a.Places[judge])
                                    bSecondCriteria = 1;
                            }

                            if (aSecondCriteria != bSecondCriteria)
                                return bSecondCriteria.CompareTo(aSecondCriteria);
                            
                            return b.Marks.Sum().CompareTo(a.Marks.Sum());
                        }))
                        .ToArray();
            }

        }
    }
}