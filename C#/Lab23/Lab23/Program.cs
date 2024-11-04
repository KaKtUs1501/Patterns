using System;

interface ClientElement
{
    void Accept(Visitor visitor);
}

class StandardClient : ClientElement
{
    public string Name { get; set; }
    public void Accept(Visitor visitor)
    {
        visitor.VisitStandardClient(this);
    }
}

class VIPClient : ClientElement
{
    public string Name { get; set; }
    public void Accept(Visitor visitor)
    {
        visitor.VisitVIPClient(this);
    }
}

interface Visitor
{
    void VisitStandardClient(StandardClient standardClient);
    void VisitVIPClient(VIPClient vipClient);
}

class RegistrationVisitor : Visitor
{
    public void VisitStandardClient(StandardClient standardClient)
    {
        Console.WriteLine($"Реєстрація стандартного клієнта: {standardClient.Name}");
    }

    public void VisitVIPClient(VIPClient vipClient)
    {
        Console.WriteLine($"Реєстрація VIP клієнта: {vipClient.Name}");
    }
}

class NotificationVisitor : Visitor
{
    public void VisitStandardClient(StandardClient standardClient)
    {
        Console.WriteLine($"Надсилання сповіщення стандартному клієнту: {standardClient.Name}");
    }

    public void VisitVIPClient(VIPClient vipClient)
    {
        Console.WriteLine($"Надсилання сповіщення VIP клієнту: {vipClient.Name}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ClientElement client1 = new StandardClient { Name = "Олег" };
        ClientElement client2 = new VIPClient { Name = "Анна" };

        Visitor registrationVisitor = new RegistrationVisitor();
        Visitor notificationVisitor = new NotificationVisitor();

        client1.Accept(registrationVisitor);
        client1.Accept(notificationVisitor);

        client2.Accept(registrationVisitor);
        client2.Accept(notificationVisitor);
    }
}