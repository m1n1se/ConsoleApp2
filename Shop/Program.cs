using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        // Структура для товара
        struct Product
        {
            public string Name;
            public int Price;
        }

        // Структура для заказа
        struct Order
        {
            public string CustomerName;
            public List<Product> Products;
            public int TotalPrice;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== МАГАЗИН ===\n");

            // Создаем список товаров
            List<Product> allProducts = new List<Product>
            {
                new Product { Name = "Хлеб", Price = 50 },
                new Product { Name = "Молоко", Price = 80 },
                new Product { Name = "Колбаса", Price = 190 },
                new Product { Name = "Сыр", Price = 205 },
                new Product { Name = "Яйца", Price = 100 }
            };

            // Покупатель
            Console.Write("Введите ваше имя: ");
            string customerName = Console.ReadLine();

            // Корзина покупателя
            List<Product> cart = new List<Product>();

            // Показываем товары
            Console.WriteLine("\nНаши товары:");
            for (int i = 0; i < allProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allProducts[i].Name} - {allProducts[i].Price} руб.");
            }

            // Добавляем товары в корзину
            bool shopping = true;
            while (shopping)
            {
                Console.Write("\nВведите номер товара для добавления (0 - закончить): ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 0)
                {
                    shopping = false;
                }
                else if (choice > 0 && choice <= allProducts.Count)
                {
                    cart.Add(allProducts[choice - 1]);
                    Console.WriteLine($"Добавлен: {allProducts[choice - 1].Name}");
                }
            }

            // Создаем заказ
            Order order = new Order();
            order.CustomerName = customerName;
            order.Products = cart;

            // Считаем сумму
            int total = 0;
            foreach (var product in cart)
            {
                total += product.Price;
            }
            order.TotalPrice = total;

            // Показываем заказ
            Console.WriteLine("\n=== ВАШ ЗАКАЗ ===");
            Console.WriteLine($"Покупатель: {order.CustomerName}");
            Console.WriteLine("Товары:");

            for (int i = 0; i < order.Products.Count; i++)
            {
                Console.WriteLine($"  {order.Products[i].Name} - {order.Products[i].Price} руб.");
            }

            Console.WriteLine($"\nОбщая сумма: {order.TotalPrice} руб.");

            // Процесс оплаты
            Console.WriteLine("\n=== ОПЛАТА ===");
            Console.WriteLine($"К оплате: {order.TotalPrice} руб.");
            Console.Write("Введите сумму для оплаты: ");
            int payment = int.Parse(Console.ReadLine());

            if (payment >= order.TotalPrice)
            {
                Console.WriteLine("Оплата прошла успешно!");
                if (payment > order.TotalPrice)
                {
                    Console.WriteLine($"Сдача: {payment - order.TotalPrice} руб.");
                }
            }
            else
            {
                Console.WriteLine("Недостаточно средств!");
            }

            Console.WriteLine("\nСпасибо за покупку!");
        }
    }
}
