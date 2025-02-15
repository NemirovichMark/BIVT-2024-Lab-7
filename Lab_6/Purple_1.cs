using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
    class Purple_1 {
        public struct Participant {
            private string _name;
            private string _surname;
            private double[] _coefs;
            private double[,] _marks;
            public int _jumpsCount;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs => (double[])_coefs.Clone(); // shallow copy
            public double[,] Marks => (double[,])_marks.Clone();
            public double TotalScore {get; private set; }

            public Participant(string name, string surname) {
                _name = name;
                _surname = surname;
                _coefs = new double[4] {2.5, 2.5, 2.5, 2.5};
                _marks = new double[4, 7];
            }

            public void SetCriterias(double[] coefs) {
                if (_coefs == null) 
                    return;

                for (int i = 0; i < 4; i++) 
                    _coefs[i] = coefs[i];
            }

            public void Jump(int[] marks) {
                if (marks == null || _jumpsCount >= 4) 
                    return;

                for (int j = 0; j < 7; j++) 
                    _marks[_jumpsCount, j] = marks[j];
                
                TotalScore += (marks.Sum() - marks.Min() - marks.Max()) * _coefs[_jumpsCount++];
            }

            public static void Sort(Participant[] array) {
                Array.Sort(array, (a, b) => b.TotalScore.CompareTo(a.TotalScore));
            }
        }
    }
}