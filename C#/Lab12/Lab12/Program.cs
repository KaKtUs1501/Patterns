using System;
using System.Collections.Generic;

public class ClientFlyweight
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Address { get; private set; }

    public ClientFlyweight(string name, string surname, string address)
    {
        Name = name;
        Surname = surname;
        Address = address;
    }

    public void DisplayClientInfo(string appointmentDate, string serviceType)
    {
        Console.WriteLine($"Client: {Name} {Surname}, Address: {Address}, Appointment: {appointmentDate}, Service: {serviceType}");
    }
}

public class ClientFactory
{
    private Dictionary<string, ClientFlyweight> clients = new Dictionary<string, ClientFlyweight>();

    public ClientFlyweight GetClient(string name, string surname, string address)
    {
        string key = $"{name}-{surname}-{address}";
        if (!clients.ContainsKey(key))
        {
            clients[key] = new ClientFlyweight(name, surname, address);
        }
        return clients[key];
    }
}

public class NotaryAppointment
{
    private ClientFlyweight client;
    private string appointmentDate;
    private string serviceType;

    public NotaryAppointment(ClientFlyweight client, string appointmentDate, string serviceType)
    {
        this.client = client;
        this.appointmentDate = appointmentDate;
        this.serviceType = serviceType;
    }

    public void DisplayAppointmentInfo()
    {
        client.DisplayClientInfo(appointmentDate, serviceType);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ClientFactory clientFactory = new ClientFactory();
        ClientFlyweight client1 = clientFactory.GetClient("John", "Doe", "123 Main St");
        NotaryAppointment appointment1 = new NotaryAppointment(client1, "2024-10-15", "Document Signing");
        appointment1.DisplayAppointmentInfo();

        ClientFlyweight client2 = clientFactory.GetClient("Jane", "Smith", "456 Oak St");
        NotaryAppointment appointment2 = new NotaryAppointment(client2, "2024-10-16", "Consultation");
        appointment2.DisplayAppointmentInfo();
        
        NotaryAppointment appointment3 = new NotaryAppointment(client1, "2024-10-17", "Will Preparation");
        appointment3.DisplayAppointmentInfo();
    }
}

