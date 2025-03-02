namespace Lab_6 {
    public class Purple_4 {
        public struct Sportsman {
            public Sportsman(string name, string surname) {
                _name = name;
                _surname = surname;
            }

            private string _name;
            private string _surname;
            private double _time;

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public void Run(double time) {
                if (_time != 0) return;
                _time = time;
            }

            public void Print() {
                Console.WriteLine($"{_name, 15} {_surname, 15} {_time, 15}");
            }
        }

        public struct Group {
            public Group(string name) {
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public Group(Group group) {
                _name = group.Name;

                if (group.Sportsmen == null) {
                    _sportsmen = null;
                } else {
                    _sportsmen = new Sportsman[group.Sportsmen.Length];
                    Array.Copy(group.Sportsmen, _sportsmen, group.Sportsmen.Length);    
                }
            }

            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen {
                get {
                    // var copy = new Sportsman[_sportsmen.Length];
                    // Array.Copy(_sportsmen, copy, _sportsmen.Length);

                    // return copy;
                    return _sportsmen;
                }
            }

            public void Add(Sportsman sportsman) {
                if (_sportsmen == null) return;

                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen) {
                if (_sportsmen == null || sportsmen == null) return;
                int lastLen = _sportsmen.Length;
                Array.Resize(ref _sportsmen, _sportsmen.Length + sportsmen.Length);
                for (int i = 0; i < sportsmen.Length; i++) {
                    _sportsmen[lastLen + i] = sportsmen[i];
                }
            }

            public void Add(Group group) {
                if (_sportsmen == null || group.Sportsmen == null) return;

                Add(group.Sportsmen);
            }

            public void Sort() {
                if (_sportsmen == null) return;
                
                for (int i = 1; i < _sportsmen.Length; i++) {
                    Sportsman key = _sportsmen[i];
                    int j = i - 1;
                    
                    while (j >= 0 && _sportsmen[j].Time > key.Time)
                    {
                        _sportsmen[j + 1] = _sportsmen[j];
                        j--;
                    }
                    
                    _sportsmen[j + 1] = key;
                }
            }

            public static Group Merge(Group group1, Group group2) {
                if (group1.Sportsmen == null || group2.Sportsmen == null) return new Group();

                Group finalists = new Group("Финалисты");

                Sportsman[] group1Sportsmen = group1.Sportsmen;
                Sportsman[] group2Sportsmen = group2.Sportsmen;
                
                Sportsman[] finalistsSportsmen = new Sportsman[group1Sportsmen.Length + group2Sportsmen.Length];

                int i = 0, j = 0, k = 0;
                while (i < group1Sportsmen.Length && j < group2Sportsmen.Length) {
                    if (group1Sportsmen[i].Time <= group2Sportsmen[j].Time)
                        finalistsSportsmen[k++] = group1Sportsmen[i++];
                    else
                        finalistsSportsmen[k++] = group2Sportsmen[j++];
                }

                while (i < group1Sportsmen.Length)
                    finalistsSportsmen[k++] = group1Sportsmen[i++];

                while (j < group2Sportsmen.Length)
                    finalistsSportsmen[k++] = group2Sportsmen[j++];

                finalists.Add(finalistsSportsmen);

                return finalists;
            }
            
            public void Print() {
                Console.WriteLine(_name);

                foreach (Sportsman sportsman in _sportsmen) {
                    Console.WriteLine($"{sportsman.Name} {sportsman.Surname} {sportsman.Time}");
                }

                Console.WriteLine();
            }
        }
    }
}