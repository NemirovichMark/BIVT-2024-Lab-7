using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
    class Program {
        public static void Main(string[] args) {
               var participants = new List<Purple_3.Participant>();

            // // Data from the provided list (name, surname, marks)
            participants.Add(new Purple_3.Participant("Виктор", "Полевой", 5.93, 5.44, 1.20, 0.28, 1.57, 1.86, 5.89));
            participants.Add(new Purple_3.Participant("Алиса", "Козлова", 1.68, 3.79, 3.62, 2.76, 4.47, 4.26, 5.79));
            participants.Add(new Purple_3.Participant("Ярослав", "Зайцев", 2.93, 3.10, 5.46, 4.88, 3.99, 4.79, 5.56));
            participants.Add(new Purple_3.Participant("Савелий", "Кристиан", 4.20, 4.69, 3.90, 1.67, 1.13, 5.66, 5.40));
            participants.Add(new Purple_3.Participant("Алиса", "Козлова", 3.27, 2.43, 0.90, 5.61, 3.12, 3.76, 3.73));
            participants.Add(new Purple_3.Participant("Алиса", "Луговая", 0.75, 1.13, 5.43, 2.07, 2.68, 0.83, 3.68));
            participants.Add(new Purple_3.Participant("Александр", "Петров", 3.78, 3.42, 3.84, 2.19, 1.20, 2.51, 3.51));
            participants.Add(new Purple_3.Participant("Мария", "Смирнова", 1.35, 3.40, 1.85, 2.02, 2.78, 3.23, 3.03));
            participants.Add(new Purple_3.Participant("Полина", "Сидорова", 0.55, 5.93, 0.75, 5.15, 4.35, 1.51, 2.77));
            participants.Add(new Purple_3.Participant("Татьяна", "Сидорова", 3.86, 0.19, 0.46, 5.14, 5.37, 0.94, 0.84));



          var newParticipants = participants.ToArray();
            
            Purple_3.Participant.SetPlaces(newParticipants);

            Purple_3.Participant.Sort(newParticipants);

            foreach (var i in newParticipants) {
                Console.WriteLine(i.Name + " " + i.Surname + " " + i.Score + " " + i.Places.Min() + " " + i.Marks.Sum());
            }

        }
    }
}