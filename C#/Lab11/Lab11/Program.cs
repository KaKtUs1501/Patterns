using System;

// Підсистема перевірки документів
public class DocumentVerificationSubsystem
{
    public void VerifyDocuments(string clientData)
    {
        Console.WriteLine("Verifying documents for " + clientData);
    }
}

// Підсистема бронювання
public class AppointmentBookingSubsystem
{
    public void BookAppointment(string clientData)
    {
        Console.WriteLine("Booking appointment for " + clientData);
    }
}

// Підсистема сповіщень
public class NotificationSubsystem
{
    public void SendNotification(string clientData)
    {
        Console.WriteLine("Sending notification to " + clientData);
    }
}

// Підсистема архівування
public class ArchiveSubsystem
{
    public void SaveClientRecord(string clientData)
    {
        Console.WriteLine("Saving client record for " + clientData);
    }
}

// Фасад
public class NotaryFacade
{
    private DocumentVerificationSubsystem _docVerification;
    private AppointmentBookingSubsystem _booking;
    private NotificationSubsystem _notification;
    private ArchiveSubsystem _archive;

    public NotaryFacade()
    {
        _docVerification = new DocumentVerificationSubsystem();
        _booking = new AppointmentBookingSubsystem();
        _notification = new NotificationSubsystem();
        _archive = new ArchiveSubsystem();
    }

    public void RegisterClient(string clientData)
    {
        _docVerification.VerifyDocuments(clientData);
        _booking.BookAppointment(clientData);
        _notification.SendNotification(clientData);
        _archive.SaveClientRecord(clientData);
    }
}

// Використання фасаду
class Program
{
    static void Main(string[] args)
    {
        NotaryFacade facade = new NotaryFacade();
        facade.RegisterClient("John Doe");
    }
}