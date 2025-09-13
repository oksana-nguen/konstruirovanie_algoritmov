using lab1;

string name = "Молоко";
int price = 2000;
int year = 2023;
Product milk = new Product(name, price, year);
milk.Info();

name = "Медведь";
price = 2500;
string category = "Плюшевая игрушка";
year = 2020;
Toys bear = new Toys(name,price,year,category);
bear.Consol();
bear.Info();

name = "Сметана";
price = 50;
category = "Кисломолочный продукт";
year = 2025;
int percent = 15;
Dairyproduct sour_cream = new Dairyproduct(name, price, year, category, percent);
sour_cream.Consoll();

name = "огурец";
price = 120;
int weight = 3;
year = 2024;
Goods cucumber = new Goods(name, price, year, weight);
cucumber.Consolll();