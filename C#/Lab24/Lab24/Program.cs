using System;

// Клас клієнта (Інформаційний експерт)
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

// Інтерфейс для стратегій реєстрації (Поліморфізм)
interface RegistrationStrategy
{
    void Register(Client client);
}

// Реалізація стандартної реєстрації
class StandardRegistration : RegistrationStrategy
{
    public void Register(Client client)
    {
        Console.WriteLine($"Реєстрація стандартного клієнта: {client.Name} {client.Surname}");
        // Додаткова логіка для стандартної реєстрації
    }
}

// Реалізація VIP реєстрації
class VIPRegistration : RegistrationStrategy
{
    public void Register(Client client)
    {
        Console.WriteLine($"Реєстрація VIP клієнта: {client.Name} {client.Surname}");
        // Додаткова логіка для VIP реєстрації
    }
}

// Контролер, який управляє реєстрацією клієнтів (Контролер та Перенаправлення)
class RegistrationController
{
    private readonly RegistrationStrategy _strategy;
    private readonly Logger _logger;

    public RegistrationController(RegistrationStrategy strategy, Logger logger)
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

// Служба сповіщення клієнтів (Штучний об’єкт)
class NotificationService
{
    public void Notify(Client client, string message)
    {
        Console.WriteLine($"Надсилання повідомлення клієнту {client.Name}: {message}");
    }
}

// Логгер для збереження інформації про події (Штучний об’єкт)
class Logger
{
    public void Log(string message)
    {
        Console.WriteLine($"ЛОГ: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення клієнтів
        Client client1 = new Client("Олег", "Петров", "oleg@example.com", "+380501234567", false);
        Client client2 = new Client("Анна", "Іванова", "anna@example.com", "+380671234567", true);

        // Створення логера
        Logger logger = new Logger();

        // Вибір стратегії та створення контролера
        RegistrationController controller1 = new RegistrationController(new StandardRegistration(), logger);
        RegistrationController controller2 = new RegistrationController(new VIPRegistration(), logger);

        // Реєстрація клієнтів
        controller1.RegisterClient(client1);
        controller2.RegisterClient(client2);

        // Створення служби сповіщення
        NotificationService notificationService = new NotificationService();

        // Надсилання сповіщень клієнтам
        notificationService.Notify(client1, "Ваш запис підтверджено.");
        notificationService.Notify(client2, "Дякуємо за використання VIP-сервісу!");
    }
}
