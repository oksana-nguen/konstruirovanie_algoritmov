using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
//вариант 9 игрушка, продукт, товар, молочный продукт
namespace lab1
{
    public class Product
    {
        private string name;
        private int price;
        private int year;
        public string Name { get; set; }
        public int Price { get; set; }
        public int Year
        {
            get { return year; }
            set
            {
                if (value <= 2025 && value > 0) year = value;
            }
        }
        public Product(string name, int price, int year)
        {
            Name = name;
            Price = price;
            Year = year;
        }
        public Product(string name,int price)
        {
            Name = name;
            Price = price;
            Year = 2025;
        }
        public Product(int price, int year)
        {
            Price = price;
            Year = year;
            Name = "неизвестно";
        }
        public void Info()
        {
            Console.WriteLine("Товар: {0} стоит {1} рублей и изготовлен в '{2}'", Name, Price, Year);
        }
    }
}
