using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Purple_4;

namespace Lab_6
{
    public class Purple_4
    {
        public struct Sportsman
        {
            //поля 
            private string _name;
            private string _surname;
            private double _time;

            private int _timeFlag;
      

            //свойтсва 
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public double  Time => _time;
            

            //конструктор 
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;

                _time = 0;

                _timeFlag = 0;
             

            }

            //методы
            public void Run(double time)
            {
                if (time <= 0 || _timeFlag==1) return;
                _time = time;
                _timeFlag = 1;
            }

            public void Print()
            {
                Console.Write($"{this.Name} {this.Surname} {_time}");
               
                Console.WriteLine();
            }

        }

        public struct Group
        {
            //поля
            private string _name;
            private Sportsman[] _sportsmen;

            private static Sportsman[] _twoGroups;

            //свойства
            public string Name { get { return _name; } }
            public Sportsman[] Sportsmen
            {
                get
                {
                    if ( _sportsmen == null) return null;
                    Sportsman[] copy = new Sportsman[_sportsmen.Length];
                    Array.Copy(_sportsmen, copy, _sportsmen.Length);
                    return copy;
                }
            }

            //конструкторы
            public Group(string name)
            {
                _name = name;

                _sportsmen= new Sportsman[0];

            }

           public Group(Group group) 
            {

                _name = group.Name;
                _sportsmen = group.Sportsmen;

            }

            static Group()
            {
                _twoGroups = new Sportsman[0];
            }
            //методы
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null) return;
                Array.Resize(ref this._sportsmen, this._sportsmen.Length + 1);
                this._sportsmen[this._sportsmen.Length - 1]=sportsman;

                Array.Resize(ref _twoGroups, _twoGroups.Length + 1);
                _twoGroups[_twoGroups.Length - 1] = sportsman;
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (_sportsmen == null) return;
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    Array.Resize(ref this._sportsmen, this._sportsmen.Length + 1);
                    this._sportsmen[this._sportsmen.Length - 1] = sportsmen[i];

                    Array.Resize(ref _twoGroups, _twoGroups.Length + 1);
                    _twoGroups[_twoGroups.Length - 1] = sportsmen[i];
                }
            }

            public void Add(Group group)
            {
                if (_sportsmen == null) return;
                for (int i = 0; i < group._sportsmen.Length; i++)
                {
                    Array.Resize(ref this._sportsmen, this._sportsmen.Length + 1);
                    this._sportsmen[this._sportsmen.Length - 1] = group._sportsmen[i];

                    Array.Resize(ref _twoGroups, _twoGroups.Length + 1);
                    _twoGroups[_twoGroups.Length - 1] = group._sportsmen[i];
                }
            }

            public void Sort()
            {
                if (_sportsmen == null) return;
                for (int i = 0; i < _sportsmen.Length-1; i++)
                {
                    for (int j = 0; j < _sportsmen.Length - 1 - i; j++)
                    {
                        if (_sportsmen[j].Time > _sportsmen[j + 1].Time)
                        {
                            Sportsman copy =_sportsmen[j+1];
                            _sportsmen[j + 1] = _sportsmen[j];
                            _sportsmen[j]=copy;
                        }

                    }
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                if (group1.Sportsmen == null || group2.Sportsmen == null) return new Group();
                Group Finalists=new Group("Финалисты");
                Finalists._sportsmen = new Sportsman[group1._sportsmen.Length+ group2._sportsmen.Length];

                int i = 0, j = 0, k = 0;
                while (i < group1._sportsmen.Length && j < group2._sportsmen.Length)
                {
                    if (group1._sportsmen[i].Time <= group2._sportsmen[j].Time)
                        Finalists._sportsmen[k++] = group1._sportsmen[i++];
                    else
                        Finalists._sportsmen[k++] = group2._sportsmen[j++];
                }
                while (i < group1._sportsmen.Length)
                    Finalists._sportsmen[k++] = group1._sportsmen[i++];
                while (j < group2._sportsmen.Length)
                    Finalists._sportsmen[k++] = group2._sportsmen[j++];


                return Finalists;
            }

            public void Print()
            {
                Console.WriteLine(_name);
                foreach (Sportsman i in _sportsmen)
                {
                    Console.WriteLine($"{i.Name} {i.Surname} {i.Time}");
                }
                
            }




        }
    }
}
