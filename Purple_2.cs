namespace Lab_7{

    public class Purple_2
    {
        public struct Participant{
        private string _Name;
        private string _Surname;
        private int _Distance;
        private int[] _Marks;
        private int _Target;

        public string Name  => _Name;
        public string Surname => _Surname;
        public int Distance => _Distance;
        public int[] Marks 
        {
            get{
                if (_Marks == null) return null;
                int[] copy = new int[_Marks.Length];
                Array.Copy(_Marks, copy, _Marks.Length);
                return copy;
            }
        }
        public int Result{
            get{
                if (_Marks == null) return 0;
                int res = 60;
                int [] copy = new int[_Marks.Length];
                Array.Copy(_Marks, copy, _Marks.Length);

                if (_Distance >= _Target){ res += (_Distance - _Target) * 2;}
                else{ res -= (120 - _Target) * 2;}
                res += copy.Sum() - copy.Max() - copy.Min();

                return res < 0 ? 0 : res;
            }
        
        }
        public Participant(string name, string surname){
            _Name = name;
            _Surname = surname;
            _Marks = new int[5];
            _Distance = 0;
            _Target = 100;
        }
        public void Jump(int distance, int[] marks, int target){
            if (_Marks == null || marks == null) return;
            _Distance = distance;
            _Target = target;
            Array.Copy(marks,_Marks, Math.Min(_Marks.Length, marks.Length));
        }

        public static void Sort(Participant[] array){
        if (array == null) return;
        int n = array.Length;

        for (int i = 0; i < n - 1; i++){
            for (int j = 0; j < n - 1 - i; j++){
                if (array[j].Result < array[j + 1].Result){
                   (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }

        public void Print(){
             Console.WriteLine($"{_Name,-12} {_Surname,-12} {Result,-11}");
        }

        }

        public abstract class SkiJumping{
            private string _Name;
            private int _Standard;
            private Participant[] _Participants;

            public string Name => _Name;
            public int Standard => _Standard;
            public Participant[] Participants => _Participants;

            public SkiJumping(string name, int standard){
                _Name = name;
                _Standard = standard;
                _Participants = [];
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

            public void Jump(int distance, int[] marks){
                if (_Participants == null || marks == null) return;
                for(int i = 0; i < Participants.Length;i++){
                    if (Participants[i].Distance == 0){
                        Participants[i].Jump(distance, marks, _Standard);                
                        break;
                    }
                }
            }
            public void Print(){
                Console.WriteLine($"Competition: {Name}");
                Console.WriteLine($"Standard Distance: {Standard}m");
                Console.WriteLine("Participants:");
                foreach (var participant in _Participants)
                {
                    participant.Print();
                }
            }
        }
        public class JuniorSkiJumping : SkiJumping{
            public JuniorSkiJumping() 
                : base("100m", 100) 
            { }
        }

        public class ProSkiJumping : SkiJumping{
            public ProSkiJumping() 
                : base("150m", 150) 
            { }
        }
    }
}