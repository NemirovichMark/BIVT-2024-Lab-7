namespace Lab_6{
    internal class Program
     {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Task_1();
            program.Task_2();

        }
        public void Task_1()
        {
             Purple_1.Participant[] participants = new Purple_1.Participant[]
        {
            new Purple_1.Participant("Никита", "Сидоров"),
            new Purple_1.Participant("Иван", "Лозенко"),
        };

        participants[0].SetCriterias(new double[] { 2.8, 2.9, 2.7, 3.2});
        participants[0].Jump(new int[] { 1, 6, 4, 3, 5, 2, 5 }); 
        participants[0].Jump(new int[] { 0, 2, 3, 5, 0, 6, 5 });
        participants[0].Jump(new int[] { 5, 3, 4, 2, 5, 1, 4 });
        participants[0].Jump(new int[] { 1, 3, 1, 5, 6, 0, 3 });

        participants[1].SetCriterias(new double[] { 3.4, 2.5, 3.0, 2.6 });
        participants[1].Jump(new int[] { 4, 3, 4, 3, 4, 1, 4 });
        participants[1].Jump(new int[] { 3, 4, 5, 0, 2, 5, 1 });
        participants[1].Jump(new int[] { 6, 6, 2, 6, 5, 3, 6 });
        participants[1].Jump(new int[] { 4, 2, 5, 6, 5, 4, 2 });

        Purple_1.Participant.Sort(participants);

        Console.WriteLine("Purple1");

        Console.WriteLine($"{"Имя",-12} {"Фамилия",-12} {"Результат",-10} {"Место",-5}");
        Console.WriteLine(new string('-', 42));
        int place = 0;
        foreach (var athlete in participants)
        {
            Console.WriteLine($"{athlete.Name,-12} {athlete.Surname,-12} {Math.Round(athlete.TotalScore,1),-11} {++place,-5}");
        }
        Console.WriteLine();
        }
        public void Task_2(){

        System.Console.WriteLine("Purple2");
        
        Purple_2.Participant p1 = new Purple_2.Participant("Имя1", "Фамилия1");
        p1.Jump(120, new int[] { 17, 10, 16, 12, 8 });
        Purple_2.Participant p2 = new Purple_2.Participant("Имя2", "Фамилия2");
        p2.Jump(130, new int[] { 5, 4, 2, 0, 7 });
        Purple_2.Participant p3 = new Purple_2.Participant("Имя3", "Фамилия3");
        p3.Jump(119, new int[] { 15, 16, 17, 18, 19 });
        Purple_2.Participant p4 = new Purple_2.Participant("Имя4", "Фамилия4");
        p4.Jump(200, new int[] { 20, 20, 20, 20, 20 });

        Purple_2.Participant[] participants = new Purple_2.Participant[] { p1, p2, p3, p4};
        Purple_2.Participant.Sort(participants);

        Console.WriteLine($"{"Имя",-12} {"Фамилия",-12} {"Результат",-10} {"Место",-5}");
        Console.WriteLine(new string('-', 42));
        int place = 0;
        foreach (var athlete in participants)
        {
            Console.WriteLine($"{athlete.Name,-12} {athlete.Surname,-12} {athlete.Result,-11} {++place,-5}");
        }
        Console.WriteLine();

        }
        public void Task_3(){}
        public void Task_4(){}
        public void Task_5(){}
     }
}