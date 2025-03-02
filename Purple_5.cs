using System;
using System.Collections.Generic;
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

            public Response(string answer1, string answer2, string answer3)
            {
                _animal = answer1;
                _characterTrait = answer2;
                _concept = answer3;
            }

            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null) return default(int);
                int counter = 0;
                switch (questionNumber) {
                    case 1:
                        foreach (var response in responses)
                            if (response.Animal != null && response.Animal == this.Animal)
                                counter++;
                        break;
                    case 2:
                        foreach (var response in responses)
                            if (response.CharacterTrait != null && response.CharacterTrait == this.CharacterTrait)
                                counter++;
                        break;
                    case 3:
                        foreach (var response in responses)
                            if (response.Concept != null && response.Concept == this.Concept)
                                counter++;
                        break;
                    default:
                        return default(int);
                }
                return counter;
            }
            public void Print()
            {
                Console.WriteLine("Animal: " + _animal);
                Console.WriteLine("Trait: " + _characterTrait);
                Console.WriteLine("Concept: " + _concept);
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
                    if (_responses == null) return default(Response[]);
                    return _responses;
                }
            }

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                if (answers == null || _responses == null) return;
                
                Array.Resize(ref _responses, _responses.Length + 1);

                string answer1 = null;
                string answer2 = null;
                string answer3 = null;

                switch (answers.Length)
                {
                    case 0:
                        return;
                    case 1:
                        answer1 = answers[0];
                        break;
                    case 2:
                        answer1 = answers[0];
                        answer2 = answers[1];
                        break;
                    default:
                        answer1 = answers[0];
                        answer2 = answers[1];
                        answer3 = answers[2];
                        break;
                }

                _responses[_responses.Length - 1] = new Response(answer1, answer2, answer3);
            }

            public string[] GetTopResponses(int question)
            {
                if (_responses == null) return null;

                int[] frequency = new int[_responses.Length];
                int[] f = new int[0];
                string[] unique = new string[0];
                string[] responses = new string[0];

                switch (question)
                {
                    case 1:     //Animal
                        responses = _responses.Select(x => x.Animal).ToArray();
                        unique = responses.Distinct().ToArray();
                        Array.Resize(ref f, unique.Length);
                        for (int i = 0; i < _responses.Length; i++)
                        {
                            frequency[i] = _responses[i].CountVotes(_responses, 1);
                        }
                        for (int i = 0; i < f.Length; i++)
                        {
                            f[i] = frequency[Array.IndexOf(responses, unique[i])];
                        }
                        SortFrequency(unique, f);
                        return unique.Where(x => x != null).Take(5).ToArray();
                    case 2:     //Character Trait
                        responses = _responses.Select(x => x.CharacterTrait).ToArray();
                        unique = responses.Distinct().ToArray();
                        Array.Resize(ref f, unique.Length);
                        for (int i = 0; i < _responses.Length; i++)
                        {
                            frequency[i] = _responses[i].CountVotes(_responses, 2);
                        }
                        for (int i = 0; i < f.Length; i++)
                        {
                            f[i] = frequency[Array.IndexOf(responses, unique[i])];
                        }
                        SortFrequency(unique, f);
                        return unique.Where(x => x != null).Take(5).ToArray();
                    case 3:     //Concept
                        responses = _responses.Select(x => x.Concept).ToArray();
                        unique = responses.Distinct().ToArray();
                        Array.Resize(ref f, unique.Length);
                        for (int i = 0; i < _responses.Length; i++)
                        {
                            frequency[i] = _responses[i].CountVotes(_responses, 3);
                        }
                        for (int i = 0; i < f.Length; i++)
                        {
                            f[i] = frequency[Array.IndexOf(responses, unique[i])];
                        }
                        SortFrequency(unique, f);
                        return unique.Where(x => x != null).Take(5).ToArray();
                    default:
                        return null;
                }
            }
            private void SortFrequency(Response[] answers, int[] array)
            {
                if (array.Length <= 1 || answers == null) return;

                for (int i = 1, j = 2; i < array.Length;)
                {
                    if (i == 0 || array[i - 1] >= array[i])
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        var temp = array[i];
                        array[i] = array[i-1];
                        array[i-1] = temp;
                        var a = answers[i];
                        answers[i] = answers[i - 1];
                        answers[i-1] = a;
                        i--;
                    }
                }
            }
            private void SortFrequency(string[] answers, int[] array)
            {
                if (array.Length <= 1 || answers == null) return;

                for (int i = 1, j = 2; i < array.Length;)
                {
                    if (i == 0 || array[i - 1] >= array[i])
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        var temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        var a = answers[i];
                        answers[i] = answers[i - 1];
                        answers[i - 1] = a;
                        i--;
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine("Name: " + _name);
                Console.WriteLine("Responses:");
                int i = 1;

                foreach (var response in _responses)
                {
                    Console.WriteLine($"{i++}: {response.Animal,10} {response.CharacterTrait,10} {response.Concept,10}");
                }
            }
        }
    }
}
