using System;
using System.Linq;

namespace Lab_6;

public class Blue_2
{
    public struct Participant {

        // приватные поля
        private string _name;
        private string _surname;
        private int[,] _marks;

        private int recordedJums;

        // публичные свойства

        public string Name => _name;
        public string Surname => _surname;
        public int[,] Marks {
            get {
                if (_marks == null) return new int[0, 0];
                int[,] copy_marks = new int[_marks.GetLength(0), _marks.GetLength(1)];
                for (int i = 0; i < _marks.GetLength(0); i++) {
                    for (int j = 0; j < _marks.GetLength(1); j++) copy_marks[i, j] = _marks[i, j];
                }
                return copy_marks;
            }
        }
        public int TotalScore
        {
            get
            {
                if (_marks == null) return 0;
                int sum = 0;
                for (int i = 0; i < recordedJums; i++)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        sum += _marks[i, j];
                    }
                }
                return sum;
            }
        }

        // конструктор
        public Participant(string name, string surname) {
            _name = name;
            _surname = surname;
            _marks = new int[2, 5];
            recordedJums = 0;
        }

        // методы
        // метод для добавления результатов прыжков
        public void Jump(int[] result)
        {
            if (result == null) return;
            if (_marks == null) return;
            if (recordedJums < 2) {
                int[] newResult = result.Take(5).ToArray();
                for (int j=0; j<newResult.Length; j++) {
                    _marks[recordedJums, j] = newResult[j];
                }
                recordedJums++;
            }
        }
        // метод для сортировки массива участников
        public static void Sort(Participant[] array) {
            if (array == null) return;
            for (int i=0; i < array.Length-1; i++) {
                for (int j=0; j < array.Length-i-1; j++) {
                    if (array[j].TotalScore < array[j+1].TotalScore) {
                        Participant temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        public void Print() {

            Console.WriteLine($"{_name} {_surname}: {TotalScore}");
            Console.WriteLine("Оценки судей:");
            for (int i = 0; i < Marks.GetLength(0); i++)
            {
                for (int j = 0; j < Marks.GetLength(1); j++)
                {
                    Console.Write($"{Marks[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}