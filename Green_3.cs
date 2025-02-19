using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6  {
  public class Green_3 {
    public struct Student {
      // Поля
      private string? _name;
      private string? _surname;
      private int[] _marks;
      private bool _isExpelled;
      private const int _examsCount = 3;

      // Свойства
      public string? Name => _name is not null ? _name : null;
      public string? Surname => _surname is not null ? _surname : null;
      public int[] Marks => _marks is not null ? _marks : new int[_examsCount];
      public double AvgMark => _marks is not null && _marks.Count(c => c != 0) != 0 ? (double)_marks.Sum()/ _marks.Count(c => c != 0) : 0;
      public bool IsExpelled => _isExpelled;

      // Конструктор
      public Student(string name, string surname) {
        this._name = name is not null ? name :  null;
        this._surname = surname is not null ? surname : null;
        this._marks = new int[_examsCount];
        for (int i = 0; i < _examsCount; i++) {
          _marks[i] = 0;
        }
        this._isExpelled = false;
      }

      // Методы
      public void Exam(int mark) {
        if (_isExpelled) {
          return;
        }
        if (mark < 2 || mark > 5) {
          Console.WriteLine("Оценка должна быть от 2 до 5");
          return;
        }
        if (Marks == null) {
          Console.WriteLine("Массив оценок не инициализирован");
           return;
        }
        for (int i = 0; i < _examsCount; i++) {
          if (Marks[i] == 0) {
            if (mark == 2) {
              _isExpelled = true;
            }
            Marks[i] = mark;
            return;
          }
        }
      }

      public static void SortByAvgMark(Student[] array) {
        if (array == null) {
          Console.WriteLine("Массив студентов не инициализирован");
          return;
        }
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                // Сравниваем средние баллы групп
                if (array[j].AvgMark < array[j + 1].AvgMark)
                {
                    // Меняем местами группы
                    Student temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
      }

      public void Print() { }

    }
  }
}