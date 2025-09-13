using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
   public class Toys: Product
    {
        public string Category { get; set; }
        private string category;
        public Toys (string name, int price, int year, string category ): base(name,price,year)
        {
            Category = category;
        }
        public void Consol()
        {
            Console.WriteLine("Игрушка: {0}  из категории '{1}' стоит {2} рублей и изготовлен в '{3}'", Name, Category, Price, Year); 
        }

    }
}
