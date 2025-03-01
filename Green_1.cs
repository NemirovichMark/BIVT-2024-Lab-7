using System;
using System.Linq;


namespace Lab_6
{
    public class Green_1
    {
        public struct Participant
        {
            
            private string _surname;
            private string _group;
            private string _trainer;
            private double _result;

            
            private static readonly double Standard; 
            private static int PassedTheStandardCount; 

            
            static Participant()
            {
                Standard = 100;
                PassedTheStandardCount = 0;
            }

            
            public Participant(string surname, string group, string trainer)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
                _result = 0; 
            }


            public string Surname
            {
                get 
                {
                    if (_surname == null) return default;
                    return _surname; 
                }
            }

            public string Group
            {
                get
                {
                    if (_group == null) return default;
                    return _group;
                }
            }

            public string Trainer
            {
                get
                {
                    if (_trainer == null) return default;
                    return _trainer;
                }
            }

            public double Result
            {
                get 
                {
                    return _result; 
                }
            }


            public static int PassedTheStandard => PassedTheStandardCount;

            
            public bool HasPassed => (_result > 0 && _result <= Standard); 

            
            public void Run(double result)
            {
                if (_result == 0) 
                {
                    _result = result;
                    if (HasPassed) 
                    {
                        PassedTheStandardCount++;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine(PassedTheStandard);
                Console.WriteLine($"{Surname} {Group} {Trainer} {Result} {HasPassed}");
            }
        }

    }
}
