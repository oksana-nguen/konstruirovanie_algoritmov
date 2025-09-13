using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Dairyproduct: Product
    {
        private double percent;
        public double Percent {
            get { return percent; }
            set { if (value>=0 && value<=100)  percent = value; }
        }
        
        public string Category { get; set; }
        private string category;
        public Dairyproduct(string name, int price, int year, string category,int percent) : base(name, price, year)
        {
            Category = category;
            Percent = percent;
        }
        public void Consoll()
        {
            Console.WriteLine("Товар: {0}  из категории '{1}', процент жирности '{2}%', стоит {3} рублей и изготовлен в '{4}'", Name, Category,Percent, Price, Year);
        }
    }
}
