using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
  public class Green_4 {
    public struct Participant {
      // Поля
      private string? _name;
      private string? _surname;
      private double[] _jumps;
      private const int _jumpsCount = 3;

      // Свойства
      public string? Name => _name is not null ? _name : null;
      public string? Surname => _surname is not null ? _surname : null;
      public double[] Jumps => _jumps is not null ? _jumps : new double[_jumpsCount];
      public double BestJump => _jumps is not null ? Math.Round(_jumps.Max(), 2) : 0;

      // Конструктор
      public Participant(string name, string surname) {
        this._name = name is not null ? name :  null;
        this._surname = surname is not null ? surname : null;
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
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                // Сравниваем средние баллы групп
                if (array[j].BestJump < array[j + 1].BestJump)
                {
                    // Меняем местами группы
                    Participant temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }      
      }
    }
  }
}