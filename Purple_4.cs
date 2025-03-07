namespace Lab_7{

    public class Purple_4
    {
        public class Sportsman{
            private string _Name;
            private string _Surname;
            private double _Time;

            public string Name => _Name;
            public string Surname => _Surname;
            public double Time => _Time;

            public Sportsman(string name, string surname){
                _Name = name;
                _Surname = surname;
                _Time = 0;
            }
            public void Run(double time){
                if (_Time != 0) return;
                _Time = time;
            }
            public static void Sort(Sportsman[] array){
                if (array == null) return;

                var sortedList = array.OrderBy(x => x._Time).ToArray();

                Array.Copy(sortedList, 0, array, 0, array.Length);
            }
            public void Print(){
                Console.WriteLine($"{_Name,-12} {_Surname,-12} {_Time,-10}");
            }
        }

        public class SkiMan : Sportsman{
            public SkiMan(string name, string surname)
                : base(name, surname)
            { }
            public SkiMan(string name, string surname, double time)
                : base(name, surname)
            {
                Run(time); 
            }
        }

        public class SkiWoman : Sportsman{
            public SkiWoman(string name, string surname)
                : base(name, surname)
            { }

            public SkiWoman(string name, string surname, double time)
                : base(name, surname){
                Run(time);
            }
        }
        public class Group {
            private string _Name;
            private Sportsman[] _Sportsmen;

            public string Name => _Name;
            public Sportsman[] Sportsmen => _Sportsmen;

            public Group(string name){
                _Name = name;
                _Sportsmen = new Sportsman[0];
            }

            public Group(Group group){
                if (group._Sportsmen == null) return;

                _Name = group.Name;
                _Sportsmen = new Sportsman[group.Sportsmen.Length];
                Array.Copy(group.Sportsmen, _Sportsmen, group.Sportsmen.Length);
            }

            public void Add(Sportsman sportsman){
                if (_Sportsmen == null) return;

                Array.Resize(ref _Sportsmen, _Sportsmen.Length + 1);
                _Sportsmen[_Sportsmen.Length-1] = sportsman;
            }
            public void Add(Group group){
                if (_Sportsmen == null || group._Sportsmen == null) return;

                for (int i = 0; i < group.Sportsmen.Length; i++) Add(group.Sportsmen[i]);
            }
            public void Add(Sportsman[] sportsmen){
                if (sportsmen == null || _Sportsmen == null) return;

                int currentLength = _Sportsmen.Length;

                Array.Resize(ref _Sportsmen, currentLength + sportsmen.Length);

                for (int i = 0; i < sportsmen.Length; i++) _Sportsmen[currentLength+i] = sportsmen[i];
            }

            public void Sort(){
                if (_Sportsmen == null) return;
                _Sportsmen = _Sportsmen.OrderBy(s => s.Time).ToArray();
            }

             public static Group Merge(Group group1, Group group2){
                Group mergeGroup = new Group("Финалисты");
                if (group1._Sportsmen == null || group2._Sportsmen == null || mergeGroup._Sportsmen == null) return new Group("Финалисты");
                int i = 0, j = 0;

                while (i < group1.Sportsmen.Length && j < group2.Sportsmen.Length){
                    if (group1.Sportsmen[i].Time < group2.Sportsmen[j].Time) mergeGroup.Add(group1.Sportsmen[i++]);

                    else mergeGroup.Add(group2.Sportsmen[j++]);
                }

                while (i < group1.Sportsmen.Length) mergeGroup.Add(group1.Sportsmen[i++]);

                while (j < group2.Sportsmen.Length) mergeGroup.Add(group2.Sportsmen[j++]);

                return mergeGroup;
            }

            public void Split(out Sportsman[] men, out Sportsman[] women){
                int cntM = 0, cntW = 0;

                foreach (var sportsman in _Sportsmen){
                    if (sportsman is SkiMan) cntM++;
                    else if (sportsman is SkiWoman) cntW++;
                }

                men = new Sportsman[cntM];
                women = new Sportsman[cntW];

                int indM = 0, indW = 0;

                foreach (var sportsman in _Sportsmen){
                    if (sportsman is SkiMan) men[indM++] = sportsman;
                    else if (sportsman is SkiWoman) women[indW++] = sportsman;
                }
            }

            public void Shuffle(){
                Split(out var skiMen, out var skiWomen);

                var sortedMen = skiMen.OrderBy(s => s.Time).ToArray();
                var sortedWomen = skiWomen.OrderBy(s => s.Time).ToArray();

                int cntM = sortedMen.Length, cntW = sortedWomen.Length;
                Sportsman[] shuffled = new Sportsman[cntM+cntW];

                int indM = 0, indW = 0;
                bool isMen = true; 

                for (int i = 0; i < cntM+cntW; i++){
                    if (isMen && indM < cntM) shuffled[i] = sortedMen[indM++];
                    else if (!isMen && indW < cntW) shuffled[i] = sortedWomen[indW++];

                    isMen = !isMen;
                }
                _Sportsmen = shuffled;
            }
 
             public void Print(){
                Console.WriteLine($"Group: {_Name}");
                foreach (var sportsman in _Sportsmen){
                    sportsman.Print();
                }
            }
        }
    }
}