using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;

            public int Result { get; private set; }
            
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[] marks = new int[_marks.Length];
                    Array.Copy(_marks, marks, _marks.Length);
                    return marks;
                }
            }
            
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
            }

            public void Jump(int distance, int[] marks)
            {
                if (marks == null || marks.Length != 5) return;

                _distance = distance;
                Array.Copy(marks, _marks, marks.Length);

                int points = 60 + (_distance - 120) * 2;
                if (points < 0) points = 0;
                Result += points + marks.Sum() - marks.Max() - marks.Min();
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1) return;
                Participant[] buffer = new Participant[array.Length];
                MergeSort(array, buffer, 0, array.Length - 1);
            }
            private static void MergeSort(Participant[] array, Participant[] buffer, int left, int right)
            {
                if (left < right)
                {
                    int mid = left + (right - left) / 2;
                    MergeSort(array, buffer, left, mid);
                    MergeSort(array, buffer, mid + 1, right);
                    Merge(array, buffer, left, mid, right);
                }
            }
            private static void Merge(Participant[] array, Participant[] buffer, int left, int mid, int right)
            {
                int i = left, j = mid + 1, k = left;
                while (i <= mid && j <= right)
                {
                    if (array[i].Result >= array[j].Result) buffer[k++] = array[i++];
                    else buffer[k++] = array[j++];
                }
                while (i <= mid) buffer[k++] = array[i++];
                while (j <= right) buffer[k++] = array[j++];
                for (i = left; i <= right; i++) array[i] = buffer[i];
            }
            
            public void Print()
            {
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Surname: {_surname}");
                Console.WriteLine($"Distance: {_distance}");
                Console.WriteLine("\nMarks:");
                foreach(double mark in _marks) Console.Write($"{mark}\t");
                Console.WriteLine();
                Console.WriteLine($"Result: {Result}\n");
            }
            
            /* public static void PrintTable(Participant[] array)
            {
                Console.WriteLine("Name\tSurname\tResult");
                foreach (Participant p in array) Console.WriteLine($"{p.Name}\t{p.Surname}\t{p.Result}");
            } */
        }
    }
}