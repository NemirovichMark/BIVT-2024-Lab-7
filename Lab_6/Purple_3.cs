using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
    public class Purple_3 {
        public struct Participant {
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _markCount;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks => (_marks == null) ? _marks : (double[])_marks.Clone(); // shallow copy for safety
            public int[] Places => (_places == null) ? _places : (int[])_places.Clone();
            public int Score => (_places == null) ? 0 : _places.Sum(); 

            

            public Participant(string name, string surname) { 
                _name = name;  
                _surname = surname;

                _marks = new double[7];
                _places = new int[7];
            }

            public void Evaluate(double result) {
                if (_markCount >= 7 || _marks == null) return;

                _marks[_markCount++] = result;
            }

            public static void SetPlaces(Participant[] participants) {
                if (participants == null) return;
                
                for (int judge = 0; judge < 7; judge++) {
                    var sortedParticipants = participants.Where(x => x.Marks != null && x.Places != null)
                                                         .OrderByDescending(x => x.Marks[judge]).ToArray(); // stable sort

                    for (int p = 0; p < sortedParticipants.Length; p++) 
                        sortedParticipants[p]._places[judge] = p + 1;

                    if (judge == 6) {
                        sortedParticipants = sortedParticipants.Concat(
                                            participants.Where(x => x.Marks == null)
                                            ).ToArray();
                        Array.Copy(sortedParticipants, participants, participants.Length);
                    }
                }

            }

            public static void Sort(Participant[] array) {
                if (array == null) return;

                var sortedArray = array.Where(x => x.Marks != null && x.Places != null)
                                    .OrderBy(x => x.Score).ThenBy(x => x.Places.Min()).ThenByDescending(x => x.Marks.Sum()).ToArray();
                    
                sortedArray = sortedArray.Concat(
                                array.Where(x => x.Marks == null || x.Places == null)
                                ).ToArray();

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
                PrintArray(_marks, "Marks:");
                PrintArray(_places, "Places:");
                Console.WriteLine($"Score: {Score}");
            }

        }
    }
}