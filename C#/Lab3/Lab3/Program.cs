using System;

public class Client {
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public class Appointment {
    public DateTime Date { get; set; }
    public string Notary { get; set; }
    public Client Client { get; set; }
}

public abstract class AppointmentFactory {
    public abstract Appointment CreateAppointment(Client client, DateTime date, string notary);
}

public class ConcreteAppointmentFactory : AppointmentFactory {
    public override Appointment CreateAppointment(Client client, DateTime date, string notary) {
        return new Appointment { Client = client, Date = date, Notary = notary };
    }
}

class Program {
    static void Main() {
        AppointmentFactory factory = new ConcreteAppointmentFactory();
        Client client = new Client { Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123456789" };
        Appointment appointment = factory.CreateAppointment(client, DateTime.Now, "Notary A");
        Console.WriteLine($"Appointment for {appointment.Client.Name} with {appointment.Notary} on {appointment.Date}");
    }
}