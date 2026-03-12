public interface IPaymentStrategy
{
    void Pay(double amount);
}
public class CreditCardPayment:IPaymentStrategy
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} using Credit card");
    }
}

public class PayPalPayment:IPaymentStrategy
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} using paypal");
    }
}

public class CashPayment:IPaymentStrategy
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} using Cash.");
    }
}

//Context Class
public class PaymentContext
{
    private IPaymentStrategy _paymentStrategy;
    public PaymentContext(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy=paymentStrategy;
    }
    public void ExecutePayment(double amount)
    {
        _paymentStrategy.Pay(amount);
    }
}

class Program
{
    static void Main()
    {
        // Credit card payment
        PaymentContext payment1=new PaymentContext(new CreditCardPayment());
        payment1.ExecutePayment(100);

        // Paypal Payment
        PaymentContext payment2 = new PaymentContext(new PayPalPayment());
        payment2.ExecutePayment(200);

        // Cash payment
        PaymentContext payment3 = new PaymentContext(new CashPayment());
        payment3.ExecutePayment(300);
    }
}
