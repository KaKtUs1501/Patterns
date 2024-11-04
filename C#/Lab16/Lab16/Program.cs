using System;
using System.Collections.Generic;

// Клас для запису про клієнта
public abstract class ClientRecord
{
    public string Name { get; set; }
    public string AppointmentTime { get; set; }
    public ClientRecord(string name, string time)
    {
        Name = name;
        AppointmentTime = time;
    }
}

// Клас для фізичних осіб
public class IndividualClientRecord : ClientRecord
{
    public IndividualClientRecord(string name, string time) : base(name, time) { }
}

// Клас для юридичних осіб
public class CorporateClientRecord : ClientRecord
{
    public CorporateClientRecord(string name, string time) : base(name, time) { }
}

// Інтерфейс ітератора
public interface IClientIterator
{
    bool HasNext();
    ClientRecord Next();
}

// Колекція записів про клієнтів
public class ClientRecordsCollection
{
    private List<ClientRecord> _clientRecords = new List<ClientRecord>();

    public void AddClient(ClientRecord client)
    {
        _clientRecords.Add(client);
    }

    public IClientIterator CreateIndividualIterator()
    {
        return new IndividualClientIterator(_clientRecords);
    }

    public IClientIterator CreateCorporateIterator()
    {
        return new CorporateClientIterator(_clientRecords);
    }

    public IClientIterator CreateAllClientsIterator()
    {
        return new AllClientsIterator(_clientRecords);
    }
}

// Ітератор для фізичних осіб
public class IndividualClientIterator : IClientIterator
{
    private List<ClientRecord> _clientRecords;
    private int _position = 0;

    public IndividualClientIterator(List<ClientRecord> clientRecords)
    {
        _clientRecords = clientRecords;
    }

    public bool HasNext()
    {
        while (_position < _clientRecords.Count)
        {
            if (_clientRecords[_position] is IndividualClientRecord)
                return true;
            _position++;
        }
        return false;
    }

    public ClientRecord Next()
    {
        return _clientRecords[_position++];
    }
}

// Ітератор для юридичних осіб
public class CorporateClientIterator : IClientIterator
{
    private List<ClientRecord> _clientRecords;
    private int _position = 0;

    public CorporateClientIterator(List<ClientRecord> clientRecords)
    {
        _clientRecords = clientRecords;
    }

    public bool HasNext()
    {
        while (_position < _clientRecords.Count)
        {
            if (_clientRecords[_position] is CorporateClientRecord)
                return true;
            _position++;
        }
        return false;
    }

    public ClientRecord Next()
    {
        return _clientRecords[_position++];
    }
}

// Ітератор для всіх записів
public class AllClientsIterator : IClientIterator
{
    private List<ClientRecord> _clientRecords;
    private int _position = 0;

    public AllClientsIterator(List<ClientRecord> clientRecords)
    {
        _clientRecords = clientRecords;
    }

    public bool HasNext()
    {
        return _position < _clientRecords.Count;
    }

    public ClientRecord Next()
    {
        return _clientRecords[_position++];
    }
}

class Program
{
    static void Main(string[] args)
    {
        ClientRecordsCollection collection = new ClientRecordsCollection();
        collection.AddClient(new IndividualClientRecord("John Doe", "10:00 AM"));
        collection.AddClient(new CorporateClientRecord("ABC Corp", "11:00 AM"));
        collection.AddClient(new IndividualClientRecord("Jane Smith", "12:00 PM"));

        // Ітерація фізичних осіб
        IClientIterator individualIterator = collection.CreateIndividualIterator();
        Console.WriteLine("Individual Clients:");
        while (individualIterator.HasNext())
        {
            ClientRecord client = individualIterator.Next();
            Console.WriteLine($"Client: {client.Name}, Appointment: {client.AppointmentTime}");
        }

        // Ітерація юридичних осіб
        IClientIterator corporateIterator = collection.CreateCorporateIterator();
        Console.WriteLine("\nCorporate Clients:");
        while (corporateIterator.HasNext())
        {
            ClientRecord client = corporateIterator.Next();
            Console.WriteLine($"Client: {client.Name}, Appointment: {client.AppointmentTime}");
        }

        // Ітерація всіх клієнтів
        IClientIterator allClientsIterator = collection.CreateAllClientsIterator();
        Console.WriteLine("\nAll Clients:");
        while (allClientsIterator.HasNext())
        {
            ClientRecord client = allClientsIterator.Next();
            Console.WriteLine($"Client: {client.Name}, Appointment: {client.AppointmentTime}");
        }
    }
}
