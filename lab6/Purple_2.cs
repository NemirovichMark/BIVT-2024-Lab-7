using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6{
    public class Purple_2{
        public struct Participant{
            private const int tramplin = 120;
            private const int deafultPoints = 60;
            private const int extraPoints = 2;
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks{
                get{
                    if (_marks == null) return null;
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public int Result {
                get{
                if (_marks == null) return 0;
                int sum = 0;

                int maxI = 0, minI = 1;
                for (int i = 0; i < _marks.Length; i++){
                    if (_marks[i] > _marks[maxI]){
                        maxI = i;
                    }
                    if (_marks[i] < _marks[minI]){
                        minI = i;
                    }
                }
                
                for (int i = 0; i < _marks.Length; i++){
                    if (i != maxI && i != minI){
                        sum += _marks[i];
                    }
                }

                int points = deafultPoints;
                if (_distance >= tramplin)
                {
                    points += (_distance - tramplin) * extraPoints;
                }
                else
                {
                    points -= (tramplin - _distance) * extraPoints;
                    if (points < 0) points = 0;
                }
                sum += points;
                return sum;
                }
            }

            public Participant(string name, string surname){
                _name = name;
                _surname = surname;
                _marks = new int[5]{0, 0, 0, 0, 0};

            }

            public void Jump(int distance, int[] marks){
                if (marks == null || _marks == null) return;

                if (marks.Length != 5){
                    return;
                }

                for (int i = 0; i < marks.Length; i++){
                    if (marks[i] < 0 || marks[i] > 20){
                        return;
                    }
                }
                _distance = distance;
                Array.Copy(marks, _marks, marks.Length);
            }

            public static void Sort(Participant[] array){
                if (array == null) return;
                
                for (int i = 1; i < array.Length; i++){
                    int k = i, j = k - 1;
                    while (j >= 0){
                        if (array[j].Result < array[k].Result){
                            Participant tmp = array[k];
                            array[k] = array[j];
                            array[j] = tmp;
                        }
                        k = j;
                        j--;
                    }
                }
            }

            public void Print(){}
        }
    }
}