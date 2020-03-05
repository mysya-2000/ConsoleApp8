using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class FunctionExplorer
    {
        private readonly Func<double, double> _Func;
        public FunctionExplorer(Func<double, double> f)
        {
            _Func = f;
        }
        public double GetMinValue(double x1, double x2, double dx)
        {
            double min = double.PositiveInfinity;
            double x = x1;
            while (x <= x2)
            {
                double y = _Func(x);
                if (y < min)
                    min = y;
                x += dx;
            }
            return min;
        }
        public double GetMinValue(double x1, double x2, double dx, out double xmin)
        {
            double min = double.PositiveInfinity;
            double x = x1;
            xmin = x1;
            while (x <= x2)
            {
                double y = _Func(x);
                if (y < min)
                {
                    min = y;
                    xmin = x;
                }
                x += dx;
            }
            return min;
        }
        public FunctionValue GetMin(double x1, double x2, double dx)
        {
            double min = double.PositiveInfinity;
            double x = x1;
            var xmin = x1;
            while (x <= x2)
            {
                double y = _Func(x);
                if (y < min)
                {
                    min = y;
                    xmin = x;
                }
                x += dx;
            }
            return new FunctionValue(xmin, min);
        }

    }
    struct FunctionValue
    {
        public readonly double x;
        public readonly double y;
         public FunctionValue(double x, double y)
         {
             this.x = x;
             this.y = y;
         }
    }

    class Program
    {
        private static double F(double x)
        {
            return x * x;
        }

        static Func<double, double> CreateFunc(double a, double b, double c)
        {
            return x => a * x * x + b * x + c;
        }
      
        static void Main(string[] args)
        {
            Console.WriteLine("Введите условие");
            Console.Write("a>");
            string usl = Console.ReadLine();
            double a = double.Parse(usl);
            Console.Write("b>");
            string usl_2 = Console.ReadLine();
            double b = double.Parse(usl_2);
            Console.Write("c>");
            string usl_3 = Console.ReadLine();
            double c = double.Parse(usl_3);
            Func<double, double> f = F;
            //  Func<double, double> = CreateFunc(a, b, c);

            Console.WriteLine("Введите ограничения");
            Console.Write("x1>");
            string us4 = Console.ReadLine();
            double x1 = double.Parse(us4);
            Console.Write("x2>");
            string us5 = Console.ReadLine();
            double x2 = double.Parse(us5);

            const double x0 = -5;
            const double y0 = -7;
            double x_min; 
            Func<double, double> f1 = x => (x - x0) * (x - x0) + y0;
            var explorer = new FunctionExplorer(f1);
            var min = explorer.GetMinValue(-10, +10, 0.01, out x_min);
            var min_value = explorer.GetMin(-10, 10, 0.01);
            Console.WriteLine("min ={0}", min);
            Console.WriteLine("xmin={0}", x_min);
            Console.WriteLine("min f({0})={1}", min_value.x, min_value.y);
            Console.ReadLine();

          
        }
    }

}