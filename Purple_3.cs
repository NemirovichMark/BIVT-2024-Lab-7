using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;

            private int _markIndex;

            public string Name => _name;
            public string Surname => _surname;
            public int Score => (_places == null) ? 0 : _places.Sum();
            
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _markIndex = 0;
            }
            
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    double[] marks = new double[_marks.Length];
                    Array.Copy(_marks, marks, _marks.Length);
                    return marks;
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null) return null;
                    int[] places = new int[_places.Length];
                    Array.Copy(_places, places, _places.Length);
                    return places;
                }
            }

            public void Evaluate(double result) 
            {
                if (_markIndex >= 7) return;
                _marks[_markIndex++] = result;
            }

            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null) return;
                Participant[] temp = new Participant[participants.Length];
                for (int i = 0; i < 7; i++) // i-й судья
                {
                    temp = participants.Where(p => p._marks != null && p._places != null).OrderByDescending(p => p._marks[i]).ToArray();
                    for (int j = 0; j < temp.Length; j++) temp[j]._places[i] = j + 1;
                }
                Array.Copy(temp.Concat(participants.Where(p => p._marks == null || p._places == null)).ToArray(),
                    participants, participants.Length);
            }
            
            // linq-реализация
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1) return;
                Participant[] buffer = new Participant[array.Length];
                buffer = array.Where(p => p._marks != null && p._places != null).
                    OrderBy(p => p.Score).ThenBy(p => p._places.Min()).
                    ThenByDescending(p => p._marks.Sum()).ToArray();
                Array.Copy(buffer.Concat(array.Where(p => p._marks == null || p._places == null)).ToArray(),
                    array, array.Length);
            }
            
            public void Print()
            {
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Surname: {_surname}");

                Console.WriteLine("Marks:");
                foreach(double mark in _marks) Console.Write($"{mark}\t");
                Console.WriteLine();
                
                Console.WriteLine("Places:");
                foreach(double mark in _marks) Console.Write($"{mark}\t");
                Console.WriteLine();

                Console.WriteLine($"Top place: {_places.Min()}");
                Console.WriteLine($"TotalMark: {Math.Round(_marks.Sum(), 2)}");
                Console.WriteLine($"Result: {Score}");
                Console.WriteLine();
            }
            
            /*public static void PrintTable(Participant[] array)
            {
                Console.WriteLine("Name\tSurname\tScore\tTopPlace\tTotalMark");
                foreach (Participant p in array) Console.WriteLine($"{p.Name}\t{p.Surname}\t{p.Score}\t{p.Places.Min()}\t{Math.Round(p.Marks.Sum(), 2)}");
            }*/
        }
    }
}