using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Purple_3
    {
        public struct Participant
        {
            private string _name, _surname;
            private double[] _marks;
            private int[] _places;
            private int _indexJudge;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    return (double[])_marks.Clone();
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null) return null;
                    return (int[])_places.Clone();
                }
            }
            public Participant(string name, string surname) {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _indexJudge = 0;
            }
            public void Evaluate(double result)
            {
                if (_indexJudge >= 7) return;
                if (_marks == null) return;
                _marks[_indexJudge++] = result;
            }
            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null) return;
                for (int i = 0; i<7; i++)
                {
                    //Array.Sort(array, (x, y) => x.Marks)
                }

            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                Array.Sort(array);
            }
        }
    }
}
