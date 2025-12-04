using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Класс для товара магазина
/// </summary>
/// <param name="id"></param>
/// <param name="name"></param>
/// <param name="price"></param>
/// <param name="stock"></param>
public class Product(int id, string name, decimal price, int stock)
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; } = id;
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; } = name;
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; } = price;
    /// <summary>
    /// Количество
    /// </summary>
    public int Stock { get; private set; } = stock;
    /// <summary>
    /// Уменьшает количесвто товара на складе
    /// </summary>
    /// <param name="quantity"></param>
    /// <returns></returns>
    public bool ReduceStock(int quantity)
    {
        if (Stock < quantity) return false;
        Stock -= quantity;
        return true;
    }
}
/// <summary>
/// Класс покупателя в магазине
/// </summary>
/// <param name="id"></param>
/// <param name="name"></param>
/// <param name="email"></param>
public class Customer(int id, string name, string email)
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; } = id;
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; } = name;
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; } = email;
    /// <summary>
    /// Список заказов
    /// </summary>
    public List<Order> Orders { get; } = new();
}
/// <summary>
/// Класс  заказа
/// </summary>
public class Order
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; }
    /// <summary>
    /// Покупатель
    /// </summary>
    public Customer Customer { get; }
    /// <summary>
    /// Список товаров в заказе
    /// </summary>
    public List<(Product Product, int Quantity)> Items { get; } = new();
    /// <summary>
    /// Дата и время заказа
    /// </summary>
    public DateTime Date { get; } = DateTime.Now;
    /// <summary>
    /// Текущий статус 
    /// </summary>
    public string Status { get; set; } = "Создан";
    /// <summary>
    /// Общая сумма заказа
    /// </summary>
    public decimal Total { get; private set; }
    /// <summary>
    /// Создает новый заказ
    /// </summary>
    /// <param name="id"></param>
    /// <param name="customer"></param>
    public Order(int id, Customer customer)
    {
        Id = id;
        Customer = customer;
        customer.Orders.Add(this);
    }
    /// <summary>
    /// Добавление товара в заказ
    /// </summary>
    /// <param name="product"></param>
    /// <param name="quantity"></param>
    /// <exception cref="Exception"></exception>
    public void AddItem(Product product, int quantity)
    {
        if (!product.ReduceStock(quantity))
            throw new Exception($"Недостаточно {product.Name}");

        Items.Add((product, quantity));
        Total += product.Price * quantity;
    }
    /// <summary>
    /// Оплата заказа
    /// </summary>
    /// <param name="method"></param>
    public void Pay(string method)
    {
        Status = $"Оплачен ({method})";
    }
}
/// <summary>
/// Класс магазина
/// </summary>
public class Shop
{
    private readonly List<Product> _products = new();
    private readonly List<Customer> _customers = new();
    private int _orderCounter = 1;
    /// <summary>
    /// Добавление нового товара
    /// </summary>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="stock"></param>
    /// <returns></returns>
    public Product AddProduct(string name, decimal price, int stock)
    {
        var product = new Product(_products.Count + 1, name, price, stock);
        _products.Add(product);
        return product;
    }
    /// <summary>
    /// Регистрация нового покупателя
    /// </summary>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    public Customer AddCustomer(string name, string email)
    {
        var customer = new Customer(_customers.Count + 1, name, email);
        _customers.Add(customer);
        return customer;
    }
    /// <summary>
    /// Создание нового заказа
    /// </summary>
    /// <param name="customer"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    public Order CreateOrder(Customer customer, params (Product Product, int Quantity)[] items)
    {
        var order = new Order(_orderCounter++, customer);

        foreach (var (product, quantity) in items)
        {
            order.AddItem(product, quantity);
        }

        return order;
    }
}
/// <summary>
/// Основоной класс
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа 
    /// </summary>
    static void Main()
    {
        var shop = new Shop();
        //Создание товоара
        var book = shop.AddProduct("Книга", 500, 100);
        var pen = shop.AddProduct("Ручка", 50, 200);
        //Регистрация покупателя
        var customer = shop.AddCustomer("Анна", "anna@mail.ru");
        //Создание заказа
        var order = shop.CreateOrder(customer,
            (book, 2),
            (pen, 5));
        //оплата
        order.Pay("Карта");
        //Вывод информации
        Console.WriteLine($"Заказ #{order.Id}");
        Console.WriteLine($"Клиент: {customer.Name}");
        Console.WriteLine($"Сумма: {order.Total:C}");
        Console.WriteLine($"Статус: {order.Status}");
    }
}