using System;


namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            private string _name;
            private string _surname;
            private int _counter;

            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _counter;

            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _counter = 0;
            }

            public int CountVotes(Response[] responses)
            {
                if (responses == null) return 0;
                int cnt_votes = 0;
                foreach (var response in responses)
                {
                    if (response.Name == _name && response.Surname == _surname) cnt_votes++;
                }
                return cnt_votes;
            }

            public void Print()
            {
                Console.Write("{0,-20} {1,-20}", Name, Surname);


            }
        }
    }
}
