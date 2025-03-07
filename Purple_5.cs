namespace Lab_7{

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
                switch (questionNumber){
                    case 1:
                    return responses.Count(r => r.Animal != null);

                    case 2:
                    return responses.Count(r => r.CharacterTrait != null);

                    case 3:
                    return responses.Count(r => r.Concept != null);

                    default:
                    return 0;
                }
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
                _Responses = [];
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
            topResponses[i] = $"{group.Answer}";
        }

        return topResponses;
    }

        public void Print()
            {
                Console.WriteLine($"Research: {Name}");
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine($"Top responses for Question {i}:");
                    string[] Top = GetTopResponses(i);
                    foreach (var element in Top)
                        Console.WriteLine(element);
                }
            }
        }

        public class Report{
            private Research[] _Researches;
            private static int _Counter;

            public Research[] Researches => _Researches;

            static Report(){
                _Counter = 1;
            }

            public Report(){
                _Researches = [];
            }

            public Research MakeResearch(){

                string Name = $"No_{_Counter++}_{DateTime.Now:MM}/{DateTime.Now:yy}";

                Research newResearch = new Research(Name);

                Array.Resize(ref _Researches, _Researches.Length + 1);
                _Researches[_Researches.Length - 1] = newResearch;

                return newResearch;
            }

            public (string, double)[] GetGeneralReport(int question){
                if (_Researches == null || _Researches.Length == 0)
                    return [];

                var allResponses = _Researches.SelectMany(r => r.Responses)
                                              .Where(r => !string.IsNullOrWhiteSpace(r.Animal) || 
                                              !string.IsNullOrWhiteSpace(r.CharacterTrait) || 
                                              !string.IsNullOrWhiteSpace(r.Concept))
                                              .ToArray();

                int total = allResponses.Length;
                if (total == 0)
                    return [];

                var topAnswers = _Researches.SelectMany(r => r.GetTopResponses(question))
                                            .Where(r => !string.IsNullOrWhiteSpace(r))
                                            .GroupBy(r => r)
                                            .Select(g => new { Answer = g.Key, Count = g.Count() })
                                            .OrderByDescending(g => g.Count)
                                            .ToArray();

                var result = new (string, double)[topAnswers.Length];
                for (int i = 0; i < topAnswers.Length; i++){
                    var answer = topAnswers[i];
                    double percentage = answer.Count / (double)total * 100;
                    result[i] = (answer.Answer, percentage);
                }

                return result;
            }
        }
    }
}             