using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
  public class Green_4 {
    public struct Participant {
      // Поля
      private string _name;
      private string _surname;
      private double[] _jumps;
      private const int _jumpsCount = 3;

      // Свойства
      public string Name => _name is not null ? _name : "Нет данных";
      public string Surname => _surname is not null ? _surname : "Нет данных";
      public double[] Jumps => _jumps is not null ? _jumps : new double[_jumpsCount];
      public double BestJump => _jumps is not null ? Math.Round(_jumps.Max(), 2) : 0;

      // Конструктор
      public Participant(string name, string surname) {
        this._name = name is not null ? name :  throw new ArgumentNullException(nameof(name), "Имя не может быть null");;
        this._surname = surname is not null ? surname : throw new ArgumentException(nameof(surname), "Фамилия не может быть null");
        this._jumps = new double[_jumpsCount];
      }

      // Методы
      public void Jump(double result) {
        if (result <= 0) {
          return;
        }
        for (int i = 0; i < _jumpsCount; i++) {
          if (Jumps[i] == 0) {
            Jumps[i] = result;
            return;
          }
        }
      }

      public static void Sort(Participant[] array) {
        if (array == null) {
          return;
        }
        Array.Sort(array, (s1, s2) => s2.BestJump.CompareTo(s1.BestJump));
      }
    }
  }
}