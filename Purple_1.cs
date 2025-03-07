namespace Lab_7{

public class Purple_1
{
    public class Participant{
        private string _Name;
        private string _Surname;
        private double[] _Coefs;
        private int[,] _Marks;
        private int _NumberJump;

        public string Name  => _Name;
        public string Surname => _Surname;
        public double[] Coefs 
        { 
            get{
            if (_Coefs == null) return null;
            double[] copy = new  double[4];
            Array.Copy(_Coefs,copy, _Coefs.Length);
            return copy;
            }
        }
        public int[,] Marks 
        {
            get{
                if (_Marks == null) return null;
                int[,] copy = new int[_Marks.GetLength(0), _Marks.GetLength(1)];
                Array.Copy(_Marks, copy, _Marks.Length);
                return copy;
            }
        }

        public double TotalScore{
            get{
                 if (_Marks == null || _Coefs == null || _Marks.GetLength(0) == 0 || _Coefs.Length == 0) return 0;
                int[,] copy = Marks;
                double score = 0;
                for (int i = 0; i < _Marks.GetLength(0); i++){
                    
                    int s = Enumerable.Range(0, Marks.GetLength(1)).Sum(j => copy[i, j]);
                    int mn = Enumerable.Range(0, Marks.GetLength(1)).Min(j => copy[i, j]); 
                    int mx = Enumerable.Range(0, Marks.GetLength(1)).Max(j => copy[i, j]);

                    score += (s-mn-mx)*_Coefs[i];
                 }
                return score;
            }
        }

        public Participant(string name, string surname){
            _Name = name;
            _Surname = surname;
            _Coefs = new double[4]{2.5,2.5,2.5,2.5};
            _Marks = new int[4,7];
            _NumberJump = 0;
        }
        public void SetCriterias(double[] coefs){
            if (_Coefs == null || coefs == null) return;
            Array.Copy(coefs,_Coefs,coefs.Length);
        }
        public void Jump(int[] marks){
            if (_Marks == null || marks == null || _NumberJump > 3) return;
            for(int i = 0;i < marks.Length;i++){
                _Marks[_NumberJump,i] = marks[i]; 
            }
            _NumberJump++;
        }
        public static void Sort(Participant[] array){
        if (array == null) return;
        int n = array.Length;

        for (int i = 0; i < n - 1; i++){
            for (int j = 0; j < n - 1 - i; j++){
                if (array[j].TotalScore < array[j + 1].TotalScore)
                {
                   (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }
        public void Print(){
            Console.WriteLine($"{_Name,-12} {_Surname,-12} {Math.Round(TotalScore,1),-11}");
        }
    }
    public class Judge{
        private string _Name;
        private int[] _Marks = new int[4];
        private int _Cnt = 0;

        public string Name => _Name;

        public Judge(string name, int[] marks){
            _Name = name;
            Array.Copy(marks,_Marks,marks.Length);
        }

        public int CreateMark(){
            if (_Marks == null) return 0;
            _Cnt = _Cnt > 3 ? 0 : _Cnt;
            return _Marks[_Cnt++];
        }
        public void Print(){
            Console.WriteLine($"{_Name,-12} {string.Join(" ",_Marks)}");
        }
    }
    public class Competition{

        private Judge[] _Judges;
        private Participant[] _Participants;

        public Judge[] Judge => _Judges;

        public Participant[] Participant => _Participants;

        public Competition(Judge[] judge){
            _Judges = judge;
            _Participants = [];
        }

        public void Evaluate(Participant jumper){
            if (jumper == null) return;
            jumper.Jump(_Judges.Select(judge => judge.CreateMark()).ToArray());
        }

        public void Add(Participant[] participants){
                if (participants == null || _Participants == null) return;

                int currentLength = _Participants.Length;

                Array.Resize(ref _Participants, currentLength + participants.Length);

                for (int i = 0; i < participants.Length; i++) {
                    _Participants[currentLength + i] = participants[i];
                }
        }

        public void Sort(){
            _Participants = _Participants.OrderByDescending(x => x.TotalScore).ToArray();
        }
    }
}
}
