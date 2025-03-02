namespace Lab_6 {
    public class Purple_3 {
        public struct Participant {
            public Participant(string name, string surname) {
                _name = name;
                _surname = surname;

                _marks = new double[7];
                _places = new int[7];
            }
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;

            private int _marksCounter;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks {
                get {
                    if (_marks == null) return null;

                    var copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);

                    return copy;
                }
            }

            public int[] Places {
                get {
                    if (_places == null) return null;
                    var copy = new int[_places.Length];
                    Array.Copy(_places, copy, _places.Length);

                    return copy;
                }
            }

            public int Score {
                get {
                    if (_places == null) return 0;

                    return _places.Sum();
                }
            }

            public void Evaluate(double result) {
                if (_marks == null || _marksCounter >= _marks.Length) return;

                _marks[_marksCounter++] = result;
            }

            public static void SetPlaces(Participant[] participants) {
                if (participants == null || participants.Length == 0) return;

                for (int judge = 0; judge < 7; judge++) {
                    int goodParticipants = 0;

                    foreach (var participant in participants) {
                        if (participant.Marks != null && participant.Places != null)
                            goodParticipants++;
                    }

                    Participant[] sortedParticipants = new Participant[goodParticipants];

                    int sortedIndex = 0;
                    
                    foreach (var participant in participants) {
                        if (participant.Marks != null && participant.Places != null)
                            sortedParticipants[sortedIndex++] = participant;
                    }

                    for (int i = 1; i < sortedParticipants.Length; i++) { // insertion sort
                        Participant key = sortedParticipants[i];
                        int j = i - 1;
                        while (j >= 0 && sortedParticipants[j].Marks[judge] < key.Marks[judge]) {
                            sortedParticipants[j + 1] = sortedParticipants[j];
                            j--;
                        }
                        sortedParticipants[j + 1] = key;
                    }

                    for (int i = 0; i < goodParticipants; i++) {
                        sortedParticipants[i]._places[judge] = i + 1;
                    }

                    if (judge == 6) {
                        sortedIndex = sortedParticipants.Length;
                        Participant[] finalList = new Participant[participants.Length];
                        Array.Copy(sortedParticipants, finalList, sortedParticipants.Length);

                        foreach (var participant in participants) {
                            if (participant.Marks == null) finalList[sortedIndex++] = participant;
                        }

                        Array.Copy(finalList, participants, participants.Length);
                    }
                }
            }

            public static void Sort(Participant[] array) {
                if (array == null) return;
                for (int i = 1; i < array.Length; i++) {
                    Participant key = array[i];
                    int j = i - 1;
                    
                    while (j >= 0) {
                        int scoreComparison = key.Score.CompareTo(array[j].Score);
                        if (scoreComparison < 0) {
                            array[j + 1] = array[j];
                        } else if (scoreComparison == 0) {
                            bool hasHigherPlace = false;
                            for (int k = 0; k < 7; k++) {
                                if (key.Places[k] < array[j].Places[k]) {
                                    hasHigherPlace = true;
                                    break;
                                } else if (key.Places[k] > array[j].Places[k]) {
                                    hasHigherPlace = false;
                                    break;
                                }
                            }

                            if (!hasHigherPlace) {
                                double totalMarksA = array[j].Marks.Sum();
                                double totalMarksB = key.Marks.Sum();
                                if (totalMarksB < totalMarksA) break;
                            }
                            array[j + 1] = array[j];
                        } else {
                            break;
                        }
                        j--;
                    }
                    array[j + 1] = key;
                }

            }

            public void Print() {
                Console.Write($"{_name, 15} {_surname, 15}\t");
                if (_places != null)
                    Console.Write($"{_places.Sum()}\t");
                    Console.Write($"{_places.Min()}\t");
                if (_marks != null)
                    Console.Write($"{Math.Round(_marks.Sum(), 2)}\t");
                Console.WriteLine();
            }


        }
    }
}