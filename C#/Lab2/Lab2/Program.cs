using System;

public class ClientRecord
{
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime AppointmentDate { get; set; }

    // Метод для клонування
    public ClientRecord Clone()
    {
        return (ClientRecord)this.MemberwiseClone();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення початкового запису клієнта
        ClientRecord originalRecord = new ClientRecord
        {
            Name = "John Doe",
            Address = "123 Main St",
            AppointmentDate = DateTime.Now
        };

        // Клонування запису
        ClientRecord clonedRecord = originalRecord.Clone();
        
        clonedRecord.Name = "Jane Doe";
        
        Console.WriteLine("Original Record: " + originalRecord.Name);
        Console.WriteLine("Cloned Record: " + clonedRecord.Name);
    }
}