using System;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class CreateAppointmentCommand : ICommand
{
    private NotarySystem notarySystem;
    private string clientName;
    private string serviceType;

    public CreateAppointmentCommand(NotarySystem notarySystem, string clientName, string serviceType)
    {
        this.notarySystem = notarySystem;
        this.clientName = clientName;
        this.serviceType = serviceType;
    }

    public void Execute()
    {
        notarySystem.CreateAppointment(clientName, serviceType);
    }

    public void Undo()
    {
        notarySystem.CancelAppointment(clientName);
    }
}

public class NotarySystem
{
    public void CreateAppointment(string clientName, string serviceType)
    {
        Console.WriteLine($"Appointment created for {clientName} on service: {serviceType}");
    }

    public void CancelAppointment(string clientName)
    {
        Console.WriteLine($"Appointment for {clientName} canceled.");
    }
}

public class Invoker
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void ExecuteCommand()
    {
        command.Execute();
    }

    public void UndoCommand()
    {
        command.Undo();
    }
}

class Program
{
    static void Main(string[] args)
    {
        NotarySystem notarySystem = new NotarySystem();
        ICommand createAppointment = new CreateAppointmentCommand(notarySystem, "John Doe", "Document Signing");

        Invoker invoker = new Invoker();
        invoker.SetCommand(createAppointment);

        // Виконати команду
        invoker.ExecuteCommand();

        // Скасувати команду
        invoker.UndoCommand();
    }
}