namespace Lab_6{
    internal class Program
     {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Task_1();
            program.Task_2();
            program.Task_3();
            program.Task_4();

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

        Console.WriteLine($"{"Name",-12} {"Surname",-12} {"TotalScore",-10}");
        Console.WriteLine(new string('-', 35));
        foreach (var athlete in participants)
        {
           athlete.Print();
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

        Console.WriteLine($"{"Name",-12} {"Surname",-12} {"Result",-7} ");
        Console.WriteLine(new string('-', 42));
        foreach (var athlete in participants)
        {
            athlete.Print();
        }
        Console.WriteLine();

        }
        public void Task_3(){

        Console.WriteLine("Purple3");
        Purple_3.Participant[] participants = new Purple_3.Participant[]
        {
            new Purple_3.Participant("Степан", "Свиридов"),
            new Purple_3.Participant("Савелий", "Сидоров"),
            new Purple_3.Participant("Савелий", "Сидоров"),
            new Purple_3.Participant("Степан", "Козлов"),
            new Purple_3.Participant("Степан", "Сидоров"),
            new Purple_3.Participant("Юлия", "Свиридова"),
            new Purple_3.Participant("Мирослав", "Козлов"),
            new Purple_3.Participant("Степан", "Петров"),
            new Purple_3.Participant("Светлана", "Свиридова"),
            new Purple_3.Participant("Мария", "Павлова"),

        };

        participants[0].Evaluate(2.53);
        participants[0].Evaluate(5.13);
        participants[0].Evaluate(5.79);
        participants[0].Evaluate(4.91);
        participants[0].Evaluate(2.98);
        participants[0].Evaluate(3.74);
        participants[0].Evaluate(5.76);

        participants[1].Evaluate(2.49);
        participants[1].Evaluate(0.86);
        participants[1].Evaluate(1.52);
        participants[1].Evaluate(3.06);
        participants[1].Evaluate(1.17);
        participants[1].Evaluate(4.95);
        participants[1].Evaluate(4.89);

        participants[2].Evaluate(1.73);
        participants[2].Evaluate(5.65);
        participants[2].Evaluate(3.29);
        participants[2].Evaluate(0.72);
        participants[2].Evaluate(2.36);
        participants[2].Evaluate(0.88);
        participants[2].Evaluate(4.61);

        participants[3].Evaluate(1.82);
        participants[3].Evaluate(4.69);
        participants[3].Evaluate(4.30);
        participants[3].Evaluate(2.20);
        participants[3].Evaluate(4.33);
        participants[3].Evaluate(5.32);
        participants[3].Evaluate(4.49);


        participants[4].Evaluate(0.32);
        participants[4].Evaluate(3.34);
        participants[4].Evaluate(4.50);
        participants[4].Evaluate(4.94);
        participants[4].Evaluate(0.65);
        participants[4].Evaluate(5.60);
        participants[4].Evaluate(4.12);

        participants[5].Evaluate(3.10);
        participants[5].Evaluate(4.45);
        participants[5].Evaluate(1.87);
        participants[5].Evaluate(4.30);
        participants[5].Evaluate(1.09);
        participants[5].Evaluate(4.72);
        participants[5].Evaluate(3.62);

        participants[6].Evaluate(3.74);
        participants[6].Evaluate(1.02);
        participants[6].Evaluate(1.61);
        participants[6].Evaluate(0.01);
        participants[6].Evaluate(3.34);
        participants[6].Evaluate(4.19);
        participants[6].Evaluate(2.65);

        participants[7].Evaluate(1.49);
        participants[7].Evaluate(3.38);
        participants[7].Evaluate(1.50);
        participants[7].Evaluate(2.32);
        participants[7].Evaluate(3.57);
        participants[7].Evaluate(2.61);
        participants[7].Evaluate(2.34);


        participants[8].Evaluate(1.60);
        participants[8].Evaluate(4.49);
        participants[8].Evaluate(3.39);
        participants[8].Evaluate(1.30);
        participants[8].Evaluate(2.97);
        participants[8].Evaluate(5.18);
        participants[8].Evaluate(1.11);

        participants[9].Evaluate(5.26);
        participants[9].Evaluate(4.97);
        participants[9].Evaluate(2.73);
        participants[9].Evaluate(2.22);
        participants[9].Evaluate(1.69);
        participants[9].Evaluate(1.78);
        participants[9].Evaluate(0.75);


        Purple_3.Participant.SetPlaces(participants);
        Purple_3.Participant.Sort(participants);


        Console.WriteLine($"{"Name",-12} {"Surname",-12} {"Score",-7} {"TopPlace",-10} {"TotalMark",-7}");
        Console.WriteLine(new string('-', 50));

        foreach (var participant in participants)
        {
            participant.Print();
        }
        Console.WriteLine();
        }
        public void Task_4(){
            Console.WriteLine("Purple4");

            Purple_4.Sportsman sportsman1 = new Purple_4.Sportsman("Юлия", "Полевая");
            sportsman1.Run(432.89);
            Purple_4.Sportsman sportsman2 = new Purple_4.Sportsman("Лев", "Иванов");
            sportsman2.Run(345.43);
            Purple_4.Group group1 = new Purple_4.Group("1");
            group1.Add(sportsman1);
            group1.Add(sportsman2);
            group1.Sort();

            Purple_4.Sportsman sportsman3 = new Purple_4.Sportsman("Савелий", "Козлов");
            sportsman3.Run(567.98);
            Purple_4.Sportsman sportsman4 = new Purple_4.Sportsman("Ольга", "Павлова");
            sportsman4.Run(234.78);
            Purple_4.Sportsman sportsman5 = new Purple_4.Sportsman("Евгений", "Полевой");
            sportsman5.Run(412.38);
            Purple_4.Group group2 = new Purple_4.Group("2");
            group2.Add(sportsman3);
            group2.Add(sportsman4);
            group2.Add(sportsman5);
            group2.Sort();

            Purple_4.Group mergeGroup = Purple_4.Group.Merge(group1, group2);

            Console.WriteLine($"{"Name",-12} {"Surname",-12} {"TotalScore",-10}");
            Console.WriteLine(new string('-', 35));
            foreach (var sportsman in mergeGroup.Sportsmen)
            {
                sportsman.Print();
            }
            Console.WriteLine();

        }
        public void Task_5(){}
     }
}