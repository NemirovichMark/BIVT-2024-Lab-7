using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6{
    public class Purple_1{
        public struct Participant{
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _jumpCount;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs{
                get{
                    if (_coefs == null) return null;

                    double[] copy = new double[_coefs.Length];
                    for (int i = 0; i < _coefs.Length; i++){
                        copy[i] = _coefs[i];
                    }
                    
                    return copy;
                }
            }
            public int[,] Marks{
                get{
                    if (_marks == null) return null;

                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < _marks.GetLength(0); i++){
                        for (int j = 0; j < _marks.GetLength(1); j++){
                            copy[i, j] = _marks[i, j];
                        }
                    }
                    return copy;
                }
            }
            public double TotalScore{
                get{
                    if (_marks == null || _coefs == null) return 0;

                    double total = 0;
                    for (int jump = 0; jump < _marks.GetLength(0); jump++){
                        double[] grades = new double[_marks.GetLength(1)];
                        for (int judje = 0; judje < _marks.GetLength(1); judje++){
                            grades[judje] = _marks[jump, judje];
                        }

                        Array.Sort(grades);
                        double sum = 0;
                        for (int i = 1; i < grades.Length - 1; i++){
                            sum += grades[i];
                        }
                        total += sum * _coefs[jump];
                    }
                    return total;
                }
            }
        
            public Participant(string name, string surname){
                _name = name;
                _surname = surname;
                _coefs = new double[4]{2.5, 2.5, 2.5, 2.5};
                _marks = new int[4,7];   
            }
            
            public void SetCriterias(double[] coefs){
                if (coefs == null || _coefs == null) return;
                if (coefs.Length != 4) return;
                Array.Copy(coefs, _coefs, coefs.Length);
            }

            public void Jump(int[] marks){
                if (marks == null || _marks == null) return;

                if (_jumpCount >= 4){
                    return;
                }

                if (marks.Length > 7){
                    for (int j = 0; j < 7; j++){
                    _marks[_jumpCount, j] = marks[j];
                }
                }
                else{
                for (int j = 0; j < marks.Length; j++){
                    _marks[_jumpCount, j] = marks[j];
                }
                }
                _jumpCount++;
            }

            public static void Sort(Participant[] array){
                if (array == null) return;
                
                for (int i = 1; i < array.Length; i++){
                    int k = i, j = k - 1;
                    while(j >= 0){
                        if (array[j].TotalScore < array[k].TotalScore){
                            Participant temp = array[k];
                            array[k] = array[j];
                            array[j] = temp;
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