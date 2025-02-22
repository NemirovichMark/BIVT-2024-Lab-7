using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_5
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
                        return responses.Count(x => x._animal != null);
                    case 2:
                        return responses.Count(x => x._characterTrait != null);
                    case 3:
                        return responses.Count(x => x._concept != null);
                    default:
                        return 0;
                }
            }

            public void Print()
            {
                Console.WriteLine($"Животное: {_animal}");
                Console.WriteLine($"Черта характера: {_characterTrait}");
                Console.WriteLine($"Предмет: {_concept}");
                Console.WriteLine();
            }
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;

            public string Name => _name;

            public Response[] Responses
            {
                get
                {
                    if (_responses == null) return null;

                    var copy = new Response[_responses.Length];
                    Array.Copy(_responses, copy, _responses.Length);
                    return copy;
                }
            }

            public Research(string name)
            {
                _name = name != null ? name : "-";
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                if (answers == null || answers.Length != 3 || _responses == null) return;

                Array.Resize(ref _responses, _responses.Length + 1);
                _responses[_responses.Length - 1] = new Response(answers[0], answers[1], answers[2]);
            }

            public string[] GetTopResponses(int question)
            {
                if (question == null || _responses == null || question < 1 || question > 3 ||
                    _responses.Length == 0) return null;

                string[] keys = new string[0];
                int[] values = new int[0];
                foreach (var response in _responses)
                {
                    string answer = GetAnswerByQuestion(question, response);
                    if (answer != "-") AddAnswerToDict(ref keys, ref values, answer);
                }

                SortAnswersDict(keys, values);
                string[] topResponses = new string[keys.Length >= 5 ? 5 : keys.Length];
                Array.Copy(keys, topResponses, topResponses.Length);

                return topResponses;
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {_name}");
                Console.WriteLine();

                if (_responses == null) return;
                Console.WriteLine($"Ответы:");
                foreach (var response in _responses)
                {
                    response.Print();
                }

                Console.WriteLine();
            }

            private string GetAnswerByQuestion(int question, Response response)
            {
                switch (question)
                {
                    case 1:
                        return response.Animal;
                    case 2:
                        return response.CharacterTrait;
                    case 3:
                        return response.Concept;
                    default:
                        return "";
                }
            }

            private void AddAnswerToDict(ref string[] keys, ref int[] values, string answer)
            {
                int index = Array.FindIndex(keys, x => x == answer);
                if (index == -1)
                {
                    Array.Resize(ref keys, keys.Length + 1);
                    keys[keys.Length - 1] = answer;
                    Array.Resize(ref values, values.Length + 1);
                    values[values.Length - 1] = 1;
                }
                else
                {
                    values[index]++;
                }
            }

            private void SortAnswersDict(string[] keys, int[] values)
            {
                int n = keys.Length, i = 1, j = 2;
                while (i < n)
                {
                    if (i == 0 || values[i - 1] >= values[i])
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        (keys[i - 1], keys[i]) = (keys[i], keys[i - 1]);
                        (values[i - 1], values[i]) = (values[i], values[i - 1]);
                        i--;
                    }
                }
            }
        }
    }
}