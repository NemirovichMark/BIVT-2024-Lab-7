using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class Purple_5
    {
        public struct Response
        {
            private string _animal;
            private string _characterTrait;
            private string _concept;

            public string Animal
            {
                get
                {
                    return _animal;
                }
            }

            public string CharacterTrait
            {
                get
                {
                    return _characterTrait;
                }
            }

            public string Concept
            {
                get
                {
                    return _concept;
                }
            }

            public Response(string animal, string characterTrait, string concept)
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;
            }

            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (questionNumber < 1 || questionNumber > 3) return 0;
                int count = 0;
                for (int i = 0; i < responses.Length; i++)
                {
                    switch (questionNumber)
                    {
                        case 1:
                            if (responses[i].Animal != null)
                                count++;
                            break;
                        case 2:
                            if (responses[i].CharacterTrait != null)
                                count++;
                            break;
                        case 3:
                            if (responses[i].Concept != null)
                                count++;
                            break;
                    }
                }

                return count;
            }
            
            public void Print()
            {
                Console.WriteLine($"{_animal} ${_characterTrait} ${_concept}");
            }
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;

            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public Response[] Responses
            {
                get
                {
                    if (_responses is null) return null;
                    Response[] responsesCopy = new Response[_responses.Length];
                    Array.Copy(_responses, responsesCopy, _responses.Length);
                    return responsesCopy;
                }
            }

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                if (answers == null || answers.Length != 3 || _responses == null) 
                    return;

                Response response = new Response(answers[0], answers[1], answers[2]);
                Array.Resize(ref _responses, _responses.Length + 1);
                _responses[_responses.Length - 1] = response;
            }

            public string[] GetTopResponses(int question)
            {
                if (question < 1 || question > 3 || _responses == null)
                {
                    return null;
                }

                string[] responses = new string[_responses.Length];

                for (int i = 0; i < _responses.Length; i++)
                {
                    switch (question) {
                        case 1:
                            responses[i] = _responses[i].Animal;
                            break;
                        case 2:
                            responses[i] = _responses[i].CharacterTrait;
                            break;
                        case 3:
                            responses[i] = _responses[i].Concept;
                            break;
                    };
                }

                var topResponses = responses
                .Where(x => x != null)
                .GroupBy(word => word) 
                .OrderByDescending(group => group.Count())
                .Take(5) 
                .Select(group => group.Key)  
                .ToArray();

                return topResponses;

            }

            public void Print()
            {
                Console.WriteLine(_name);
                if (_responses is null)
                    return;
                for (int i = 0; i < _responses.GetLength(0); i++)
                {
                    _responses[i].Print();  
                }
            }
        }
    }
}
