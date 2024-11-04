using System;

public interface IClientData
{
    void GetClientInfo();
}

public class ClientData : IClientData
{
    private string name;
    private string surname;
    private string address;

    public ClientData(string name, string surname, string address)
    {
        this.name = name;
        this.surname = surname;
        this.address = address;
    }

    public void GetClientInfo()
    {
        Console.WriteLine($"Client: {name} {surname}, Address: {address}");
    }
}

public class ClientDataProxy : IClientData
{
    private ClientData clientData;
    private string userRole;

    public ClientDataProxy(string name, string surname, string address, string userRole)
    {
        clientData = new ClientData(name, surname, address);
        this.userRole = userRole;
    }

    public void GetClientInfo()
    {
        if (userRole == "admin")
        {
            clientData.GetClientInfo();
        }
        else
        {
            Console.WriteLine("Access denied. You do not have the required permissions.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IClientData clientProxy = new ClientDataProxy("John", "Doe", "123 Main St", "admin");
        clientProxy.GetClientInfo();

        IClientData clientProxyUser = new ClientDataProxy("Jane", "Smith", "456 Oak St", "user");
        clientProxyUser.GetClientInfo();
    }
}