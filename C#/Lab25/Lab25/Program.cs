using System;
using System.Collections.Generic;

#region Модель даних (Client) - SRP, KISS, YAGNI
class Client
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool IsVIP { get; set; }

    public Client(string name, string surname, string email, string phone, bool isVIP)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Phone = phone;
        IsVIP = isVIP;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Клієнт: {Name} {Surname}, Email: {Email}, Телефон: {Phone}, VIP: {IsVIP}");
    }
}
// YAGNI: Ми не додаємо зайвих полів чи методів, які поки не потрібні.
// KISS: Клас простий та зрозумілий.
#endregion

#region Інтерфейс стратегії реєстрації (OCP, DIP, LSP)
interface IRegistrationStrategy
{
    void Register(Client client);
}

class StandardRegistration : IRegistrationStrategy
{
    public void Register(Client client)
    {
        Console.WriteLine($"Реєстрація стандартного клієнта: {client.Name} {client.Surname}");
    }
}

class VIPRegistration : IRegistrationStrategy
{
    public void Register(Client client)
    {
        Console.WriteLine($"Реєстрація VIP клієнта: {client.Name} {client.Surname}");
    }
}
#endregion

#region Логгер (Pure Fabrication)
interface ILogger
{
    void Log(string message);
}

class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"ЛОГ: {message}");
    }
}
#endregion

#region Служба сповіщень (Pure Fabrication, DIP)
interface INotifier
{
    void Notify(Client client, string message);
}

class EmailNotifier : INotifier
{
    public void Notify(Client client, string message)
    {
        Console.WriteLine($"Email до {client.Email}: {message}");
    }
}
#endregion

#region Контролер (Controller, Indirection)
class RegistrationController
{
    private readonly IRegistrationStrategy _strategy;
    private readonly ILogger _logger;

    public RegistrationController(IRegistrationStrategy strategy, ILogger logger)
    {
        _strategy = strategy;
        _logger = logger;
    }

    public void RegisterClient(Client client)
    {
        try
        {
            _strategy.Register(client);
            _logger.Log($"Клієнт {client.Name} {client.Surname} успішно зареєстрований.");
        }
        catch (Exception ex)
        {
            _logger.Log($"Помилка реєстрації клієнта: {ex.Message}");
        }
    }
}
#endregion

#region Репозиторій клієнтів (APO, BDUF)
class ClientRepository
{
    public List<Client> GetAllClients()
    {
        // Простий метод отримання клієнтів (APO - уникнення передчасної оптимізації)
        return new List<Client>
        {
            new Client("Олег", "Петров", "oleg@example.com", "+380501234567", false),
            new Client("Анна", "Іванова", "anna@example.com", "+380671234567", true)
        };
    }
}
#endregion

#region Головна програма (Бритва Оккама)
class Program
{
    static void Main(string[] args)
    {
        // Створення логера та нотифікатора
        ILogger logger = new ConsoleLogger();
        INotifier notifier = new EmailNotifier();

        // Отримання клієнтів з репозиторію
        ClientRepository repository = new ClientRepository();
        List<Client> clients = repository.GetAllClients();

        // Реєстрація та сповіщення клієнтів
        foreach (var client in clients)
        {
            // Вибір стратегії на основі типу клієнта
            IRegistrationStrategy strategy = client.IsVIP ? 
                (IRegistrationStrategy)
                new VIPRegistration() : new StandardRegistration();

            // Створення контролера
            RegistrationController controller = new RegistrationController(strategy, logger);

            // Реєстрація клієнта
            controller.RegisterClient(client);

            // Надсилання сповіщення
            notifier.Notify(client, "Ваш запис підтверджено.");
        }
    }
}
#endregion
