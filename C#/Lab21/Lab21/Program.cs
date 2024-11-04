using System;

// Інтерфейс стратегії
public interface IAppointmentStrategy
{
    void ProcessAppointment(string clientName);
}

// Контекст (Система запису клієнтів)
public class AppointmentSystem
{
    private IAppointmentStrategy _strategy;

    public void SetStrategy(IAppointmentStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Process(string clientName)
    {
        _strategy.ProcessAppointment(clientName);
    }
}

// Стратегія онлайн-запису
public class OnlineStrategy : IAppointmentStrategy
{
    public void ProcessAppointment(string clientName)
    {
        Console.WriteLine($"Обробка онлайн-запису для клієнта {clientName}");
    }
}

// Стратегія телефонного запису
public class PhoneStrategy : IAppointmentStrategy
{
    public void ProcessAppointment(string clientName)
    {
        Console.WriteLine($"Обробка телефонного запису для клієнта {clientName}");
    }
}

// Стратегія особистого запису
public class InPersonStrategy : IAppointmentStrategy
{
    public void ProcessAppointment(string clientName)
    {
        Console.WriteLine($"Обробка запису при особистому візиті для клієнта {clientName}");
    }
}

// Головна програма
class Program
{
    static void Main()
    {
        AppointmentSystem system = new AppointmentSystem();

        // Використання стратегії для онлайн-запису
        system.SetStrategy(new OnlineStrategy());
        system.Process("John Doe");

        // Використання стратегії для телефонного запису
        system.SetStrategy(new PhoneStrategy());
        system.Process("Jane Smith");

        // Використання стратегії для особистого запису
        system.SetStrategy(new InPersonStrategy());
        system.Process("Alice Johnson");
    }
}