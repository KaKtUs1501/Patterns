using System;

// Інтерфейс стану
public interface IState
{
    void Confirm(Appointment appointment);
    void Cancel(Appointment appointment);
    void Complete(Appointment appointment);
}

// Контекст (Запис клієнта)
public class Appointment
{
    private IState _state;

    public Appointment(IState state)
    {
        _state = state;
    }

    public void SetState(IState state)
    {
        _state = state;
    }

    public void Confirm()
    {
        _state.Confirm(this);
    }

    public void Cancel()
    {
        _state.Cancel(this);
    }

    public void Complete()
    {
        _state.Complete(this);
    }
}

// Стан "Заплановано"
public class ScheduledState : IState
{
    public void Confirm(Appointment appointment)
    {
        Console.WriteLine("Запис вже підтверджено.");
    }

    public void Cancel(Appointment appointment)
    {
        Console.WriteLine("Запис скасовано.");
        appointment.SetState(new CancelledState());
    }

    public void Complete(Appointment appointment)
    {
        Console.WriteLine("Запис виконано.");
        appointment.SetState(new CompletedState());
    }
}

// Стан "Скасовано"
public class CancelledState : IState
{
    public void Confirm(Appointment appointment)
    {
        Console.WriteLine("Неможливо підтвердити скасований запис.");
    }

    public void Cancel(Appointment appointment)
    {
        Console.WriteLine("Запис вже скасовано.");
    }

    public void Complete(Appointment appointment)
    {
        Console.WriteLine("Неможливо завершити скасований запис.");
    }
}

// Стан "Завершено"
public class CompletedState : IState
{
    public void Confirm(Appointment appointment)
    {
        Console.WriteLine("Запис вже завершено, підтвердження не потрібне.");
    }

    public void Cancel(Appointment appointment)
    {
        Console.WriteLine("Неможливо скасувати завершений запис.");
    }

    public void Complete(Appointment appointment)
    {
        Console.WriteLine("Запис вже завершено.");
    }
}

// Головна програма
class Program
{
    static void Main()
    {
        Appointment appointment = new Appointment(new ScheduledState());

        // Запис заплановано
        appointment.Confirm(); // "Запис вже підтверджено."
        appointment.Complete(); // "Запис виконано."

        // Запис завершено
        appointment.Cancel(); // "Неможливо скасувати завершений запис."
    }
}
