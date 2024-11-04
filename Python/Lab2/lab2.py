import copy
from datetime import datetime

class ClientRecord:
    def __init__(self, name, address, appointment_date):
        self.name = name
        self.address = address
        self.appointment_date = appointment_date

    # Метод для клонування об'єкта ClientRecord
    def clone(self):
        return copy.copy(self)

if __name__ == "__main__":
    # Створення початкового запису клієнта
    original_record = ClientRecord("John Doe", "123 Main St", datetime.now())

    cloned_record = original_record.clone()

    cloned_record.name = "Jane Doe"

    print("Original Record:", original_record.name)
    print("Cloned Record:", cloned_record.name)
