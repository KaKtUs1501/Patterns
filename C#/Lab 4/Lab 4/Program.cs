using System;

public class Client {
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public abstract class Appointment {
    public DateTime Date { get; set; }
    public Client Client { get; set; }
    public abstract void Schedule();
}

public class StandardAppointment : Appointment {
    public override void Schedule() {
        Console.WriteLine("Standard appointment scheduled.");
    }
}

public class VIPAppointment : Appointment {
    public override void Schedule() {
        Console.WriteLine("VIP appointment scheduled with extra services.");
    }
}

public abstract class AppointmentFactory {
    public abstract Appointment CreateAppointment(Client client, DateTime date);
}

public class StandardAppointmentFactory : AppointmentFactory {
    public override Appointment CreateAppointment(Client client, DateTime date) {
        return new StandardAppointment { Client = client, Date = date };
    }
}

public class VIPAppointmentFactory : AppointmentFactory {
    public override Appointment CreateAppointment(Client client, DateTime date) {
        return new VIPAppointment { Client = client, Date = date };
    }
}

class Program {
    static void Main() {
        AppointmentFactory factory = new StandardAppointmentFactory();
        Client client = new Client { Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123456789" };
        Appointment appointment = factory.CreateAppointment(client, DateTime.Now);
        appointment.Schedule();
    }
}