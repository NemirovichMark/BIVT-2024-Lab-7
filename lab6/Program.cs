using System;
using System.Linq;

namespace Lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Purple_1.Participant[] participants = new Purple_1.Participant[]
        {
            new Purple_1.Participant("Иван", "Иванов"),
            new Purple_1.Participant("Петр", "Петров"),
            new Purple_1.Participant("Сергей", "Сергеев")
        };

        participants[0].SetCriterias(new double[] { 3.0, 3.2, 3.1, 3.3 });
        participants[1].SetCriterias(new double[] { 2.8, 3.0, 3.2, 3.1 });
        participants[2].SetCriterias(new double[] { 3.1, 3.0, 2.9, 3.2 });

        participants[0].Jump(new int[] { 5, 6, 5, 4, 5, 6, 5 }); 
        participants[0].Jump(new int[] { 6, 6, 5, 5, 6, 6, 5 });
        participants[0].Jump(new int[] { 5, 5, 4, 5, 5, 5, 4 });
        participants[0].Jump(new int[] { 6, 6, 6, 5, 6, 6, 5 });

        participants[1].Jump(new int[] { 4, 5, 4, 5, 4, 5, 4 });
        participants[1].Jump(new int[] { 5, 5, 5, 5, 5, 5, 5 });
        participants[1].Jump(new int[] { 6, 6, 6, 6, 6, 6, 6 });
        participants[1].Jump(new int[] { 5, 5, 5, 5, 5, 5, 5 });

        participants[2].Jump(new int[] { 6, 6, 6, 6, 6, 6, 6 });
        participants[2].Jump(new int[] { 5, 5, 5, 5, 5, 5, 5 });
        participants[2].Jump(new int[] { 4, 4, 4, 4, 4, 4, 4 });
        participants[2].Jump(new int[] { 3, 3, 3, 3, 3, 3, 3 });

        Purple_1.Participant.Sort(participants);

        System.Console.WriteLine("Purple1");

        Console.WriteLine("Итоговая таблица:");
        for (int i = 1; i <= participants.Length; i++)
        {
            Console.WriteLine($"{participants[i-1].Surname} {participants[i-1].Name}: " +
                $"Итоговый результат: {i}. {participants[i-1].TotalScore:F2}");
        }
        System.Console.WriteLine();

        System.Console.WriteLine("Purple2");
        Purple_2.Participant p1 = new Purple_2.Participant("Vadim1", "Shubin");
        p1.Jump(120, new int[] { 1, 1, 1, 1, 1 });
        Purple_2.Participant p2 = new Purple_2.Participant("Vadim2", "Shubin");
        p2.Jump(130, new int[] { 1, 1, 1, 1, 1 });
        Purple_2.Participant p3 = new Purple_2.Participant("Vadim3", "Shubin");
        p3.Jump(119, new int[] { 1, 1, 1, 1, 1 });

        Purple_2.Participant[] participantsP2 = new Purple_2.Participant[] { p1, p2, p3 };

        Console.WriteLine("До сортировки:");
        foreach (Purple_2.Participant member in participantsP2)
        {
            Console.WriteLine($"{member.Name} - {member.Result}");
        }

        Purple_2.Participant.Sort(participantsP2);

        Console.WriteLine("\nПосле сортировки:");
        foreach (Purple_2.Participant member in participantsP2)
        {
            Console.WriteLine($"{member.Name} - {member.Result}");
        }
        System.Console.WriteLine();

        System.Console.WriteLine("Purple3");
        Purple_3.Participant[] participants1 = new Purple_3.Participant[]
        {
            new Purple_3.Participant("Иван", "Иванов"),
            new Purple_3.Participant("Петр", "Петров"),
            new Purple_3.Participant("Сергей", "Сергеев"),
            new Purple_3.Participant("Алексей", "Алексеев")
        };

        participants1[0].Evaluate(5.5);
        participants1[0].Evaluate(6.0);
        participants1[0].Evaluate(5.0);
        participants1[0].Evaluate(4.5);
        participants1[0].Evaluate(5.0);
        participants1[0].Evaluate(6.0);
        participants1[0].Evaluate(5.5);

        participants1[1].Evaluate(6.0);
        participants1[1].Evaluate(5.5);
        participants1[1].Evaluate(5.5);
        participants1[1].Evaluate(5.0);
        participants1[1].Evaluate(5.5);
        participants1[1].Evaluate(6.0);
        participants1[1].Evaluate(5.0);

        participants1[2].Evaluate(4.5);
        participants1[2].Evaluate(5.0);
        participants1[2].Evaluate(4.0);
        participants1[2].Evaluate(5.5);
        participants1[2].Evaluate(4.5);
        participants1[2].Evaluate(5.0);
        participants1[2].Evaluate(4.0);

        participants1[3].Evaluate(5.5);
        participants1[3].Evaluate(6.0);
        participants1[3].Evaluate(5.0);
        participants1[3].Evaluate(4.5);
        participants1[3].Evaluate(5.0);
        participants1[3].Evaluate(6.0);
        participants1[3].Evaluate(5.5);

        Purple_3.Participant.SetPlaces(participants1);

        Console.WriteLine("Результаты соревнований:");
        foreach (var participant in participants1)
        {
            Console.WriteLine($"{participant.Surname} {participant.Name}: " +
                $"Оценки: {string.Join(", ", participant.Marks), 10}, " +
                $"Места: {string.Join(", ", participant.Places), 10}, " +
                $"Сумма мест: {participant.Score}");
        }


        Console.WriteLine("До сортировки:");
        foreach (var participant in participants1)
        {
            Console.WriteLine($"{participant.Surname} {participant.Name}: " +
                $"Сумма мест: {participant.Score}, " +
                $"Наивысшее место: {participant.Places.Min()}, " +
                $"Сумма очков: {participant.Marks.Sum()}");
        }

        Purple_3.Participant.Sort(participants1);

        Console.WriteLine("\nПосле сортировки:");
        foreach (var participant in participants1)
        {
            Console.WriteLine($"{participant.Surname} {participant.Name}: " +
                $"Сумма мест: {participant.Score}, " +
                $"Наивысшее место: {participant.Places.Min()}, " +
                $"Сумма очков: {participant.Marks.Sum()}");
        }
        System.Console.WriteLine();

        //4
        System.Console.WriteLine("Purple4");
        Purple_4.Sportsman sportsman1 = new Purple_4.Sportsman("Иван", "Иванов");
        sportsman1.Run(28.7);
        Purple_4.Sportsman sportsman2 = new Purple_4.Sportsman("Петр", "Петров");
        sportsman2.Run(30.5);
        Purple_4.Sportsman[] list = new Purple_4.Sportsman[2]{sportsman1, sportsman2};
        Purple_4.Group group1 = new Purple_4.Group("Группа 1");
        // group1.Add(sportsman1);
        // group1.Add(sportsman2);
        group1.Add(list);
        group1.Sort();

        Purple_4.Sportsman sportsman3 = new Purple_4.Sportsman("Сергей", "Сергеев");
        sportsman3.Run(29.8);
        Purple_4.Sportsman sportsman4 = new Purple_4.Sportsman("Алексей", "Алексеев");
        sportsman4.Run(27.3);

        Purple_4.Group group2 = new Purple_4.Group("Группа 2");
        group2.Add(sportsman3);
        group2.Add(sportsman4);
        group2.Sort();

        Purple_4.Group finalGroup = Purple_4.Group.Merge(group1, group2);

        Console.WriteLine($"Группа: {finalGroup.Name}");
        foreach (var sportsman in finalGroup.Sportsmen)
        {
            Console.WriteLine($"{sportsman.Surname} {sportsman.Name}: {sportsman.Time} сек");
        }
        System.Console.WriteLine();

        //5
        System.Console.WriteLine("Purple5");
        Purple_5.Research research = new Purple_5.Research("Опрос о Японии");
        research.Add(new string[] { "Тануки", "", "" });
        research.Add(new string[] { "Кошка", "Амбициозность", "Аниме" });
        research.Add(new string[] { "Серау", "Скромность", "Фудзияма" });
        research.Add(new string[] { "Коала", "Внимательность", "Кимоно" });
        research.Add(new string[] { "Коала", "Целеустремленность", "Самурай" });
        research.Add(new string[] { "Панда", "Проницательность", "Манга" });
        research.Add(new string[] { "Серау", "Скромность", "Суши" });
        research.Add(new string[] { "Макака", "Амбициозность", "" });
        research.Add(new string[] { "Сима энага", "Внимательность", "Фудзияма" });
        research.Add(new string[] { "Панда", "Уважительность", "Фудзияма" });
        research.Add(new string[] { "Тануки", "Скромность", "Манга" });
        research.Add(new string[] { "Тануки", "Проницательность", "Сакура" });
        research.Add(new string[] { "Тануки", "Целеустремленность", "Кимоно" });
        research.Add(new string[] { "Кошка", "Дружелюбность", "Манга" });
        research.Add(new string[] { "Тануки", "Проницательность", "" });
        research.Add(new string[] { "Сима энага", "Проницательность", "Самурай" });
        research.Add(new string[] { "Кошка", "Целеустремленность", "" });
        research.Add(new string[] { "Сима энага", "Внимательность", "Фудзияма" });
        research.Add(new string[] { "", "Амбициозность", "Сакура" });
        research.Add(new string[] { "Коала", "Проницательность", "Самурай" });
    //     Purple_5.Response[] responses = new Purple_5.Response[]
    // {
    //     new Purple_5.Response("Сакура", "Трудолюбие", "Самурай"),
    //     new Purple_5.Response("", "Вежливость", "Самурай"),
    //     new Purple_5.Response("Кошка", "Трудолюбие", "Чай"),
    //     new Purple_5.Response("Сакура", "", "Самурай"), 
    //     new Purple_5.Response("Кошка", "Вежливость", ""),
    //     new Purple_5.Response("Сакура", "Трудолюбие", "Самурай")
    // };
    // Purple_5.Research research = new Purple_5.Research("Опрос о Японии");
    // foreach (var response in responses)
    // {
    //     research.Add(new string[]{response.Animal, response.CharacterTrait, response.Concept});
    // }
        research.Print();
    }
    }
}
