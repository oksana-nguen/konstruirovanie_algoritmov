using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Goods: Product
    {
        private double weight;
        public double Weight { get; set; }
        public Goods(string name, int price, int year, int weight) : base(name, price, year)
        {

            Weight = weight;
        }
        public void Consolll()
        {
            Console.WriteLine("Продукт: {0} массой {1} кг стоит {2} рублей и изготовлен в '{3}' году", Name, Weight, Price, Year);
        }
    }
}
