using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab2
{
     class Toys : Product
    {
        public string Category { get; set; }
        private string category;
        public Toys(string name, int price, int year, string category) : base(name, price, year)
        {
            Category = category;
        }
        public override void Info()
        {
            Console.WriteLine("Игрушка: {0}  из категории '{1}' стоит {2} рублей и изготовлен в '{3}'", Name, Category, Price, Year);
        }
        public static bool operator >(Toys s1,Toys s2)
        {
            if(s1.Price > s2.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(Toys s1, Toys s2)
        {
            return s1.Price < s2.Price;
        }
    }
}
