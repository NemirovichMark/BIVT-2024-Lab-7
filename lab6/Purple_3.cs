using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6{
    public class Purple_3{
        public struct Participant{
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _currentMark = 0;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks{
                get{
                    if (_marks == null) return null;
                    double[] copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public int[] Places{
                get{
                    if (_places == null) return null;
                    int[] copy = new int[_places.Length];
                    Array.Copy(_places, copy, _places.Length);
                    return copy;
                }
            }

            public int Score{
                get{
                    if (_places == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < _places.Length; i++){
                        sum += _places[i];
                    }
                    return sum;
                }
            }

            public Participant(string name, string surname){
                _name = name;
                _surname = surname;
                _marks = new double[7]{0, 0, 0, 0, 0, 0, 0};
                _places = new int[7]{0, 0, 0, 0, 0, 0, 0};
            }

            public void Evaluate(double result){
                if (_marks == null) return;

                if (_currentMark < _marks.Length){
                    _marks[_currentMark] = result;
                    _currentMark++;
                }
            }

            public static void SetPlaces(Participant[] participants){
                if (participants == null) return;

                for (int judje = 0; judje < 7; judje++){
                    for (int i = 1; i < participants.Length; i++){
                        int k = i, j = k - 1;
                        while (j >= 0){
                            if (participants[j].Marks[judje] < participants[k].Marks[judje]){
                                Participant tmp = participants[k];
                                participants[k] = participants[j];
                                participants[j] = tmp;
                            }
                            k = j;
                            j--;
                        }
                    }
                    //participants - отсортирован относительно i-го судьи

                    for (int place = 0; place < participants.Length; place++){
                        participants[place]._places[judje] = place + 1;
                    }
                }
                // for (int i = 1; i < participants.Length; i++){
                //     int k = i, j = k-1;
                //     while (j >= 0){
                //         if (participants[j].Places[6] < participants[k].Places[6]){
                //             Participant tmp = participants[k];
                //             participants[k] = participants[j];
                //             participants[j] = tmp;
                //         }
                //         k = j;
                //         j--;
                //     }
                //     }
            }

            public static void Sort(Participant[] array){
                if (array == null) return;
                
                for (int i = 1; i < array.Length; i++){
                    int k = i, j = k - 1;
                    while (j >= 0){
                        if (array[j]._places.Sum() > array[k]._places.Sum()){
                            Participant tmp = array[k];
                            array[k] = array[j];
                            array[j] = tmp;
                        }
                        else if (array[j]._places.Sum() == array[k]._places.Sum()){
                            int partJ = 0, partK = 0;
                            for (int placeIndex = 0; placeIndex < array[j]._places.Length; placeIndex++){
                                if (array[j]._places[placeIndex] > array[k]._places[placeIndex]){
                                    partK++;
                                }
                                else{
                                    partJ++;
                                }
                            }
                            if (partJ > partK){
                                Participant tmp = array[k];
                                array[k] = array[j];
                                array[j] = tmp;
                            }
                            if (partJ == partK && array[j]._marks.Sum() > array[k]._marks.Sum()){
                                Participant tmp = array[k];
                                array[k] = array[j];
                                array[j] = tmp;
                            }
                        }
                        k = j;
                        j--;
                    }
                }
            }   

            public void Print(){}
        }

    }
}