using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_1
    {
        public struct Participant
        {
            // Поля
            private string? _surname;
            private string? _group;
            private string? _coachSurname;
            private double _result;
            private static readonly double _standard;
            private static int _passedCount;

            // Статический конструктор
            static Participant()
            {
                _standard = 100;
                _passedCount = 0;
            }

            // Конструктор
            public Participant(string _surname, string _group, string _coachSurname)
            {
                this._surname = _surname is not null ? _surname : null;
                this._group = _group is not null ? _group : null;
                this._coachSurname = _coachSurname is not null ? _coachSurname : null;
                this._result = 0;
            }

            // Свойства
            public string? Surname => _surname is not null ? _surname : null;
            public string? Group => _group is not null ? _group : null;
            public string? Trainer => _coachSurname is not null ? _coachSurname : null;
            public double? Result => _result != 0 ? _result : 0;
            public static int? PassedTheStandard => _passedCount;
            public bool? HasPassed => _result <= _standard;

            // Методы
            public void Run(double result)
            {
                if (_result == 0)
                {
                    this._result = result;
                    if (result <= _standard)
                    {
                        _passedCount++;
                    }
                }
            }

            public void Print() { }

        }
    }


}

