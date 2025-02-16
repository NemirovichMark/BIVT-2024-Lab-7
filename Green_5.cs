using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
  public class Green_5 {
    public struct Student {
      // Поля
      private string _name;
      private string _surname;
      private int[] _marks;
      private const int _examsCount = 5;

      // Доп Поле
      private int _sumMarks;

      // Свойства
      public string Name => _name is not null ? _name : "Нет данных";
      public string Surname => _surname is not null ? _surname : "Нет данных";
      public int[] Marks => _marks is not null ? _marks : new int[_examsCount];
      public double AvgMark => _marks is not null ? (double)_sumMarks/ _examsCount : 0;

      // Конструктор
      public Student(string name, string surname) {
        this._name = name is not null ? name :  throw new ArgumentNullException(nameof(name), "Имя не может быть null");;
        this._surname = surname is not null ? surname : throw new ArgumentException(nameof(surname), "Фамилия не может быть null");
        this._marks = new int[_examsCount];
        this._sumMarks = 0;
      }

      // Методы
      public void Exam(int mark) {
        if ( mark < 2 || mark > 5) {
          Console.WriteLine("Неверный формат оценки");
          return;
        }
        for (int i = 0; i < _examsCount; i++) {
          if (_marks[i] == 0) {
            _marks[i] = mark;
            _sumMarks+=mark;
            return;
          }
        }
      }
    }
    public struct Group {
      // Поля 
      private string _name;
      private Student[] _students;
      private  int _studentsCount;

      // Доп Поле
      private double _sumAvgMarks;

      // Свойства
      public string Name => _name is not null ? _name : "Нет данных";
      public Student[] Students => _students is not null ? _students : new Student[_studentsCount];
      public double AvgMark => _studentsCount > 0 ? Math.Round(_sumAvgMarks / _studentsCount, 2) : 0;

      // Конструктор
      public Group(string name) {
        this._name = name is not null ? name :  throw new ArgumentNullException(nameof(name), "Имя не может быть null");
        this._students = new Student[100];
        this._studentsCount = 0;
        this._sumAvgMarks = 0;
      }

      // Методы
      public void Add(Student student)
      {
          _students[_studentsCount++] = student;
          _sumAvgMarks += student.AvgMark;
      }
      public void Add(Student[] students)
      {
          foreach (var student in students)
          {
              Add(student);
          }
      }
    }
  }
}