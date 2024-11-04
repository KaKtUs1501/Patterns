using System;

// Інтерфейс нової системи реєстрації
public interface IClientRegistration
{
    void Register(string clientName, DateTime date, string serviceType);
}

// Старий API для реєстрації
public class OldClientService
{
    public void AddClientInfo(string fullName, DateTime appointment, string service)
    {
        Console.WriteLine($"[Старий API] Додано клієнта {fullName}, дата: {appointment}, послуга: {service}");
    }
}

// Адаптер для старого API
public class ClientAdapter : IClientRegistration
{
    private OldClientService _oldService;

    public ClientAdapter(OldClientService oldService)
    {
        _oldService = oldService;
    }

    public void Register(string clientName, DateTime date, string serviceType)
    {
        Console.WriteLine($"[Адаптер] Перетворюємо новий інтерфейс для клієнта {clientName}");
        _oldService.AddClientInfo(clientName, date, serviceType);
    }
}

// Клас нотаріальної контори
public class NotaryOffice
{
    private IClientRegistration _registration;

    public NotaryOffice(IClientRegistration registration)
    {
        _registration = registration;
    }

    public void RegisterClient(string clientName, DateTime date, string service)
    {
        Console.WriteLine($"[Нова система] Реєструємо клієнта {clientName}");
        _registration.Register(clientName, date, service);
    }
}

// Тестування
class Program
{
    static void Main(string[] args)
    {
        OldClientService oldService = new OldClientService();
        IClientRegistration adapter = new ClientAdapter(oldService);

        NotaryOffice office = new NotaryOffice(adapter);
        office.RegisterClient("John Doe", DateTime.Now, "Notary");
    }
}