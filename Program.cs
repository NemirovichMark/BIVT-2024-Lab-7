using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Task_1();
        }
        public void Task_1()
        {
            Purple_1.Participant participant1 = new Purple_1.Participant("Дарья", "Тихонова");
            participant1.SetCriterias(new double[] { 2.58, 2.90, 3.04, 3.43 });
            participant1.Jump(new int[] { 3, 4, 1, 2, 1, 3, 1 });
            participant1.Jump(new int[] { 5, 3, 4, 3, 3, 3, 3 });
            participant1.Jump(new int[] { 2, 4, 1, 5, 6, 1, 2 });
            participant1.Jump(new int[] { 6, 4, 3, 2, 2, 1, 1 });

            participant1.Print();

            Purple_1.Participant participant2 = new Purple_1.Participant("Александр", "Козлов");
            participant2.SetCriterias(new double[] { 2.95, 2.63, 3.16, 2.89 });
            participant2.Jump(new int[] { 3, 5, 4, 4, 5, 1, 4 });
            participant2.Jump(new int[] { 1, 6, 5, 2, 1, 4, 1 });
            participant2.Jump(new int[] { 6, 2, 4, 1, 2, 6, 5 });
            participant2.Jump(new int[] { 6, 5, 2, 2, 4, 3, 4 });

            participant2.Print();

            Purple_1.Participant[] array = new Purple_1.Participant[] { participant1, participant2 };
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].TotalScore);
            }
            Purple_1.Participant.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].TotalScore);
            }
        }
        public void Task_2()
        {
            Purple_2.Participant participant1 = new Purple_2.Participant("Оксана", "Сидорова");
            participant1.Jump(135, new int[] { 15, 1, 3, 9, 15 });

            participant1.Print();
            Console.WriteLine(participant1.Result);

            Purple_2.Participant participant2 = new Purple_2.Participant("Анастасия ", "Козлова");
            participant2.Jump(112, new int[] { 7, 4, 19, 11, 12 });

            participant2.Print();
            Console.WriteLine(participant2.Result);

            Purple_2.Participant[] array = new Purple_2.Participant[] { participant1, participant2 };
            
            Purple_2.Participant.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].Result);
            }
        }

        public void Task_3()
        {
            Purple_3.Participant participant1 = new Purple_3.Participant("Виктор", "Полевой");
            participant1.Evaluate(5.93);
            participant1.Evaluate(5.44);
            participant1.Evaluate(1.20);
            participant1.Evaluate(0.28);
            participant1.Evaluate(1.57);
            participant1.Evaluate(1.86);
            participant1.Evaluate(5.89);


            
            

            Purple_3.Participant participant2 = new Purple_3.Participant("Татьяна", "Сидорова");
            participant2.Evaluate(3.86);
            participant2.Evaluate(0.19);
            participant2.Evaluate(0.46);
            participant2.Evaluate(5.14);
            participant2.Evaluate(5.37);
            participant2.Evaluate(0.94);
            participant2.Evaluate(0.84);

            Purple_3.Participant participant3 = new Purple_3.Participant("Ярослав", "Зайцев");
            participant3.Evaluate(2.93);
            participant3.Evaluate(3.10);
            participant3.Evaluate(5.46);
            participant3.Evaluate(4.88);
            participant3.Evaluate(3.99);
            participant3.Evaluate(4.79);
            participant3.Evaluate(5.56);

            Purple_3.Participant participant4 = new Purple_3.Participant("Александр", "Петров");
            participant4.Evaluate(3.78);
            participant4.Evaluate(3.42);
            participant4.Evaluate(3.84);
            participant4.Evaluate(2.19);
            participant4.Evaluate(1.20);
            participant4.Evaluate(2.51);
            participant4.Evaluate(3.51);

            Purple_3.Participant.SetPlaces(new Purple_3.Participant[] { participant1, participant2, participant3, participant4 });

            participant1.Print();
            participant2.Print();
            participant3.Print();
            participant4.Print();

            Purple_3.Participant[] array = new Purple_3.Participant[] { participant1, participant2, participant3, participant4 };

            Purple_3.Participant.Sort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].Name + " " + array[i].Surname);
            }
        }
        public void Task_4()
        {
            //group1
            Purple_4.Group group1 = new Purple_4.Group("Women");

            Purple_4.Sportsman[] sportsmen = new Purple_4.Sportsman[] { new Purple_4.Sportsman("Полина", "Луговая") ,
                                                                        new Purple_4.Sportsman("Савелий", "Козлов") ,
                                                                        new Purple_4.Sportsman("Екатерина", "Жаркова")};

            sportsmen[0].Run(422.64);
            sportsmen[1].Run(142.05);
            sportsmen[2].Run(185.23);

            group1.Add(sportsmen);
            group1.Print();
            group1.Sort();
            group1.Print();

            //group2
            Purple_4.Group group2 = new Purple_4.Group("Men");

            Purple_4.Sportsman[] sportsmen2 = new Purple_4.Sportsman[] { new Purple_4.Sportsman("Анастасия", "Жаркова") ,
                                                                        new Purple_4.Sportsman("Оксана", "Жаркова") ,
                                                                        new Purple_4.Sportsman("Игорь", "Сидоров")};

            sportsmen2[0].Run(112.49);
            sportsmen2[1].Run(252.16);
            sportsmen2[2].Run(102.13);

            group2.Add(sportsmen2);
            group2.Print();
            group2.Sort();
            group2.Print();

            var new_group = Purple_4.Group.Merge(group1 , group2);
            new_group.Print();
        }

        public void Task_5()
        {
            Purple_5.Response[] responses =
            {
                new Purple_5.Response("Макака", null, "Манга"),
                new Purple_5.Response("Тануки", "Проницательность", "Манга"),
                new Purple_5.Response("Тануки", "Скромность", "Кимоно"),
                new Purple_5.Response("Кошка", "Внимательность", "Суши"),
                new Purple_5.Response("Сима_энага", "Дружелюбность", "Кимоно"),
                new Purple_5.Response("Дракон", "Дружелюбность", "Кимоно"),
                new Purple_5.Response("Панда", null, "Кимоно")
            };

            Purple_5.Research research = new Purple_5.Research("gay");

            foreach(var response in responses)
            {
                research.Add(new string[] { response.Animal, response.CharacterTrait, response.Concept });
            }

            research.Print();
            foreach (var response in research.GetTopResponses(3))
                Console.Write(response + "\t");
            Console.WriteLine();

        }
    }
}
