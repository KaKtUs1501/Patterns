using System;

// Інтерфейс посередника
public interface IMediator
{
    void SendMessage(string message, Participant participant);
}

// Абстрактний клас учасника
public abstract class Participant
{
    protected IMediator _mediator;
    public string Name { get; set; }

    public Participant(IMediator mediator, string name)
    {
        _mediator = mediator;
        Name = name;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

// Клас для клієнтів
public class Client : Participant
{
    public Client(IMediator mediator, string name) : base(mediator, name) { }

    public override void Send(string message)
    {
        Console.WriteLine($"{Name} (Client) sends message: {message}");
        _mediator.SendMessage(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{Name} (Client) receives message: {message}");
    }
}

// Клас для нотаріусів
public class NotaryEmployee : Participant
{
    public NotaryEmployee(IMediator mediator, string name) : base(mediator, name) { }

    public override void Send(string message)
    {
        Console.WriteLine($"{Name} (Notary Employee) sends message: {message}");
        _mediator.SendMessage(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{Name} (Notary Employee) receives message: {message}");
    }
}

// Клас для адміністратора
public class Admin : Participant
{
    public Admin(IMediator mediator, string name) : base(mediator, name) { }

    public override void Send(string message)
    {
        Console.WriteLine($"{Name} (Admin) sends message: {message}");
        _mediator.SendMessage(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{Name} (Admin) receives message: {message}");
    }
}

// Реалізація посередника
public class NotaryOfficeMediator : IMediator
{
    private Client _client;
    private NotaryEmployee _notaryEmployee;
    private Admin _admin;

    public void RegisterClient(Client client)
    {
        _client = client;
    }

    public void RegisterNotaryEmployee(NotaryEmployee notaryEmployee)
    {
        _notaryEmployee = notaryEmployee;
    }

    public void RegisterAdmin(Admin admin)
    {
        _admin = admin;
    }

    public void SendMessage(string message, Participant participant)
    {
        if (participant is Client)
        {
            _notaryEmployee.Receive(message);
        }
        else if (participant is NotaryEmployee)
        {
            _client.Receive(message);
        }
        else if (participant is Admin)
        {
            _client.Receive(message);
            _notaryEmployee.Receive(message);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        NotaryOfficeMediator mediator = new NotaryOfficeMediator();

        Client client = new Client(mediator, "John Doe");
        NotaryEmployee notaryEmployee = new NotaryEmployee(mediator, "Jane Smith");
        Admin admin = new Admin(mediator, "Admin");

        mediator.RegisterClient(client);
        mediator.RegisterNotaryEmployee(notaryEmployee);
        mediator.RegisterAdmin(admin);

        client.Send("I want to schedule an appointment.");
        notaryEmployee.Send("Appointment confirmed.");
        admin.Send("Reminder for upcoming appointments.");
    }
}
