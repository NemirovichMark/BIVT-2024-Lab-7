

namespace Lab_6 {
    public class Purple_2
    {
        public struct Participant {
            public Participant(string name, string surname) {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }

            private string _name;
            private string _surname;
            private int _jumpDistance;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _jumpDistance;
            public int[] Marks {
                get {
                    if (_marks == null) return null;

                    var copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int Result {
                get; private set;
            }

            public void Jump(int distance, int[] marks) {
                if (_marks == null || marks == null || marks.Length != 5 || distance < 0) return;
                _jumpDistance = distance;
                Array.Copy(marks, _marks, marks.Length);

                int tempResult = _marks.Sum() - (_marks.Min() + _marks.Max()) + 60 + (_jumpDistance - 120) * 2;

                if (tempResult < 0)
                    Result = 0;
                else
                    Result = tempResult;
            }

            public static void Sort(Participant[] array) { // insertion sort
                if (array == null) return;

                for (int i = 1; i < array.Length; i++) {
                    Participant key = array[i];
                    int j = i - 1;

                    while (j >= 0 && array[j].Distance < key.Distance) {
                        array[j + 1] = array[j];
                        j--;
                    }

                    array[j + 1] = key;
                }
            }

            public void Print() {
                Console.WriteLine($"{_name, 15} {_surname, 15} {Result, 15}");
            }
        }
    }
}