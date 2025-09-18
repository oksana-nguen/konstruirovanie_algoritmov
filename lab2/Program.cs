using System.Security.Cryptography;
using lab2;

string name;
int price;
int year;

name = "Медведь";
price = 2500;
string category = "Плюшевая игрушка";
year = 2020;
Toys bear = new Toys(name, price, year, category);
bear.Info();

name = "Мяч";
price = 2000;
category = "Плюшевая игрушка";
year = 2020;
Toys ball = new Toys(name, price, year, category);
ball.Info();

if(bear.Price>ball.Price)
{
    Console.WriteLine("Цена медведя дороже, чем мяча");
}

name = "Сметана";
price = 50;
category = "Кисломолочный продукт";
year = 2025;
int percent = 15;
Dairyproduct sour_cream = new Dairyproduct(name, price, year, category, percent);
sour_cream.Info();

name = "огурец";
price = 120;
int weight = 3;
year = 2024;
Goods cucumber = new Goods(name, price, year, weight);
cucumber.Info();

var toy = new { name = "пазл", price = 20};
Console.WriteLine(toy.GetType().Name);
