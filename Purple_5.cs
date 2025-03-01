using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Lab_6.Purple_5;

namespace Lab_6
{
    public class Purple_5
    {
        public struct Response
        {
            private string _animal, _characterTrait, _concept;

            public Response(string animal, string trait, string concept)
            {
                _animal = animal;
                _characterTrait = trait;
                _concept = concept;
            }

            public string Animal { get { return _animal; } }
            public string CharacterTrait { get { return _characterTrait; } }
            public string Concept { get { return _concept; } }
            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (questionNumber < 0 || questionNumber > 3)
                {
                    return 0;
                }
                int ans = 0;
                foreach (Response response in responses)
                {
                    switch (questionNumber)
                    {
                        case 1:
                            ans += ((response.Animal == "" || response.Animal == null) ? 0 : 1);
                            break;
                        case 2:
                            ans += ((response.CharacterTrait == "" || response.CharacterTrait == null) ? 0 : 1);
                            break;
                        case 3:
                            ans += ((response.Concept == "" || response.Concept == null) ? 0 : 1);
                            break;
                    }
                }
                return ans;
            }
            public void Print()
            {
                Console.WriteLine("{0}, {1}, {2}", _animal, _characterTrait, _concept);
            }

        }
        public struct Research{
            string _name;
            Response[] _responce;

            public string Name { get { return _name; } }
            public Response[] Responses { get { return (Response[])_responce.Clone(); } }
            public Research(string name)
            {
                _name = name;
                _responce = new Response[0];
            }
            public void Add(string[] answers)
            {
                if (answers == null || answers.Length != 3 || _responce == null) return;
                Response a = new Response(answers[0], answers[1], answers[2]);
                Array.Resize(ref _responce, _responce.Length + 1);
                _responce[_responce.Length - 1] = a;
            }
           
            public string[] GetTopResponses(int question)
            {
                if (_responce == null) return null;
                string[] resp = new string[_responce.Length];
                for (int i = 0; i<_responce.Length; i++)
                {
                    switch (question)
                    {
                        case 0:
                            resp[i] = _responce[i].Animal;
                            break;
                        case 1:
                            resp[i] = _responce[i].CharacterTrait;
                            break;
                        case 2:
                            resp[i] = _responce[i].Concept;
                            break;
                    }
                }

                var top = resp
                .Where(x => x != null)
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Take(5)
                .Select(g => g.Key)
                .ToArray();

                return top;
            }
            public void Print()
            {
                Console.WriteLine(_name);
                if (_responce is null)
                    return;
                for (int i = 0; i < _responce.GetLength(0); i++)
                {
                    _responce[i].Print();
                }
            }
        }

    }
}
