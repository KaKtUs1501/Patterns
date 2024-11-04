using System;

public interface INotaryRecord
{
    void Process();
}

public class ClientRecord : INotaryRecord
{
    public void Process()
    {
        Console.WriteLine("Processing client record");
    }
}

public abstract class NotaryRecordDecorator : INotaryRecord
{
    protected INotaryRecord _notaryRecord;

    public NotaryRecordDecorator(INotaryRecord notaryRecord)
    {
        _notaryRecord = notaryRecord;
    }

    public virtual void Process()
    {
        _notaryRecord.Process();
    }
}

public class PriorityRecord : NotaryRecordDecorator
{
    public PriorityRecord(INotaryRecord notaryRecord) : base(notaryRecord) {}

    public override void Process()
    {
        Console.WriteLine("Processing priority client");
        base.Process();
    }
}

public class DocumentCheckRecord : NotaryRecordDecorator
{
    public DocumentCheckRecord(INotaryRecord notaryRecord) : base(notaryRecord) {}

    public override void Process()
    {
        Console.WriteLine("Checking client documents");
        base.Process();
    }
}

class Program
{
    static void Main(string[] args)
    {
        INotaryRecord record = new ClientRecord();
        record = new PriorityRecord(record);
        record = new DocumentCheckRecord(record);

        record.Process();
    }
}

