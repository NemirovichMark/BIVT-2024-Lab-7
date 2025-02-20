namespace Lab_6{

    public class Purple_4
    {
        public struct Sportsman{
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
            public void Print(){
                Console.WriteLine($"{_Name,-12} {_Surname,-12} {_Time,-10}");
            }
        }
        public struct Group{
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

                Array.Resize(ref _Sportsmen, _Sportsmen.Length + sportsmen.Length);

                for (int i = 0; i < sportsmen.Length; i++) _Sportsmen[_Sportsmen.Length+i] = sportsmen[i];
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
            public void Print(){}
        }
    }
}