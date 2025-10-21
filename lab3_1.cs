using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication2
{
class Program
{
 public static double f(double x)
 {
 return 3*x-4*Math.Log(x)-5;
 }
 static void Main(string[] args)
 {
 double a, b, c, Eps;
 int Lich = 0;
 Console.WriteLine("Input a, b, eps");
 a = Convert.ToDouble(Console.ReadLine());
 b = Convert.ToDouble(Console.ReadLine());
 Eps = Convert.ToDouble(Console.ReadLine());
 if (f(a) * f(b) > 0) // перевіряємо, чи є корінь на інтервалі [a, b]
 { Console.WriteLine("No root in the interval");
 Console.ReadLine(); // затримка показу повідомлення
 return;
 }
 if (Math.Abs(f(a)) < Eps) // перевіряємо, чи ліва межа не є коренем
 {Console.WriteLine("x = " + a + " Lich = " + Lich);
 Console.ReadLine(); // затримка показу повідомлення
 return;
 }
 else
 if (Math.Abs(f(b)) < Eps) // перевіряємо, чи права межа не є коренем
 { Console.WriteLine("x = " + b + " Lich = " + Lich);
 Console.ReadLine(); // затримка показу повідомлення
 return;
 }
else
 {
 while (Math.Abs(b - a) > Eps) // цикл Методу ділення навпіл
 {
 c = 0.5*(a + b);
 Lich++;
 if (Math.Abs(f(c)) < Eps) // Перевіряємо, чи точка с не є коренем
 {
 Console.WriteLine("x = " + c + " Lich = " + Lich);
 Console.ReadLine(); // затримка показу повідомлення
 return;
 }
 else if (f(a) * f(c) < 0) b = c; // звуження інтервалу пошуку кореня
 else a = c;
 }
Console.WriteLine("x = " + (a + b) / 2 + " Lich = " + Lich);
 Console.ReadLine(); // затримка показу повідомлення
 return;
 }
 }
 }
}