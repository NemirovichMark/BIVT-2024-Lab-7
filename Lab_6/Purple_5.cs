using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace Lab_6{

    public class Purple_5
    {
        public struct Response{
            private string _Animal;
            private string _CharacterTrait;
            private string _Concept;

            public string Animal => _Animal;
            public string CharacterTrait => _CharacterTrait;
            public string Concept => _Concept;

            public Response(string animal, string characterTrait, string concept){
                _Animal = animal;
                _CharacterTrait = characterTrait;
                _Concept = concept;
            }

            public int CountVotes(Response[] responses, int questionNumber){
                if (responses == null) return 0;
                string answer = "";
                int cnt = 0;
                foreach(var answers in responses){
                    switch (questionNumber){
                        case 1:
                        answer = answers._Animal;
                        break;
                        case 2:
                        answer = answers._CharacterTrait;
                        break;
                        case 3:
                        answer = answers._Concept;
                        break;
                    }
                    cnt =  answer == "" || answer == null ? cnt : cnt++;
                }
                return cnt;
            }
            public void Print(){}
        }
        public struct Research{
            private string _Name;
            private Response[] _Responses;

            public string Name => _Name;
            public Response[] Responses => _Responses;

            public Research(string name){
                _Name = name;
                _Responses = new Response[0];
            }

            public void Add(string[] answers){
                if (_Responses == null || answers == null) return;

                Response newResponse = new Response(answers[0], answers[1], answers[2]);
                Array.Resize(ref _Responses, _Responses.Length + 1);
                _Responses[_Responses.Length-1] = newResponse;

            }
      public string[] GetTopResponses(int question) {
        if (_Responses == null || !_Responses.Any()) return new string[0];
        string[] answers = question switch
        {
            1 => _Responses.Where(r => r.Animal != null).Select(r => r.Animal).ToArray(),
            2 => _Responses.Where(r => r.CharacterTrait != null).Select(r => r.CharacterTrait).ToArray(),
            3 => _Responses.Where(r => r.Concept != null).Select(r => r.Concept).ToArray(),
            _ =>  new string[0]
        };

        answers = answers.Where(a => !string.IsNullOrWhiteSpace(a)).ToArray();

        var answerGroups = answers.GroupBy(a => a).Select(g => new { Answer = g.Key, Count = g.Count() }).OrderByDescending(g => g.Count).Take(5).ToArray();

        int totalResponses = answers.Length;

        string[] topResponses = new string[answerGroups.Length];

        for (int i = 0; i < answerGroups.Length; i++){
            var group = answerGroups[i];
            double percentage = (double) group.Count / totalResponses * 100;
            topResponses[i] = $"{group.Answer}: {group.Count}";
        }

        return topResponses;
    }

        public void Print(){
            for (int i = 1; i <= 3; i++){
                string[] Top = GetTopResponses(i);
                Console.WriteLine();
                foreach(var element in Top)
                    Console.WriteLine(element );
                }
            }
        }
    }
}             