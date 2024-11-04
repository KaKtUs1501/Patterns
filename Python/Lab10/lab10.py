from abc import ABC, abstractmethod

class INotaryRecord(ABC):
    @abstractmethod
    def process(self):
        pass

class ClientRecord(INotaryRecord):
    def process(self):
        print("Processing client record")

class NotaryRecordDecorator(INotaryRecord):
    def __init__(self, notary_record):
        self._notary_record = notary_record

    def process(self):
        self._notary_record.process()

class PriorityRecord(NotaryRecordDecorator):
    def process(self):
        print("Processing priority client")
        super().process()

class DocumentCheckRecord(NotaryRecordDecorator):
    def process(self):
        print("Checking client documents")
        super().process()

if __name__ == "__main__":
    record = ClientRecord()
    record = PriorityRecord(record)
    record = DocumentCheckRecord(record)

    record.process()
