using System;
using System.Text;

namespace NonlinearEquationSolver
{
    class Program
    {
        static double f(double x)
        {
            return 3 * x - 4 * Math.Log(x) - 5;
        }

        static double fp(double x, double D)
        {
            return (f(x + D) - f(x)) / D;
        }

        static double f2p(double x, double D)
        {
            return (f(x + D) + f(x - D) - 2 * f(x)) / (D * D);
        }

        static void MDN(double a, double b, double eps)
        {
            double c;
            int i = 0;

            if (f(a) * f(b) > 0)
            {
                Console.WriteLine("На цьому інтервалі немає кореня");
                return;
            }
            if (Math.Abs(f(a)) < eps)
            {
                Console.WriteLine($"x = {a}, ітерацій: {i}");
                return;
            }
            else
            if (Math.Abs(f(b)) < eps)
            {
                Console.WriteLine($"x = {b}, ітерацій: {i}");
                return;
            }

            while (Math.Abs(b - a) > eps)
            {
                c = 0.5 * (a + b);
                i++;

                if (Math.Abs(f(c)) < eps)
                {
                    Console.WriteLine($"x = {c}, ітерацій: {i}");
                    return;
                }

                if (f(a) * f(c) < 0)
                    b = c;
                else
                    a = c;
            }

            Console.WriteLine($"x = {(a + b) / 2.0}, ітерацій: {i}");
        }

        static void MN(double a, double b, double eps, int kmax)
        {
            double D = eps / 100.0;
            double x = b, Dx;
            int k;

            if (f(x) * f2p(x, D) < 0)
            {
                x = a;
            }

            if (f(x) * f2p(x, D) < 0)
            {
                Console.WriteLine("Для заданого рівняння збіжність методу Ньютона не гарантується");
            }

            for (k = 1; k <= kmax; k++)
            {
                Dx = f(x) / fp(x, D);
                x = x - Dx;

                if (Math.Abs(Dx) < eps)
                {
                    Console.WriteLine($"Шуканий корінь: {x}, k={k}");
                    return;
                }
            }

            Console.WriteLine("За задану кількість ітерацій корінь з точністю Eps не знайдено");
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Оберіть метод:");
            Console.WriteLine("1 - Метод ділення навпіл");
            Console.WriteLine("2 - Метод Ньютона");
            Console.Write("Вибраний метод: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введіть межу a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть межу b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть точність Eps: ");
            double eps = Convert.ToDouble(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        MDN(a, b, eps);
                        break;
                    }
                case 2:
                    {
                        Console.Write("Введіть максимальну кількість ітерацій Kmax: ");
                        int kmax = Convert.ToInt32(Console.ReadLine());
                        MN(a, b, eps, kmax);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Ти шось не то ввів");
                        break;
                    }
            }
            Console.ReadLine();
        }
    }
}
