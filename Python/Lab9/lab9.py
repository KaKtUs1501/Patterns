from abc import ABC, abstractmethod

# Інтерфейс для компонентів (записів)
class INotaryRecord(ABC):
    @abstractmethod
    def display_details(self):
        pass

# Листовий елемент (окрема заявка)
class ClientRecord(INotaryRecord):
    def __init__(self, client_name):
        self.client_name = client_name

    def display_details(self):
        print(f"Client: {self.client_name}")

# Композитний елемент (група заявок)
class CompositeClientRecord(INotaryRecord):
    def __init__(self):
        self.client_records = []

    def add_record(self, record):
        self.client_records.append(record)

    def remove_record(self, record):
        self.client_records.remove(record)

    def display_details(self):
        for record in self.client_records:
            record.display_details()

# Приклад використання Composite Pattern
if __name__ == "__main__":
    # Індивідуальні заявки
    client1 = ClientRecord("John Doe")
    client2 = ClientRecord("Jane Smith")

    # Група клієнтів
    group = CompositeClientRecord()
    group.add_record(client1)
    group.add_record(client2)

    # Ще одна заявка
    client3 = ClientRecord("Alice Johnson")

    # Основна група
    main_group = CompositeClientRecord()
    main_group.add_record(group)
    main_group.add_record(client3)

    # Виведення інформації
    main_group.display_details()

    main_group.remove_record(client3)
    main_group.display_details()
