using System;
using System.Collections.Generic;

namespace Task2_JewelryShop
{
    public class JewelryCustomer
    {
        public string FullName;
        public string PhoneNumber;
        public string Type;     
        public string Material;  
        public decimal Price;
        public double Discount;  

        public JewelryCustomer(string name, string phone, string type, string material, decimal price, double discount)
        {
            FullName = name;
            PhoneNumber = phone;
            Type = type;
            Material = material;
            Price = price;
            Discount = discount;
        }

        // Метод расчета итоговой цены
        public decimal GetFinalPrice()
        {
            return Price - (Price * (decimal)(Discount / 100));
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Клиент: {FullName} (Тел: {PhoneNumber})");
            Console.WriteLine($"Покупка: {Type} из материала {Material}");
            Console.WriteLine($"Цена: {Price}, Скидка: {Discount}%, Итого к оплате: {GetFinalPrice()}");
            Console.WriteLine("------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<JewelryCustomer> customers = new List<JewelryCustomer>();

            while (true)
            {
                Console.WriteLine("\n--- ЮВЕЛИРНЫЙ МАГАЗИН ---");
                Console.WriteLine("1. Добавить покупателя");
                Console.WriteLine("2. Вывод всех покупателей");
                Console.WriteLine("3. Поиск по телефону");
                Console.WriteLine("4. Общая прибыль");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("ФИО: ");
                        string name = Console.ReadLine();
                        Console.Write("Телефон: ");
                        string phone = Console.ReadLine();
                        Console.Write("Тип украшения: ");
                        string type = Console.ReadLine();
                        Console.Write("Материал: ");
                        string mat = Console.ReadLine();
                        Console.Write("Цена: ");
                        decimal price = decimal.Parse(Console.ReadLine());
                        Console.Write("Скидка (%): ");
                        double disc = double.Parse(Console.ReadLine());

                        customers.Add(new JewelryCustomer(name, phone, type, mat, price, disc));
                        break;

                    case "2":
                        foreach (var c in customers) c.PrintInfo();
                        break;

                    case "3":
                        Console.Write("Введите номер для поиска: ");
                        string searchPhone = Console.ReadLine();
                        bool found = false;
                        foreach (var c in customers)
                        {
                            if (c.PhoneNumber == searchPhone)
                            {
                                c.PrintInfo();
                                found = true;
                            }
                        }
                        if (!found) Console.WriteLine("Клиент не найден.");
                        break;

                    case "4":
                        decimal total = 0;
                        foreach (var c in customers) total += c.GetFinalPrice();
                        Console.WriteLine($"Общая прибыль: {total} руб.");
                        break;

                    case "0": return;
                }
            }
        }
    }
}