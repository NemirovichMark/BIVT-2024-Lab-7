using System.Linq;

namespace Lab_6 {
    internal class Purple_1
    {
        public struct Participant {
            public Participant(string name, string surname) {
                _name = name;
                _surname = surname;
                _coefs = new double[4];
                for (int i = 0; i < _coefs.Length; i++) 
                    _coefs[i] = 2.5;
                _marks = new int[4, 7];
            }

            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _jumpCounter;
            private double _totalScore;

            private static Participant[] MergeSort(Participant[] array) {
                if (array == null || array.Length <= 1) return array;
                int n = array.Length;
                Participant[] left = new Participant[n/2];
                Participant[] right = new Participant[n - n/2];
                for (int i = 0; i < array.Length; i++) {
                    if (i < n/2) left[i] = array[i];
                    else right[i - n/2] = array[i];
                }
                left = MergeSort(left);
                right = MergeSort(right);
                return Merge(left, right);
            }

            private static Participant[] Merge(Participant[] left, Participant[] right) {
                int i = 0, j = 0, k = 0;
                Participant[] result = new Participant[left.Length + right.Length];
                while (i < left.Length && j < right.Length) {
                    if (left[i].TotalScore >= right[j].TotalScore) result[k++] = left[i++];
                    else result[k++] = right[j++];
                }
                while (i < left.Length)
                    result[k++] = left[i++];
                while (j < right.Length)
                    result[k++] = right[j++];
                return result;
            }

            public string Name { get; private set; }
            public string Surname { get; private set; }
            public double[] Coefs {
                get {
                    var copy = new double[4];
                    Array.Copy(_coefs, copy, _coefs.Length);
                    return copy;
                }
            }

            public int[,] Marks {
                get {
                    var copy = new int[4, 7];
                    for (int i = 0; i < 4; i++) {
                        for (int j = 0; j < 7; j++) {
                            copy[i, j] = _marks[i, j];
                        }
                    }
                    return copy;
                }
            }
            
            public double TotalScore => _totalScore;

            public void SetCriterias(double[] coefs) {
                if (coefs == null) return;

                for (int i = 0; i < 4; i++) {
                    _coefs[i] = coefs[i];
                }
            }

            public void Jump(int[] marks) {
                if (marks == null) return;

                double currentScore = (marks.Sum() - marks.Min() - marks.Max()) * _coefs[_jumpCounter];
                _totalScore += currentScore;

                for (int i = 0; i < 7; i++) {
                    _marks[_jumpCounter, i] = marks[i];
                }
                _jumpCounter++;
            }

            public static void Sort(Participant[] array) {
                array = MergeSort(array);
            }

            public void Print() {
                Console.Write($"{_name} {_surname}");
                if (_coefs != null) {
                    foreach (var item in _coefs)
                        Console.Write($"{item, 5}");
                }

                Console.Write(" ");

                if (_marks != null) {
                    foreach (var item in _marks)
                        Console.Write($"{item, 5}");
                }
                Console.WriteLine();

            }
        }
    }
}