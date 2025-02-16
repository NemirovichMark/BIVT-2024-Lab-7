using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
    class Program {
        public static void Main(string[] args) {
            var p = new string[] {"a", "c", "b", "b", "a"};
            p = p.GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key).Take(10).ToArray();
            Console.WriteLine(string.Join(", ", p));
        }
    }
}