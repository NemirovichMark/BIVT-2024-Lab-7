using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
    public class Purple_1 {
        public struct Participant {
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _jumpsCount;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs => (_coefs == null) ? _coefs : (double[])_coefs.Clone(); // shallow copy for safety
            public int[,] Marks => (_marks == null) ? _marks : (int[,])_marks.Clone();
            public double TotalScore {get; private set; }

            public Participant(string name, string surname) {
                _name = name;
                _surname = surname;
                _coefs = new double[4] {2.5, 2.5, 2.5, 2.5};
                _marks = new int[4, 7];
            }

            public void SetCriterias(double[] coefs) {
                if (_coefs == null || coefs == null) 
                    return;
    
                for (int i = 0; i < 4; i++) 
                    _coefs[i] = coefs[i];
            }

            public void Jump(int[] marks) {
                if (_marks == null || _coefs == null || marks == null || _jumpsCount >= 4) 
                    return;

                for (int j = 0; j < 7; j++) 
                    _marks[_jumpsCount, j] = marks[j];
                
                TotalScore += (marks.Sum() - marks.Min() - marks.Max()) * _coefs[_jumpsCount++];
            }

            public static void Sort(Participant[] array) {
                if (array == null) return;

                var sortedArray = array.OrderByDescending(x => x.TotalScore).ToArray(); // stable sort
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

            private void PrintMatrix<T>(T[,] matrix, string label) {
                if (matrix == null) {
                    Console.WriteLine($"{label} N/A");
                    return;
                }

                Console.WriteLine(label);
                for (int i = 0; i < matrix.GetLength(0); i++) {
                    for (int j = 0; j < matrix.GetLength(1); j++) {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            public void Print() {
                Console.WriteLine($"Name: {_name ?? "N/A"}");
                Console.WriteLine($"Surname: {_surname ?? "N/A"}");
                PrintArray(_coefs, "Coefs:");
                PrintMatrix(_marks, "   :");
                Console.WriteLine($"Total Score: {TotalScore}");
            }
        }
    }
}