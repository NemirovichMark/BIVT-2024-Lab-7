using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BIVT_2024_Lab_6
{
    public class Purple_5
    {
        public struct Response
        {
            public string _animal;
            public string _characterTrait;
            public string _concept;

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
                        if (responses[i].Animal != "")
                            count++;
                        break;
                    case 2:
                        if (responses[i].CharacterTrait != "")
                            count++;
                        break;
                    case 3:
                        if (responses[i].Concept != "")
                            count++;
                        break;
                }
            }

            return count;
        }

        public struct Research
        {
            public string _name;
            public Response[] _responses;

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
                    return _responses;
                }
            }

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }
        }
    }
}
