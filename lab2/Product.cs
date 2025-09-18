using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    abstract class Product
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
        public Product() : this("Неизвестно", 0, 0)
        { }
        public Product(string name, int price) : this(name, price, 2025)
        { }
        public Product(int price, int year) : this("Неизвестно", price, year)
        { }
        public Product(string name, int price, int year)
        {
            Name = name;
            Price = price;
            Year = year;
        }
        public abstract void Info();
        
        
    }
}
