using System;
using System.Collections.Generic;

// Інтерфейс для компонентів (записів)
public interface INotaryRecord
{
    void DisplayDetails();
}

// Листовий елемент (окрема заявка)
public class ClientRecord : INotaryRecord
{
    private string _clientName;

    public ClientRecord(string clientName)
    {
        _clientName = clientName;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Client: {_clientName}");
    }
}

// Композитний елемент (група заявок)
public class CompositeClientRecord : INotaryRecord
{
    private List<INotaryRecord> _clientRecords = new List<INotaryRecord>();

    public void AddRecord(INotaryRecord record)
    {
        _clientRecords.Add(record);
    }

    public void RemoveRecord(INotaryRecord record)
    {
        _clientRecords.Remove(record);
    }

    public void DisplayDetails()
    {
        foreach (var record in _clientRecords)
        {
            record.DisplayDetails();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Індивідуальні заявки
        INotaryRecord client1 = new ClientRecord("John Doe");
        INotaryRecord client2 = new ClientRecord("Jane Smith");

        // Група клієнтів
        CompositeClientRecord group = new CompositeClientRecord();
        group.AddRecord(client1);
        group.AddRecord(client2);

        // Ще одна заявка
        INotaryRecord client3 = new ClientRecord("Alice Johnson");

        // Основна група
        CompositeClientRecord mainGroup = new CompositeClientRecord();
        mainGroup.AddRecord(group);
        mainGroup.AddRecord(client3);

        // Виведення інформації
        mainGroup.DisplayDetails();
        
        mainGroup.RemoveRecord(client3);
        mainGroup.DisplayDetails();
    }
}