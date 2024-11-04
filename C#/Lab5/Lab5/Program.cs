using System;

public class ClientRegistration
{
    public string ClientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string ServiceType { get; set; }
    public string ContactInfo { get; set; }
}

public interface IClientRegistrationBuilder
{
    void SetClientName(string name);
    void SetAppointmentDate(DateTime date);
    void SetServiceType(string service);
    void SetContactInfo(string contactInfo);
    ClientRegistration Build();
}

public class StandardRegistrationBuilder : IClientRegistrationBuilder
{
    private ClientRegistration _registration = new ClientRegistration();

    public void SetClientName(string name) { _registration.ClientName = name; }
    public void SetAppointmentDate(DateTime date) { _registration.AppointmentDate = date; }
    public void SetServiceType(string service) { _registration.ServiceType = service; }
    public void SetContactInfo(string contactInfo) { _registration.ContactInfo = contactInfo; }
    public ClientRegistration Build() { return _registration; }
}

public class VIPRegistrationBuilder : IClientRegistrationBuilder
{
    private ClientRegistration _registration = new ClientRegistration();

    public void SetClientName(string name) 
    { 
        _registration.ClientName = $"VIP: {name}";  
    }

    public void SetAppointmentDate(DateTime date) 
    { 
        _registration.AppointmentDate = date; 
    }

    public void SetServiceType(string service) 
    { 
        _registration.ServiceType = $"VIP {service}";  
    }

    public void SetContactInfo(string contactInfo) 
    { 
        _registration.ContactInfo = contactInfo; 
    }

    public ClientRegistration Build() 
    { 
        return _registration; 
    }
}

public class RegistrationDirector
{
    private IClientRegistrationBuilder _builder;

    public RegistrationDirector(IClientRegistrationBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructStandardRegistration(string name, DateTime date, string service, string contactInfo)
    {
        _builder.SetClientName(name);
        _builder.SetAppointmentDate(date);
        _builder.SetServiceType(service);
        _builder.SetContactInfo(contactInfo);
    }

    public ClientRegistration GetResult()
    {
        return _builder.Build();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Використання стандартного будівельника
        var standardBuilder = new StandardRegistrationBuilder();
        var director = new RegistrationDirector(standardBuilder);
        director.ConstructStandardRegistration("John Doe", DateTime.Now, "Notary", "123-456-789");
        ClientRegistration standardRegistration = director.GetResult();
        Console.WriteLine($"Клієнт: {standardRegistration.ClientName}, Дата: {standardRegistration.AppointmentDate}, Послуга: {standardRegistration.ServiceType}");

        // Використання VIP реєстрації
        var vipBuilder = new VIPRegistrationBuilder();
        director = new RegistrationDirector(vipBuilder);  // Використовуємо VIP будівельника
        director.ConstructStandardRegistration("Jane Doe", DateTime.Now, "Notary", "987-654-321");
        ClientRegistration vipRegistration = director.GetResult();
        Console.WriteLine($"Клієнт: {vipRegistration.ClientName}, Дата: {vipRegistration.AppointmentDate}, Послуга: {vipRegistration.ServiceType}");
    }
}