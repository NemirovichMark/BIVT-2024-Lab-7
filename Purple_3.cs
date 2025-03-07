namespace Lab_7{

    public class Purple_3
    {
        public struct Participant
         {
            private string _Name;
            private string _Surname;
            private double[] _Marks;
            private int[] _Places;
            private int _NextMark;

            public string Name => _Name;
            public string Surname => _Surname;
            public double[] Marks 
            {
                get{
                    if (_Marks == null) return null;
                    double[] copy = new double[_Marks.Length];
                    Array.Copy(_Marks, copy, _Marks.Length);
                    return copy;
                }
            }
            public int[] Places
            {
                get{
                    if (_Places == null) return null;
                    int[] copy = new int[_Places.Length];
                    Array.Copy(_Places, copy, _Places.Length);
                    return copy;
                }
            }
            public Participant(string name, string surname){
                _Name = name;
                _Surname = surname;
                _Marks = new double[7];
                _Places = new int[7];
            }
            public void Evaluate(double result){
                if (_NextMark >= 7 || _Marks == null) return;
                _Marks[_NextMark++] = result;

            }

            public static void SetPlaces(Participant[] participants){
                if (participants == null ) return;

                for (int judge = 0; participants[0]._Marks != null && judge < participants[0]._Marks.Length ; judge++){

                    double[] scores = new double[participants.Length];
                    int[] sortedIndexes = new int[participants.Length];

                    int validParticipants = 0;

                    for (int i = 0; i < participants.Length; i++){
                        if (participants[i]._Marks != null && participants[i]._Places != null && participants[i]._Marks.Length > judge){
                            scores[validParticipants] = participants[i]._Marks[judge];
                            sortedIndexes[validParticipants] = i;
                            validParticipants++;
                        }
                    }
                    if (validParticipants == 0) continue;

                    Array.Resize(ref scores, validParticipants);
                    Array.Resize(ref sortedIndexes, validParticipants);

                    Array.Sort(scores, sortedIndexes);
                    Array.Reverse(sortedIndexes);

                    for (int i = 0; i < validParticipants; i++)
                    {
                        participants[sortedIndexes[i]]._Places[judge] = i + 1; 
                    }
                }
                for (int i = 0; i < participants.Length - 1; i++){
                    for (int j = 0; j < participants.Length - 1 - i; j++){
                        if (participants[j]._Places != null && participants[j + 1]._Places != null){
                            if (participants[j]._Places[participants[j]._Places.Length - 1] >  participants[j + 1]._Places[participants[j + 1]._Places.Length - 1]){
                                (participants[j], participants[j + 1]) = (participants[j + 1], participants[j]);
                        }
                        }
                    }
                }
            }
            public int Score{
                get{
                    if (_Places == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < _Places.Length; i++){
                        sum += _Places[i];
                    }
                    return sum;
                }
            }
            private double Marks_score{
                get{
                    if (_Marks == null) return 0;
                    double sum = 0;
                    for (int i = 0; i < _Marks.Length; i++){
                        sum += _Marks[i];
                    }
                    return sum;
                }
            }
            public static void Sort(Participant[] array){
                if (array == null) return;

                var sortedList = array.Where(p => p.Marks != null && p.Places != null)
                .OrderBy(p => p.Score).ThenBy(p => string.Join(",", p.Places)).
                ThenByDescending(p => p.Marks_score).ToArray(); 

                int minLength = Math.Min(sortedList.Length, array.Length);
                Array.Copy(sortedList, 0, array, 0, minLength);
            }
            public void Print(){
                Console.WriteLine($"{_Name,-12} {_Surname,-12} {Score,-10} {Places.Min(),-8} {Math.Round(Marks.Sum(),2),-7}");
            }
        }
        public  abstract class Skating{
            private Participant[] _Participants;
            protected double[] _Moods;

            public Participant[] Participants => _Participants;
            public double[] Moods{
                get{
                    if (_Moods == null) return null;
                    double[] copy = new  double[5];
                    Array.Copy(_Moods,copy, _Moods.Length);
                    return copy;
                }
            }

            public Skating(double[] moods){
                _Moods = moods;
                ModificateMood();
                _Participants = [];
            }

            protected abstract void ModificateMood();

            public void Evaluate(double[] marks){
                if (_Participants == null || marks == null || marks.Length == 0) return;

                for (int i = 0; i < marks.Length; i++) marks[i] *= _Moods[i];

                for(int i = 0; i < _Participants.Length;i++)
                {
                    if (_Participants[i].Marks[0] == 0)
                    {
                        for(int j = 0; j < marks.Length;j++){
                            _Participants[i].Evaluate(marks[j]);
                        }
                        break;
                    }
                }
        }

            public void Add(Participant participant){
                if (_Participants == null) return;

                Array.Resize(ref _Participants , _Participants .Length + 1);
                _Participants[_Participants.Length-1] = participant;
            }

            public void Add(Participant[] participants){
                if (participants == null || _Participants == null) return;

                int currentLength = _Participants.Length;

                Array.Resize(ref _Participants, currentLength + participants.Length);

                for (int i = 0; i < participants.Length; i++) _Participants[currentLength + i] = participants[i];
            }

            public void Print(){
                Console.WriteLine("Participants:");
                foreach (var participant in _Participants)
                {
                    participant.Print();
                }
        }
    }
        public class FigureSkating : Skating{

            public FigureSkating(double[] moods) 
                : base(moods) 
            { }

            protected override void ModificateMood() {
                for (int i = 0; i < _Moods.Length; i++){
                    _Moods[i] += i/10.0; 
                }
            }
        }


        public class IceSkating : Skating{
        
            public IceSkating(double[] moods) 
                : base(moods)
            { }

            protected override void ModificateMood(){
                for (int i = 0; i < _Moods.Length; i++){
                    _Moods[i] += _Moods[i] * i/100.0;  
                }
            }
        }
    }
 }
            