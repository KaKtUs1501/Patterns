using System;
using System.Collections.Generic;

class Record
{
    private string clientName;
    private DateTime appointmentDate;

    public Record(string clientName, DateTime appointmentDate)
    {
        this.clientName = clientName;
        this.appointmentDate = appointmentDate;
    }

    public void SetAppointmentDate(DateTime date)
    {
        appointmentDate = date;
    }

    public RecordMemento Save()
    {
        return new RecordMemento(clientName, appointmentDate);
    }

    public void Restore(RecordMemento memento)
    {
        clientName = memento.GetClientName();
        appointmentDate = memento.GetAppointmentDate();
    }

    public override string ToString()
    {
        return $"Client: {clientName}, Appointment: {appointmentDate}";
    }
}

class RecordMemento
{
    private readonly string clientName;
    private readonly DateTime appointmentDate;

    public RecordMemento(string clientName, DateTime appointmentDate)
    {
        this.clientName = clientName;
        this.appointmentDate = appointmentDate;
    }

    public string GetClientName() => clientName;
    public DateTime GetAppointmentDate() => appointmentDate;
}

class RecordHistory
{
    private Stack<RecordMemento> history = new Stack<RecordMemento>();

    public void SaveState(Record record)
    {
        history.Push(record.Save());
    }

    public void RestoreState(Record record)
    {
        if (history.Count > 0)
        {
            record.Restore(history.Pop());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Record record = new Record("John Doe", DateTime.Now);
        RecordHistory history = new RecordHistory();

        Console.WriteLine("Initial state: " + record);
        
        history.SaveState(record);
        
        record.SetAppointmentDate(DateTime.Now.AddDays(1));
        Console.WriteLine("Updated state: " + record);
        
        history.RestoreState(record);
        Console.WriteLine("Restored state: " + record);
    }
}
