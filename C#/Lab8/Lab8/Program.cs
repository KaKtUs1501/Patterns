using System;

// Інтерфейс реалізації
public interface IClientRegistrationImplementor
{
    void RegisterClient(string clientName, DateTime date, string service);
    void CompleteClientRegistration();
}

// Конкретна реалізація для Email
public class EmailRegistrationImplementor : IClientRegistrationImplementor
{
    public void RegisterClient(string clientName, DateTime date, string service)
    {
        Console.WriteLine($"[Email] Реєстрація клієнта {clientName} на {date} для послуги {service}");
    }

    public void CompleteClientRegistration()
    {
        Console.WriteLine("[Email] Завершено реєстрацію клієнта");
    }
}

// Конкретна реалізація для SMS
public class SmsRegistrationImplementor : IClientRegistrationImplementor
{
    public void RegisterClient(string clientName, DateTime date, string service)
    {
        Console.WriteLine($"[SMS] Реєстрація клієнта {clientName} на {date} для послуги {service}");
    }

    public void CompleteClientRegistration()
    {
        Console.WriteLine("[SMS] Завершено реєстрацію клієнта");
    }
}

// Абстракція
public abstract class ClientRegistrationBridge
{
    protected IClientRegistrationImplementor _implementor;

    protected ClientRegistrationBridge(IClientRegistrationImplementor implementor)
    {
        _implementor = implementor;
    }

    public abstract void Register(string clientName, DateTime date, string service);
    public abstract void CompleteRegistration();
}

// Уточнена абстракція для Email
public class EmailClientRegistrationBridge : ClientRegistrationBridge
{
    public EmailClientRegistrationBridge(IClientRegistrationImplementor implementor) : base(implementor) { }

    public override void Register(string clientName, DateTime date, string service)
    {
        Console.WriteLine("[Email Client] Початок реєстрації");
        _implementor.RegisterClient(clientName, date, service);
    }

    public override void CompleteRegistration()
    {
        Console.WriteLine("[Email Client] Завершення реєстрації");
        _implementor.CompleteClientRegistration();
    }
}

// Уточнена абстракція для SMS
public class SmsClientRegistrationBridge : ClientRegistrationBridge
{
    public SmsClientRegistrationBridge(IClientRegistrationImplementor implementor) : base(implementor) { }

    public override void Register(string clientName, DateTime date, string service)
    {
        Console.WriteLine("[SMS Client] Початок реєстрації");
        _implementor.RegisterClient(clientName, date, service);
    }

    public override void CompleteRegistration()
    {
        Console.WriteLine("[SMS Client] Завершення реєстрації");
        _implementor.CompleteClientRegistration();
    }
}

// Тестування
class Program
{
    static void Main(string[] args)
    {
        IClientRegistrationImplementor emailImplementor = new EmailRegistrationImplementor();
        IClientRegistrationImplementor smsImplementor = new SmsRegistrationImplementor();

        ClientRegistrationBridge emailBridge = new EmailClientRegistrationBridge(emailImplementor);
        ClientRegistrationBridge smsBridge = new SmsClientRegistrationBridge(smsImplementor);

        emailBridge.Register("John Doe", DateTime.Now, "Notary");
        emailBridge.CompleteRegistration();

        smsBridge.Register("Jane Doe", DateTime.Now.AddHours(1), "Notary");
        smsBridge.CompleteRegistration();
    }
}
