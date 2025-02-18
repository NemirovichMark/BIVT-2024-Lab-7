namespace Lab_6{

    public class Purple_2
    {
        public struct Participant{
        private string _Name;
        private string _Surname;
        private int _Distance;
        private int[] _Marks;

        public string Name  => _Name;
        public string Surname => _Surname;
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
                int res = 60;
                int [] copy = new int[_Marks.Length];
                Array.Copy(_Marks, copy, _Marks.Length);

                if (_Distance >= 120){ res += (_Distance - 120) * 2;}
                else{ res -= (120 - _Distance) * 2;}
                res += copy.Sum() - copy.Max() - copy.Min();

                return res < 0 ? 0 : res;
            }
        }
        public Participant(string name, string surname){
            _Name = name;
            _Surname = surname;
            _Marks = new int[5];
        }
        public void Jump(int distance, int[] marks){
            if (marks == null) return;
            _Distance = distance;
            Array.Copy(marks,_Marks,marks.Length);
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
    }
}