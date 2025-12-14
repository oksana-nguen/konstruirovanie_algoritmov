using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASD_2
{
    public struct Complex
    {
        public double Real {  get; set; }
        public double Imaginary { get; set; }
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public static Complex Create(double real, double imaginary)
        {
            return new Complex(real, imaginary);
        }
        public static Complex Add(double real1, double imaginary1, double real2, double imaginary2)
        {
            return new Complex(real1 + real2, imaginary1 + imaginary2);
        }
        public static Complex Subtract(double real1, double imaginary1, double real2, double imaginary2)
        {
            return new Complex(real1 - real2, imaginary1 - imaginary2);
        }
        public static Complex Multiplication(double real1, double imaginary1, double real2, double imaginary2)
        {
            return new Complex(real1 * real2 - imaginary1 * imaginary2, real1 * imaginary2 + imaginary1 * real2);
        }
        public static Complex Division(double real1, double imaginary1, double real2, double imaginary2)
        {
            if (real2 * real2 + imaginary2 * imaginary2 == 0) throw new InvalidOperationException("деление на 0");
            else
                return new Complex((real1 * real2 + imaginary1 * imaginary1) / (real2 * real2 + imaginary2 * imaginary2), (imaginary1 * real2 - imaginary2 * real1) / (imaginary2 * imaginary2 + real2 * real2));
        }
        public double Abs()
        {
            return Math.Sqrt(Real*Real+ Imaginary*Imaginary);
        }
        public double Arg()
        {
            if (Real > 0) return Math.Atan(Imaginary / Real);
            else if (Real < 0 && Imaginary >= 0) return Math.Atan(Imaginary / Real) + Math.PI;
            else if (Real < 0 && Imaginary < 0) return Math.Atan(Imaginary / Real) - Math.PI;
            else if (Real == 0 && Imaginary > 0) return Math.PI / 2;
            else if (Real == 0 && Imaginary < 0) return -Math.PI / 2;
            else return 0.0;
        }
        public double GetReal()
        {
            return Real;
        }
        public double GetImaginary()
        {
            return Imaginary;
        }
        public void Print()
        {
            if(Imaginary>0)
            Console.WriteLine("Результат : {0}+{1}i",Real,Imaginary);
            else if(Imaginary<0)
                Console.WriteLine("Результат: {0}-{1}i", Real, Imaginary);
            else Console.WriteLine("Pезультат : {0}", Real);
        }
    }
}
