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
            Purple_1.Participant p1 = new Purple_1.Participant("Дарья", "Тихонова");
            Purple_1.Participant p2 = new Purple_1.Participant("Александр", "Козлов");
            Purple_1.Participant p3 = new Purple_1.Participant("Никита", "Павлов");
            Purple_1.Participant p4 = new Purple_1.Participant("Юрий", "Луговой");
            Purple_1.Participant p5 = new Purple_1.Participant("Юрий", "Степанов");
            Purple_1.Participant p6 = new Purple_1.Participant("Мария", "Луговая");
            Purple_1.Participant p7 = new Purple_1.Participant("Виктор", "Жарков");
            Purple_1.Participant p8 = new Purple_1.Participant("Марина", "Иванова");
            Purple_1.Participant p9 = new Purple_1.Participant("Марина", "Полевая");
            Purple_1.Participant p10 = new Purple_1.Participant("Максим", "Тихонов");

            p1.SetCriterias(new double[] { 2.58, 2.90, 3.04, 3.43});
            p2.SetCriterias(new double[] { 2.95, 2.63, 3.16, 2.89 });
            p3.SetCriterias(new double[] { 2.56, 3.40, 2.91, 2.69 });
            p4.SetCriterias(new double[] { 2.86, 2.90, 3.19, 3.14 });
            p5.SetCriterias(new double[] { 2.81, 2.64, 2.76, 3.20 });
            p6.SetCriterias(new double[] { 2.74, 3.30, 2.94, 3.27 });
            p7.SetCriterias(new double[] { 2.57, 2.79, 2.71, 3.46 });
            p8.SetCriterias(new double[] { 3.09, 2.67, 2.90, 3.50 });
            p9.SetCriterias(new double[] { 2.65, 3.47, 3.11, 3.39 });
            p10.SetCriterias(new double[] { 3.14, 3.46, 2.96, 2.76 });

            p1.Jump(new int[] { 3, 4, 1, 2, 1, 3, 1 }); p1.Jump(new int[] { 5, 3, 4, 3, 3, 3, 3 }); p1.Jump(new int[] { 2, 4, 1, 5, 6, 1, 2 }); p1.Jump(new int[] { 6, 4, 3, 2, 2, 1, 1 });
            p2.Jump(new int[] { 3, 5, 1, 2, 1, 3, 1 }); p2.Jump(new int[] { 5, 3, 4, 3, 3, 3, 3 }); p2.Jump(new int[] { 2, 4, 1, 5, 6, 1, 2 }); p2.Jump(new int[] { 6, 4, 3, 2, 2, 1, 1 });
            p3.Jump(new int[] { 3, 4, 1, 2, 1, 3, 1 }); p3.Jump(new int[] { 5, 3, 4, 3, 3, 3, 3 }); p3.Jump(new int[] { 2, 4, 1, 5, 6, 1, 2 }); p3.Jump(new int[] { 6, 4, 3, 2, 2, 1, 1 });
            p4.Jump(new int[] { 3, 4, 1, 2, 1, 3, 1 }); p4.Jump(new int[] { 5, 3, 4, 3, 3, 3, 3 }); p4.Jump(new int[] { 2, 4, 1, 5, 6, 1, 2 }); p4.Jump(new int[] { 6, 4, 3, 2, 2, 1, 1 });
            p5.Jump(new int[] { 3, 4, 1, 2, 1, 3, 1 }); p5.Jump(new int[] { 5, 3, 4, 3, 3, 3, 3 }); p5.Jump(new int[] { 2, 4, 1, 5, 6, 1, 2 }); p5.Jump(new int[] { 6, 4, 3, 2, 2, 1, 1 });
            p6.Jump(new int[] { 3, 4, 1, 2, 1, 3, 1 }); p6.Jump(new int[] { 5, 3, 4, 3, 3, 3, 3 }); p6.Jump(new int[] { 2, 4, 1, 5, 6, 1, 2 }); p6.Jump(new int[] { 6, 4, 3, 2, 2, 1, 1 });
            p7.Jump(new int[] { 3, 4, 1, 2, 1, 3, 1 }); p7.Jump(new int[] { 5, 3, 4, 3, 3, 3, 3 }); p7.Jump(new int[] { 2, 4, 1, 5, 6, 1, 2 }); p7.Jump(new int[] { 6, 4, 3, 2, 2, 1, 1 });
            p8.Jump(new int[] { 3, 4, 1, 2, 1, 3, 1 }); p8.Jump(new int[] { 5, 3, 4, 3, 3, 3, 3 }); p8.Jump(new int[] { 2, 4, 1, 5, 6, 1, 2 }); p8.Jump(new int[] { 6, 4, 3, 2, 2, 1, 1 });
            p9.Jump(new int[] { 3, 4, 1, 2, 1, 3, 1 }); p9.Jump(new int[] { 5, 3, 4, 3, 3, 3, 3 }); p9.Jump(new int[] { 2, 4, 1, 5, 6, 1, 2 }); p9.Jump(new int[] { 6, 4, 3, 2, 2, 1, 1 });
            p10.Jump(new int[] { 3, 4, 1, 2, 1, 3, 1 }); p10.Jump(new int[] { 5, 3, 4, 3, 3, 3, 3 }); p10.Jump(new int[] { 2, 4, 1, 5, 6, 1, 2 }); p10.Jump(new int[] { 6, 4, 3, 2, 2, 1, 1 });
        }
        void Purple2Test()
        {

        }
    }
}
