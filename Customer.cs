using System;
using System.Collections.Generic;
using System.Text;


class Customer
{

    public string CustomerCode { get; set; }
    public string FullName { get; set; }
    public DateTime InvoiceDate { get; set; }
}

class VietnameseCustomer : Customer
{
    public string CustomerType { get; set; }
    public int ConsumedAmount { get; set; }
    public double UnitPrice { get; set; }

    public double CalculateTotalAmount()
    {
        double totalAmount = 0;
        double standardPrice = 0;

        if (ConsumedAmount <= 50)
        {
            standardPrice = 1000;
        }
        else if (ConsumedAmount <= 100)
        {
            standardPrice = 1200;
        }
        else if (ConsumedAmount <= 200)
        {
            standardPrice = 1500;
        }
        else
        {
            standardPrice = 2000;
        }

        if (ConsumedAmount <= 200)
        {
            totalAmount = ConsumedAmount * UnitPrice;
        }
        else
        {
            totalAmount = (200 * UnitPrice) + ((ConsumedAmount - 200) * standardPrice);
        }

        return totalAmount;
    }
}

class ForeignCustomer : Customer
{
    public string Nationality { get; set; }
    public int ConsumedAmount { get; set; }
    public double UnitPrice { get; set; }

    public double CalculateTotalAmount()
    {
        return ConsumedAmount * UnitPrice;
    }
}

class Program
{
    static  void Main(string[] args)
    {
        List<Customer> customers = new List<Customer>();


        VietnameseCustomer vnCustomer1 = InputVietnameseCustomer();
        customers.Add(vnCustomer1);


        ForeignCustomer foreignCustomer1 = InputForeignCustomer();
        customers.Add(foreignCustomer1);

        Console.WriteLine("Invoice List:");
        foreach (Customer customer in customers)
        {
            if (customer is VietnameseCustomer)
            {
                VietnameseCustomer vnCust = (VietnameseCustomer)customer;
                double totalAmount = vnCust.CalculateTotalAmount();
                Console.WriteLine($"Vietnamese Customer - Code: {vnCust.CustomerCode}, Name: {vnCust.FullName}, Total Amount: {totalAmount}");
            }
            else if (customer is ForeignCustomer)
            {
                ForeignCustomer foreignCust = (ForeignCustomer)customer;
                double totalAmount = foreignCust.CalculateTotalAmount();
                Console.WriteLine($"Foreign Customer - Code: {foreignCust.CustomerCode}, Name: {foreignCust.FullName}, Total Amount: {totalAmount}");
            }
        }
    }

    static VietnameseCustomer InputVietnameseCustomer()
    {
        VietnameseCustomer customer = new VietnameseCustomer();

        Console.WriteLine("Enter Vietnamese Customer Information:");
        Console.Write("Customer Code: ");
        customer.CustomerCode = Console.ReadLine();

        Console.Write("Full Name: ");
        customer.FullName = Console.ReadLine();

        Console.Write("Invoice Date (yyyy-mm-dd): ");
        customer.InvoiceDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Customer Type (sinh hoạt, kinh doanh, sản xuất): ");
        customer.CustomerType = Console.ReadLine();

        Console.Write("Consumed Amount (KW): ");
        customer.ConsumedAmount = int.Parse(Console.ReadLine());

        Console.Write("Unit Price: ");
        customer.UnitPrice = double.Parse(Console.ReadLine());

        return customer;
    }

    static ForeignCustomer InputForeignCustomer()
    {
        ForeignCustomer customer = new ForeignCustomer();

        Console.WriteLine("Enter Foreign Customer Information:");
        Console.Write("Customer Code: ");
        customer.CustomerCode = Console.ReadLine();

        Console.Write("Full Name: ");
        customer.FullName = Console.ReadLine();

        Console.Write("Invoice Date (yyyy-mm-dd): ");
        customer.InvoiceDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Nationality: ");
        customer.Nationality = Console.ReadLine();

        Console.Write("Consumed Amount (KW): ");
        customer.ConsumedAmount = int.Parse(Console.ReadLine());

        Console.Write("Unit Price: ");
        customer.UnitPrice = double.Parse(Console.ReadLine());

        return customer;
    }
}
