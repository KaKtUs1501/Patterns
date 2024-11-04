using System;

public abstract class RequestHandler
{
    protected RequestHandler nextHandler;

    public void SetNext(RequestHandler next)
    {
        nextHandler = next;
    }

    public abstract void HandleRequest(ClientRequest request);
}

public class ClientRequest
{
    public string ClientName { get; set; }
    public string ServiceType { get; set; }

    public ClientRequest(string clientName, string serviceType)
    {
        ClientName = clientName;
        ServiceType = serviceType;
    }
}

public class AuthorizationHandler : RequestHandler
{
    public override void HandleRequest(ClientRequest request)
    {
        if (request.ClientName == "authorizedUser")
        {
            Console.WriteLine("Authorization successful.");
            nextHandler?.HandleRequest(request);
        }
        else
        {
            Console.WriteLine("Authorization failed.");
        }
    }
}

public class ServiceValidationHandler : RequestHandler
{
    public override void HandleRequest(ClientRequest request)
    {
        if (request.ServiceType == "Document Signing")
        {
            Console.WriteLine("Service is available.");
            nextHandler?.HandleRequest(request);
        }
        else
        {
            Console.WriteLine("Service not available.");
        }
    }
}

public class AppointmentCreationHandler : RequestHandler
{
    public override void HandleRequest(ClientRequest request)
    {
        Console.WriteLine($"Appointment created for {request.ClientName} on service: {request.ServiceType}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        AuthorizationHandler authHandler = new AuthorizationHandler();
        ServiceValidationHandler serviceHandler = new ServiceValidationHandler();
        AppointmentCreationHandler appointmentHandler = new AppointmentCreationHandler();

        // Встановлюємо порядок у ланцюжку
        authHandler.SetNext(serviceHandler);
        serviceHandler.SetNext(appointmentHandler);
        
        ClientRequest request = new ClientRequest("authorizedUser", "Document Signing");

        // Передаємо запит через ланцюжок
        authHandler.HandleRequest(request);
    }
}
