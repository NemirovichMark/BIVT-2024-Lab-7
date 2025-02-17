using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
    class Purple_2 {
        public struct Participant {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks => (_marks == null) ? _marks : (int[])_marks.Clone(); // shallow copy for safety
            public int Result {get; private set; }

            public Participant(string name, string surname) {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }

            public void Jump(int distance, int[] marks) {
                if (_marks == null || marks == null)
                    return;

                for (int i = 0; i < 5; i++) 
                    _marks[i] = marks[i];

                Result = Math.Max(0, marks.Sum() - marks.Min() - marks.Max() 
                                    + 60 + (distance - 120) * 2);            
            }

            public static void Sort(Participant[] array) {
                var sortedArray = array.OrderByDescending(x => x.Result).ToArray(); // stable sort
                Array.Copy(sortedArray, array, array.Length);
            }

            private void PrintArray<T>(T[] array, string label) {
                Console.Write(label + " ");
                if (array == null) {
                    Console.WriteLine("N/A");
                    return;
                }
                
                foreach (var element in array)
                    Console.Write(element + " ");
                Console.WriteLine();
            }

            public void Print() {
                Console.WriteLine($"Name: {_name ?? "N/A"}");
                Console.WriteLine($"Surname: {_surname ?? "N/A"}");
                Console.WriteLine($"Distance: {_distance}");
                PrintArray(_marks, "Marks:");
            }
        }
    }
}