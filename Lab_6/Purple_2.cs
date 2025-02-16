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
            public int[] Marks => (int[])_marks.Clone(); // shallow copy for safety
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
                                    + (distance - 120) * 2);            
            }

            public static void Sort(Participant[] array) {
                array = array.OrderByDescending(x => x.Result).ToArray(); // stable sort
            }
        }
    }
}