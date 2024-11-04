using System;
using System.Collections.Generic;

// Клас ClientRegistration
public class ClientRegistration
{
    public string ClientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string ServiceType { get; set; }
}

// Пул об'єктів для реєстрацій клієнтів
public class ClientPool
{
    private readonly List<ClientRegistration> availableRegistrations = new List<ClientRegistration>();
    private readonly List<ClientRegistration> inUseRegistrations = new List<ClientRegistration>();

    public ClientRegistration GetClientRegistration()
    {
        if (availableRegistrations.Count > 0)
        {
            var registration = availableRegistrations[0];
            availableRegistrations.RemoveAt(0);
            inUseRegistrations.Add(registration);
            return registration;
        }
        else
        {
            var newRegistration = new ClientRegistration();
            inUseRegistrations.Add(newRegistration);
            return newRegistration;
        }
    }

    public void ReleaseClientRegistration(ClientRegistration registration)
    {
        inUseRegistrations.Remove(registration);
        availableRegistrations.Add(registration);
    }
}

// Клас для керування нотаріальною конторою
public class NotaryOffice
{
    private ClientPool clientPool;

    public NotaryOffice(ClientPool pool)
    {
        clientPool = pool;
    }

    public ClientRegistration RegisterClient(string clientName, DateTime date, string service)
    {
        var registration = clientPool.GetClientRegistration();
        registration.ClientName = clientName;
        registration.AppointmentDate = date;
        registration.ServiceType = service;
        Console.WriteLine($"Зареєстровано клієнта {clientName} на {date}");
        return registration; // Повертаємо об'єкт реєстрації
    }

    public void CompleteRegistration(ClientRegistration registration)
    {
        if (!string.IsNullOrEmpty(registration.ClientName))
        {
            Console.WriteLine($"Завершено реєстрацію для {registration.ClientName}");
        }
        else
        {
            Console.WriteLine("Ім'я клієнта відсутнє!");
        }
        clientPool.ReleaseClientRegistration(registration);
    }
}

// Приклад використання
class Program
{
    static void Main(string[] args)
    {
        var pool = new ClientPool();
        var notaryOffice = new NotaryOffice(pool);

        // Реєстрація клієнта "John Doe"
        var registration1 = notaryOffice.RegisterClient("John Doe", DateTime.Now, "Notary");

        // Завершення реєстрації "John Doe"
        notaryOffice.CompleteRegistration(registration1);

        // Реєстрація клієнта "Jane Doe"
        var registration2 = notaryOffice.RegisterClient("Jane Doe", DateTime.Now.AddHours(1), "Notary");

        // Завершення реєстрації "Jane Doe"
        notaryOffice.CompleteRegistration(registration2);
    }
}
