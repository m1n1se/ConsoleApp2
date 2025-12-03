using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Product(int id, string name, decimal price, int stock)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public decimal Price { get; } = price;
    public int Stock { get; private set; } = stock;

    public bool ReduceStock(int quantity)
    {
        if (Stock < quantity) return false;
        Stock -= quantity;
        return true;
    }
}

public class Customer(int id, string name, string email)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public string Email { get; } = email;
    public List<Order> Orders { get; } = new();
}

public class Order
{
    public int Id { get; }
    public Customer Customer { get; }
    public List<(Product Product, int Quantity)> Items { get; } = new();
    public DateTime Date { get; } = DateTime.Now;
    public string Status { get; set; } = "Создан";
    public decimal Total { get; private set; }

    public Order(int id, Customer customer)
    {
        Id = id;
        Customer = customer;
        customer.Orders.Add(this);
    }

    public void AddItem(Product product, int quantity)
    {
        if (!product.ReduceStock(quantity))
            throw new Exception($"Недостаточно {product.Name}");

        Items.Add((product, quantity));
        Total += product.Price * quantity;
    }

    public void Pay(string method)
    {
        Status = $"Оплачен ({method})";
    }
}

public class Shop
{
    private readonly List<Product> _products = new();
    private readonly List<Customer> _customers = new();
    private int _orderCounter = 1;

    public Product AddProduct(string name, decimal price, int stock)
    {
        var product = new Product(_products.Count + 1, name, price, stock);
        _products.Add(product);
        return product;
    }

    public Customer AddCustomer(string name, string email)
    {
        var customer = new Customer(_customers.Count + 1, name, email);
        _customers.Add(customer);
        return customer;
    }

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

class Program
{
    static void Main()
    {
        var shop = new Shop();

        var book = shop.AddProduct("Книга", 500, 100);
        var pen = shop.AddProduct("Ручка", 50, 200);

        var customer = shop.AddCustomer("Анна", "anna@mail.ru");

        var order = shop.CreateOrder(customer,
            (book, 2),
            (pen, 5));

        order.Pay("Карта");

        Console.WriteLine($"Заказ #{order.Id}");
        Console.WriteLine($"Клиент: {customer.Name}");
        Console.WriteLine($"Сумма: {order.Total:C}");
        Console.WriteLine($"Статус: {order.Status}");
    }
}