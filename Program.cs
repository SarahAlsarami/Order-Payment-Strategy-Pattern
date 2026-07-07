public class Order
{
    public string CustomerName { get; set; }
    public double Amount { get; set; }

    public Order(string customerName, double amount)
    {
        CustomerName = customerName;
        Amount = amount;
    }
}
public interface IPaymentStrategy
{
    void Pay(double amount);
}
public class CashPayment : IPaymentStrategy
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} SAR using Cash.");
    }
}
public class CardPayment : IPaymentStrategy
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} SAR using Card.");
    }
}
public class ApplePayPayment : IPaymentStrategy
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} SAR using Apple Pay.");
    }
}
public class StcPayPayment : IPaymentStrategy
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} SAR using STC Pay.");
    }
}




public class OrderService
{
    private IPaymentStrategy _paymentStrategy;
    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }
    public void Checkout(double amount)
    {
        _paymentStrategy.Pay(amount);
    }
    // public void Checkout(Order order, string paymentType)
    // {
    //     Console.WriteLine($"Customer: {order.CustomerName}");
    //     Console.WriteLine($"Amount: {order.Amount} SAR");

    //     if (paymentType == "cash")
    //     {
    //         Console.WriteLine("Payment method: Cash");
    //         Console.WriteLine("Payment completed successfully.");
    //     }
    //     else if (paymentType == "card")
    //     {
    //         Console.WriteLine("Payment method: Card");
    //         Console.WriteLine("Card payment completed successfully.");
    //     }
    //     else if (paymentType == "applepay")
    //     {
    //         Console.WriteLine("Payment method: Apple Pay");
    //         Console.WriteLine("Apple Pay payment completed successfully.");
    //     }
    //     else  if (paymentType == "applepay")
    //     {
    //         Console.WriteLine("Payment method: Apple Pay");
    //         Console.WriteLine("Apple Pay payment completed successfully.");
    //     }
    //     else if (paymentType == "stcpay")
    //     {
    //         Console.WriteLine("Payment method: STC Pay");
    //         Console.WriteLine("STC Pay payment completed successfully.");
    //     }
    //     else
    //     {
    //         Console.WriteLine("Invalid payment method.");
    //     }
    }
    public class Program
{
    public static void Main(string[] args)
    {
        OrderService orderService = new OrderService();
        //before adding the new payment strategy
        // orderService.Checkout(order1, "cash");
        // orderService.Checkout(order2, "card");
        // orderService.Checkout(order3, "applepay");
        Order order1 = new Order("Sarah", 100);
        orderService.SetPaymentStrategy(new CashPayment());
        orderService.Checkout(order1.Amount);

        Order order2 = new Order("Lama", 250);
        orderService.SetPaymentStrategy(new CardPayment());
        orderService.Checkout(order2.Amount);
        Order order3 = new Order("Rana", 75);
        orderService.SetPaymentStrategy(new ApplePayPayment());
        orderService.Checkout(order3.Amount);
   

        // orderService.Checkout(order4, "stcpay");
        //after adding the new payment strategy
        Order order4 = new Order("Nora", 300);
        orderService.SetPaymentStrategy(new StcPayPayment());
        orderService.Checkout(order4.Amount);

    }}
}