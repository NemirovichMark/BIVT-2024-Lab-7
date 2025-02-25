using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Program //класс доступен везде в рамках неймспейса, internal - по умолчанию (объект доступен в данном пространстве м)
                           // по умолчанию у методов внутри класса; private писать напрямую модификаторы доступа пока что 
    {
        static void Main(string[] args)
        {
            Program program = new Program();// создание экземпляра класса


            //Purple_1 purple_1 = new Purple_1();

            //Example.Student s = new Example.Student("Petya", 20); //обращаемся к структуре 
            //Console.WriteLine(s.Name);

            //s.Marks[0] = 6;//обращаемся по ссылке и можем поменять значения 
            //foreach (int mark in s.Marks)
            //{
            //    Console.WriteLine(mark);
            //}

            //структура - значимый тип можно без конструктора new


            //Purple_1 purple_1 = new Purple_1();

            //// Участник 1
            //Purple_1.Participant Tihonova = new Purple_1.Participant("Darya", "Tihonova");
            //Tihonova.SetCriterias(new double[] { 2.58, 2.90, 3.04, 3.43 });

            //// Участник 2
            //Purple_1.Participant Kozlov = new Purple_1.Participant("Alexander", "Kozlov");
            //Kozlov.SetCriterias(new double[] { 2.95, 2.63, 3.16, 2.89 });

            //// Участник 3
            //Purple_1.Participant Pavlov = new Purple_1.Participant("Nikita", "Pavlov");
            //Pavlov.SetCriterias(new double[] { 2.56, 3.40, 2.91, 2.69 });

            //// Участник 4
            //Purple_1.Participant Lugovoy = new Purple_1.Participant("Yuri", "Lugovoy");
            //Lugovoy.SetCriterias(new double[] { 2.86, 2.90, 3.19, 3.14 });

            //// Участник 5
            //Purple_1.Participant Stepanov = new Purple_1.Participant("Yuri", "Stepanov");
            //Stepanov.SetCriterias(new double[] { 2.81, 2.64, 2.76, 3.20 });

            //// Участник 6
            //Purple_1.Participant Lugovaya = new Purple_1.Participant("Maria", "Lugovaya");
            //Lugovaya.SetCriterias(new double[] { 2.74, 3.30, 2.94, 3.27 });

            //// Участник 7
            //Purple_1.Participant Zharkov = new Purple_1.Participant("Victor", "Zharkov");
            //Zharkov.SetCriterias(new double[] { 2.57, 2.79, 2.71, 3.46 });

            //// Участник 8
            //Purple_1.Participant Ivanova = new Purple_1.Participant("Marina", "Ivanova");
            //Ivanova.SetCriterias(new double[] { 3.09, 2.67, 2.90, 3.50 });

            //// Участник 9
            //Purple_1.Participant Polevaya = new Purple_1.Participant("Marina", "Polevaya");
            //Polevaya.SetCriterias(new double[] { 2.65, 3.47, 3.11, 3.39 });

            //// Участник 10
            //Purple_1.Participant Tikhonov = new Purple_1.Participant("Maxim", "Tikhonov");
            //Tikhonov.SetCriterias(new double[] { 3.14, 3.46, 2.96, 2.76 });

            //// Участник 1
            //Tihonova.Jump(new int[] { 3, 4, 1, 2, 1, 3, 1 });
            //Tihonova.Jump(new int[] { 5, 3, 4, 3, 3, 3, 3 });
            //Tihonova.Jump(new int[] { 2, 4, 1, 5, 6, 1, 2 });
            //Tihonova.Jump(new int[] { 6, 4, 3, 2, 2, 1, 1 });

            //// Участник 2
            //Kozlov.Jump(new int[] { 3, 5, 4, 4, 5, 1, 4 });
            //Kozlov.Jump(new int[] { 1, 6, 5, 2, 1, 4, 1 });
            //Kozlov.Jump(new int[] { 6, 2, 4, 1, 2, 6, 5 });
            //Kozlov.Jump(new int[] { 6, 5, 2, 2, 4, 3, 4 });

            //// Участник 3
            //Pavlov.Jump(new int[] { 1, 1, 3, 5, 5, 5, 2 });
            //Pavlov.Jump(new int[] { 4, 1, 1, 2, 2, 2, 5 });
            //Pavlov.Jump(new int[] { 5, 2, 3, 3, 2, 2, 3 });
            //Pavlov.Jump(new int[] { 3, 1, 3, 4, 2, 4, 5 });

            //// Участник 4
            //Lugovoy.Jump(new int[] { 3, 3, 5, 2, 1, 2, 4 });
            //Lugovoy.Jump(new int[] { 5, 5, 4, 2, 3, 2, 2 });
            //Lugovoy.Jump(new int[] { 6, 3, 1, 2, 2, 6, 6 });
            //Lugovoy.Jump(new int[] { 5, 1, 6, 6, 3, 2, 5 });

            //// Участник 5
            //Stepanov.Jump(new int[] { 4, 3, 5, 4, 5, 1, 1 });
            //Stepanov.Jump(new int[] { 5, 3, 4, 2, 1, 1, 2 });
            //Stepanov.Jump(new int[] { 2, 2, 4, 2, 6, 3, 4 });
            //Stepanov.Jump(new int[] { 3, 2, 1, 3, 5, 1, 5 });

            //// Участник 6
            //Lugovaya.Jump(new int[] { 6, 5, 5, 4, 2, 6, 4 });
            //Lugovaya.Jump(new int[] { 5, 4, 3, 2, 4, 6, 1 });
            //Lugovaya.Jump(new int[] { 1, 1, 3, 4, 4, 1, 6 });
            //Lugovaya.Jump(new int[] { 3, 1, 5, 1, 4, 3, 1 });

            //// Участник7
            //Zharkov.Jump(new int[] { 4, 6, 1, 4, 5, 3, 4 });
            //Zharkov.Jump(new int[] { 1, 2, 3, 1, 5, 4, 3 });
            //Zharkov.Jump(new int[] { 3, 6, 2, 3, 1, 6, 3 });
            //Zharkov.Jump(new int[] { 3, 3, 6, 6, 3, 6, 6 });

            //// Участник8
            //Ivanova.Jump(new int[] { 6, 5, 3, 2, 6, 5, 3 });
            //Ivanova.Jump(new int[] { 5, 4, 4, 2, 1, 2, 4 });
            //Ivanova.Jump(new int[] { 4, 2, 2, 5, 1, 3, 1 });
            //Ivanova.Jump(new int[] { 6, 5, 6, 1, 6, 3, 3 });

            //// Участник9
            //Polevaya.Jump(new int[] { 3, 6, 3, 5, 4, 2, 3 });
            //Polevaya.Jump(new int[] { 4, 6, 1, 4, 2, 1, 5 });
            //Polevaya.Jump(new int[] { 1, 1, 3, 1, 3, 2, 6 });
            //Polevaya.Jump(new int[] { 1, 4, 4, 6, 6, 2, 5 });

            //// Участник10
            //Tikhonov.Jump(new int[] { 3, 3, 1, 4, 5, 6, 2 });
            //Tikhonov.Jump(new int[] { 6, 4, 5, 4, 2, 3, 1 });
            //Tikhonov.Jump(new int[] { 3, 3, 4, 2, 2, 3, 6 });
            //Tikhonov.Jump(new int[] { 5, 1, 5, 5, 1, 3, 4 });

            //Purple_1.Participant[] group = new Purple_1.Participant[] { Tihonova, Kozlov, Pavlov, Lugovoy, Stepanov, Lugovaya, Zharkov, Ivanova, Polevaya, Tikhonov };
            //Purple_1.Participant.Sort(group);
            //foreach (Purple_1.Participant i in group)
            //{
            //    i.Print();
            //}

            //<<<2>>>

            //Purple_2.Participant Sidorova = new Purple_2.Participant("Оксана", "Сидорова");
            //Sidorova.Jump(135, new int[] { 15, 1, 3, 9, 15 });

            //Purple_2.Participant Polevaya = new Purple_2.Participant("Полина", "Полевая");
            //Polevaya.Jump(191, new int[] { 19, 14, 9, 11, 4 });

            //Purple_2.Participant Polevoy = new Purple_2.Participant("Дмитрий", "Полевой");
            //Polevoy.Jump(147, new int[] { 20, 9, 1, 13, 6 });

            //Purple_2.Participant Rasputina = new Purple_2.Participant("Евгения", "Распутина");
            //Rasputina.Jump(115, new int[] { 5, 20, 17, 9, 16 });

            //Purple_2.Participant Lugovoy = new Purple_2.Participant("Савелий", "Луговой");
            //Lugovoy.Jump(112, new int[] { 19, 8, 1, 6, 17 });

            //Purple_2.Participant Pavlova = new Purple_2.Participant("Евгения", "Павлова");
            //Pavlova.Jump(151, new int[] { 16, 12, 5, 20, 4 });

            //Purple_2.Participant Sviridov = new Purple_2.Participant("Егор", "Свиридов");
            //Sviridov.Jump(186, new int[] { 5, 20, 3, 19, 18 });

            //Purple_2.Participant SviridovStepan = new Purple_2.Participant("Степан", "Свиридов");
            //SviridovStepan.Jump(166, new int[] { 16, 12, 5, 4, 15 });

            //Purple_2.Participant Kozlova = new Purple_2.Participant("Анастасия", "Козлова");
            //Kozlova.Jump(112, new int[] { 7, 4, 19, 11, 12 });

            //Purple_2.Participant Sviridova = new Purple_2.Participant("Светлана", "Свиридова");
            //Sviridova.Jump(197, new int[] { 14, 3, 6, 17, 1 });


            //Purple_2.Participant[] group = new Purple_2.Participant[] { Sidorova, Polevaya, Polevoy, Rasputina, Lugovoy, Pavlova, Sviridov, SviridovStepan, Kozlova, Sviridova };
            //Purple_2.Participant.Sort(group);
            //foreach (Purple_2.Participant i in group)
            //{
            //    i.Print();
            //}

            //<<<<3>>>>>
            //Purple_3.Participant Polevoy = new Purple_3.Participant("Виктор", "Полевой");
            //double[] Polevoy_marks = new double[7] { 5.93, 5.44, 1.20, 0.28, 1.57, 1.86, 5.89 };
            //foreach (double i in Polevoy_marks)
            //{
            //    Polevoy.Evaluate(i);
            //}

            //Purple_3.Participant Kozlova1 = new Purple_3.Participant("Алиса", "Козлова");
            //double[] Kozlova1_marks = new double[7] { 1.68, 3.79, 3.62, 2.76, 4.47, 4.26, 5.79 };
            //foreach (double i in Kozlova1_marks)
            //{
            //    Kozlova1.Evaluate(i);
            //}

            //Purple_3.Participant Zaytsev = new Purple_3.Participant("Ярослав", "Зайцев");
            //double[] Zaytsev_marks = new double[7] { 2.93, 3.10, 5.46, 4.88, 3.99, 4.79, 5.56 };
            //foreach (double i in Zaytsev_marks)
            //{
            //    Zaytsev.Evaluate(i);
            //}

            //Purple_3.Participant Krestian = new Purple_3.Participant("Савелий", "Кристиан");
            //double[] Krestian_marks = new double[7] { 4.20, 4.69, 3.90, 1.67, 1.13, 5.66, 5.40 };
            //foreach (double i in Krestian_marks)
            //{
            //    Krestian.Evaluate(i);
            //}

            //Purple_3.Participant Kozlova2 = new Purple_3.Participant("Алиса", "Козлова");
            //double[] Kozlova2_marks = new double[7] { 3.27, 2.43, 0.90, 5.61, 3.12, 3.76, 3.73 };
            //foreach (double i in Kozlova2_marks)
            //{
            //    Kozlova2.Evaluate(i);
            //}

            //Purple_3.Participant Lugovaya = new Purple_3.Participant("Алиса", "Луговая");
            //double[] Lugovaya_marks = new double[7] { 0.75, 1.13, 5.43, 2.07, 2.68, 0.83, 3.68 };
            //foreach (double i in Lugovaya_marks)
            //{
            //    Lugovaya.Evaluate(i);
            //}

            //Purple_3.Participant Petrov = new Purple_3.Participant("Александр", "Петров");
            //double[] Petrov_marks = new double[7] { 3.78, 3.42, 3.84, 2.19, 1.20, 2.51, 3.51 };
            //foreach (double i in Petrov_marks)
            //{
            //    Petrov.Evaluate(i);
            //}

            //Purple_3.Participant Smirnova = new Purple_3.Participant("Мария", "Смирнова");
            //double[] Smirnova_marks = new double[7] { 1.35, 3.40, 1.85, 2.02, 2.78, 3.23, 3.03 };
            //foreach (double i in Smirnova_marks)
            //{
            //    Smirnova.Evaluate(i);
            //}

            //Purple_3.Participant Sidorova1 = new Purple_3.Participant("Полина", "Сидорова");
            //double[] Sidorova1_marks = new double[7] { 0.55, 5.93, 0.75, 5.15, 4.35, 1.51, 2.77 };
            //foreach (double i in Sidorova1_marks)
            //{
            //    Sidorova1.Evaluate(i);
            //}

            //Purple_3.Participant Sidorova2 = new Purple_3.Participant("Татьяна", "Сидорова");
            //double[] Sidorova2_marks = new double[7] { 3.86, 0.19, 0.46, 5.14, 5.37, 0.94, 0.84 };
            //foreach (double i in Sidorova2_marks)
            //{
            //    Sidorova2.Evaluate(i);
            //}

            //Purple_3.Participant[] group = new Purple_3.Participant[] { Polevoy, Kozlova1, Zaytsev, Krestian, Kozlova2, Lugovaya, Petrov, Smirnova, Sidorova1, Sidorova2 };
            //Purple_3.Participant.SetPlaces(group);
            //Purple_3.Participant.Sort(group);
            //foreach (Purple_3.Participant i in group)
            //{
            //    i.Print();
            //}

            //<<<<4>>>

            //Purple_4.Sportsman Polina_Lygovaya = new Purple_4.Sportsman("Полина", "Луговая");
            //Polina_Lygovaya.Run(422.64);

            //Purple_4.Sportsman Savely_Kozlov = new Purple_4.Sportsman("Савелий", "Козлов");
            //Savely_Kozlov.Run(142.05);

            //Purple_4.Sportsman Ekaterina_Zharkova = new Purple_4.Sportsman("Екатерина", "Жаркова");
            //Ekaterina_Zharkova.Run(185.23);

            //Purple_4.Sportsman Dmitriy_Ivanov = new Purple_4.Sportsman("Дмитрий", "Иванов");
            //Dmitriy_Ivanov.Run(294.32);

            //Purple_4.Sportsman Dmitriy_Polevoy = new Purple_4.Sportsman("Дмитрий", "Полевой");
            //Dmitriy_Polevoy.Run(79.26);

            //Purple_4.Sportsman Savely_Petrov = new Purple_4.Sportsman("Савелий", "Петров");
            //Savely_Petrov.Run(230.63);

            //Purple_4.Sportsman Evgeniya_Raspuntina = new Purple_4.Sportsman("Евгения", "Распутина");
            //Evgeniya_Raspuntina.Run(35.16);

            //Purple_4.Sportsman Ekaterina_Lygovaya = new Purple_4.Sportsman("Екатерина", "Луговая");
            //Ekaterina_Lygovaya.Run(376.12);

            //Purple_4.Sportsman Maria_Ivanova = new Purple_4.Sportsman("Мария", "Иванова");
            //Maria_Ivanova.Run(279.20);

            //Purple_4.Sportsman Stepan_Pavlov = new Purple_4.Sportsman("Степан", "Павлов");
            //Stepan_Pavlov.Run(292.38);

            //Purple_4.Sportsman Olga_Pavlova = new Purple_4.Sportsman("Ольга", "Павлова");
            //Olga_Pavlova.Run(467.60);

            //Purple_4.Sportsman Olga_Polevaya = new Purple_4.Sportsman("Ольга", "Полевая");
            //Olga_Polevaya.Run(473.82);

            //Purple_4.Sportsman Darya_Pavlova = new Purple_4.Sportsman("Дарья", "Павлова");
            //Darya_Pavlova.Run(290.14);

            //Purple_4.Sportsman Darya_Sviridova = new Purple_4.Sportsman("Дарья", "Свиридова");
            //Darya_Sviridova.Run(368.60);

            //Purple_4.Sportsman Evgeniya_Sviridova = new Purple_4.Sportsman("Евгения", "Свиридова");
            //Evgeniya_Sviridova.Run(212.67);

            //Purple_4.Group group1 = new Purple_4.Group("Группа 1");
            //group1.Add(new Purple_4.Sportsman[] { Polina_Lygovaya, Savely_Kozlov, Ekaterina_Zharkova, Dmitriy_Ivanov, Dmitriy_Polevoy, Savely_Petrov, Evgeniya_Raspuntina, Ekaterina_Lygovaya, Maria_Ivanova, Stepan_Pavlov, Olga_Pavlova, Olga_Polevaya, Darya_Pavlova, Darya_Sviridova, Evgeniya_Sviridova });



            //Purple_4.Sportsman Anastasia_Zharkova = new Purple_4.Sportsman("Анастасия", "Жаркова");
            //Anastasia_Zharkova.Run(112.49);

            //Purple_4.Sportsman Alexander_Pavlov = new Purple_4.Sportsman("Александр", "Павлов");
            //Alexander_Pavlov.Run(472.11);

            //Purple_4.Sportsman Stepan_Sviridov = new Purple_4.Sportsman("Степан", "Свиридов");
            //Stepan_Sviridov.Run(213.92);

            //Purple_4.Sportsman Igor_Sidorov = new Purple_4.Sportsman("Игорь", "Сидоров");
            //Igor_Sidorov.Run(102.13);

            //Purple_4.Sportsman Evgeniya_Sidorova = new Purple_4.Sportsman("Евгения", "Сидорова");
            //Evgeniya_Sidorova.Run(263.21);

            //Purple_4.Sportsman Maria_Sidorova = new Purple_4.Sportsman("Мария", "Сидорова");
            //Maria_Sidorova.Run(350.75);

            //Purple_4.Sportsman Lev_Petrov = new Purple_4.Sportsman("Лев", "Петров");
            //Lev_Petrov.Run(248.68);

            //Purple_4.Sportsman Savely_Kozlov1 = new Purple_4.Sportsman("Савелий", "Козлов");
            //Savely_Kozlov1.Run(325.28);

            //Purple_4.Sportsman Egor_Sviridov = new Purple_4.Sportsman("Егор", "Свиридов");
            //Egor_Sviridov.Run(300.00);

            //Purple_4.Sportsman Oksana_Zharkova = new Purple_4.Sportsman("Оксана", "Жаркова");
            //Oksana_Zharkova.Run(252.16);

            //Purple_4.Sportsman Svetlana_Petrova = new Purple_4.Sportsman("Светлана", "Петрова");
            //Svetlana_Petrova.Run(402.20);

            //Purple_4.Sportsman Polina_Petrova = new Purple_4.Sportsman("Полина", "Петрова");
            //Polina_Petrova.Run(397.33);

            //Purple_4.Sportsman Ekaterina_Pavlova = new Purple_4.Sportsman("Екатерина", "Павлова");
            //Ekaterina_Pavlova.Run(384.94);

            //Purple_4.Sportsman Yuliya_Polevaya = new Purple_4.Sportsman("Юлия", "Полевая");
            //Yuliya_Polevaya.Run(8.09);

            //Purple_4.Sportsman Evgeniya_Pavlova = new Purple_4.Sportsman("Евгения", "Павлова");
            //Evgeniya_Pavlova.Run(480.52);

            //Purple_4.Group group2 = new Purple_4.Group("Группа 2");
            //group2.Add(new Purple_4.Sportsman[] { Anastasia_Zharkova, Alexander_Pavlov, Stepan_Sviridov, Igor_Sidorov, Evgeniya_Sidorova, Maria_Sidorova, Lev_Petrov, Savely_Kozlov1, Egor_Sviridov, Oksana_Zharkova, Svetlana_Petrova, Polina_Petrova, Ekaterina_Pavlova, Yuliya_Polevaya, Evgeniya_Pavlova });

            //Purple_4.Group Finalists = Purple_4.Group.Merge(group1, group2);
            //Finalists.Print();

            //<<<<<5>>>>
            Purple_5.Research research = new Purple_5.Research("Япония");

            research.Add(new string[] { "Макака", null, "Манга" });
            research.Add(new string[] { "Тануки", "Проницательность", "Манга" });
            research.Add(new string[] { "Тануки", "Скромность", "Кимоно" });
            research.Add(new string[] { "Кошка", "Внимательность", "Суши" });
            research.Add(new string[] { "Сима_энага", "Дружелюбность", "Кимоно" });
            research.Add(new string[] { "Макака", "Внимательность", "Самурай" });
            research.Add(new string[] { "Панда", "Проницательность", "Манга" });
            research.Add(new string[] { "Сима_энага", "Проницательность", "Суши" });
            research.Add(new string[] { "Серау", "Внимательность", "Сакура" });
            research.Add(new string[] { "Панда", null, "Кимоно" });
            research.Add(new string[] { "Сима_энага", "Дружелюбность", "Сакура" });
            research.Add(new string[] { "Кошка", "Внимательность", "Кимоно" });
            research.Add(new string[] { "Панда", null, "Сакура" });
            research.Add(new string[] { "Кошка", "Уважительность", "Фудзияма" });
            research.Add(new string[] { "Панда", "Целеустремленность", "Аниме" });
            research.Add(new string[] { "Серау", "Дружелюбность", null });
            research.Add(new string[] { "Панда", null, "Манга" });
            research.Add(new string[] { "Сима_энага", "Скромность", "Фудзияма" });
            research.Add(new string[] { "Панда", "Проницательность", "Самурай" });
            research.Add(new string[] { "Кошка", "Внимательность", "Сакура" });
            for (int i = 1; i < 4; i++)
            {
                research.Print(i);
            }
        }

    }

}