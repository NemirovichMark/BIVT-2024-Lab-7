using Lab_6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BIVT_2024_Lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.Perple1Test();
            p.Purple2Test();
        }

        void Perple1Test()
        {
            Purple_1.Participant participant1 = new Purple_1.Participant("Иван", "Иванов");
            Purple_1.Participant participant2 = new Purple_1.Participant("Петр", "Петров");
            Purple_1.Participant participant3 = new Purple_1.Participant("Сергей", "Скворцов");
            Purple_1.Participant participant4 = new Purple_1.Participant("Федя", "Ромашев");

            participant1.SetCriterias(new double[] { 2.5, 2.5, 2.5, 2.5 });
            participant2.SetCriterias(new double[] { 2.5, 2.5, 2.5, 2.5 });
            participant3.SetCriterias(new double[] { 2.5, 2.5, 2.5, 2.5 });
            participant4.SetCriterias(new double[] { 2.5, 2.5, 2.5, 2.5 });

            participant1.Jump(new int[] { 1, 1, 1, 1, 1, 1, 1 });
            participant1.Jump(new int[] { 1, 1, 1, 1, 1, 1, 1 });
            participant1.Jump(new int[] { 1, 1, 1, 1, 1, 1, 1 });
            participant1.Jump(new int[] { 1, 1, 1, 1, 1, 1, 1 });

            participant2.Jump(new int[] { 4, 4, 4, 4, 4, 4, 4 });
            participant2.Jump(new int[] { 4, 4, 4, 4, 4, 4, 4 });
            participant2.Jump(new int[] { 4, 4, 4, 4, 4, 4, 4 });
            participant2.Jump(new int[] { 4, 4, 4, 4, 4, 4, 4 });

            participant3.Jump(new int[] { 3, 3, 3, 3, 3, 3, 3 });
            participant3.Jump(new int[] { 3, 3, 3, 3, 3, 3, 3 });
            participant3.Jump(new int[] { 3, 3, 3, 3, 3, 3, 3 });
            participant3.Jump(new int[] { 3, 3, 3, 3, 3, 3, 3 });

            participant4.Jump(new int[] { 2, 2, 2, 2, 2, 2, 2 });
            participant4.Jump(new int[] { 2, 2, 2, 2, 2, 2, 2 });
            participant4.Jump(new int[] { 2, 2, 2, 2, 2, 2, 2 });
            participant4.Jump(new int[] { 2, 2, 2, 2, 2, 2, 2 });

            Purple_1.Participant[] participants = new Purple_1.Participant[] { participant1, participant2, participant3, participant4 };

            Purple_1.Sort(participants);

            foreach (var participant in participants)
            {
                Console.WriteLine($"{participant.Name} {participant.Surname}: {participant.TotalScore}");
            }
        }
        void Purple2Test()
        {
            Purple_2.Participant participant1 = new Purple_2.Participant("Иван", "Иванов");
            Purple_2.Participant participant2 = new Purple_2.Participant("Петр", "Петров");
            Purple_2.Participant participant3 = new Purple_2.Participant("Сергей", "Скворцов");
            Purple_2.Participant participant4 = new Purple_2.Participant("Федя", "Ромашев");


            participant1.Jump(120, new int[] { 20, 20, 20, 20, 20 });
            participant2.Jump(80, new int[] { 1, 1, 1, 1, 1 });
            participant3.Jump(150, new int[] { 1, 1, 1, 1, 1 });
            participant4.Jump(100, new int[] { 1, 1, 1, 1, 1 });

            Purple_2.Participant[] participants = new Purple_2.Participant[] { participant1, participant2, participant3, participant4 };
            Purple_2.Participant.Sort(participants);

            // Выводим результаты
            foreach (var participant in participants)
            {
                Console.WriteLine($"{participant.Name} {participant.Surname}: {participant.Result}");
            }
        }
    }
}
