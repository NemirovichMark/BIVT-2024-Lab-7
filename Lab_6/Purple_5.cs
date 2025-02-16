using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Lab_6
{
    class Purple_5
    {
        public struct Response
        {
            private string _animal;
            private string _characterTrait;
            private string _concept;

            public string Animal => _animal;
            public string CharacterTrait => _characterTrait;
            public string Concept => _concept;

            public Response(string animal, string characterTrait, string concept)
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;
            }

            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null) return 0;

                switch (questionNumber)
                {
                    case 1:
                        return responses.Count(r => r.Animal != null && r.Animal.Length > 0);
                    case 2:
                        return responses.Count(r => r.CharacterTrait != null && r.CharacterTrait.Length > 0);
                    case 3:
                        return responses.Count(r => r.Concept != null && r.Concept.Length > 0);
                    default:
                        return 0;
                }
            }
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;

            public string Name => _name;
            public Response[] Responses => _responses;

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                if (answers == null) return;

                var responseAnimal = answers[0];
                var responseCharacterTrait = answers[1];
                var responseConcept = answers[2];

                var newResponse = new Response(responseAnimal, responseCharacterTrait, responseConcept);

                int n = _responses.Length;
                var newResponses = new Response[n + 1];
                Array.Copy(_responses, newResponses, n);
                newResponses[n] = newResponse;

                _responses = newResponses;
            }

            public string[] GetTopResponses(int question)
            {
                switch (question)
                {
                    case 1:
                        return _responses.GroupBy(r => r.Animal)
                                .OrderByDescending(r => r.Count())
                                .Take(5)
                                .Select(r => r.Key)
                                .ToArray();
                    case 2:
                        return _responses.GroupBy(r => r.CharacterTrait)
                                .OrderByDescending(r => r.Count())
                                .Take(5)
                                .Select(r => r.Key)
                                .ToArray();
                    case 3:
                        return _responses.GroupBy(r => r.Concept)
                                .OrderByDescending(r => r.Count())
                                .Take(5)
                                .Select(r => r.Key)
                                .ToArray();
                    default:
                        return new string[0];
                }
            }
        }
    }
}
