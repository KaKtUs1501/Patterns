using System;
using System.Collections.Generic;

// Інтерфейс суб'єкта
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Інтерфейс спостерігача
public interface IObserver
{
    void Update(string appointmentDetails);
}

// Конкретний суб'єкт (Запис на зустріч)
public class Appointment : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private string appointmentDetails;

    public string AppointmentDetails
    {
        get { return appointmentDetails; }
        set
        {
            appointmentDetails = value;
            NotifyObservers();
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(appointmentDetails);
        }
    }
}

// Конкретний спостерігач (Адміністратор)
public class Admin : IObserver
{
    private string name;

    public Admin(string name)
    {
        this.name = name;
    }

    public void Update(string appointmentDetails)
    {
        Console.WriteLine($"{name} отримав оновлення запису: {appointmentDetails}");
    }
}

// Конкретний спостерігач (Нотаріус)
public class NotaryEmployee : IObserver
{
    private string name;

    public NotaryEmployee(string name)
    {
        this.name = name;
    }

    public void Update(string appointmentDetails)
    {
        Console.WriteLine($"{name} отримав оновлення запису: {appointmentDetails}");
    }
}

public class Program
{
    public static void Main()
    {
        Appointment appointment = new Appointment();

        // Створюємо спостерігачів
        Admin admin = new Admin("Admin");
        NotaryEmployee notary = new NotaryEmployee("Notary Employee");

        // Реєструємо спостерігачів
        appointment.RegisterObserver(admin);
        appointment.RegisterObserver(notary);

        // Змінюємо стан запису і сповіщаємо спостерігачів
        appointment.AppointmentDetails = "Запис на 15 жовтня 2024, 10:00";
        
        appointment.RemoveObserver(notary);
        appointment.AppointmentDetails = "Запис перенесено на 16 жовтня 2024, 14:00";
    }
}
