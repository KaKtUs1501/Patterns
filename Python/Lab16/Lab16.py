# Абстрактний клас для запису про клієнта
class ClientRecord:
    def __init__(self, name, appointment_time):
        self.name = name
        self.appointment_time = appointment_time

# Клас для фізичних осіб
class IndividualClientRecord(ClientRecord):
    pass

# Клас для юридичних осіб
class CorporateClientRecord(ClientRecord):
    pass

# Інтерфейс ітератора
class ClientIterator:
    def has_next(self):
        raise NotImplementedError

    def next(self):
        raise NotImplementedError

# Колекція записів про клієнтів
class ClientRecordsCollection:
    def __init__(self):
        self._client_records = []

    def add_client(self, client):
        self._client_records.append(client)

    def create_individual_iterator(self):
        return IndividualClientIterator(self._client_records)

    def create_corporate_iterator(self):
        return CorporateClientIterator(self._client_records)

    def create_all_clients_iterator(self):
        return AllClientsIterator(self._client_records)

# Ітератор для фізичних осіб
class IndividualClientIterator(ClientIterator):
    def __init__(self, client_records):
        self._client_records = client_records
        self._position = 0

    def has_next(self):
        while self._position < len(self._client_records):
            if isinstance(self._client_records[self._position], IndividualClientRecord):
                return True
            self._position += 1
        return False

    def next(self):
        client = self._client_records[self._position]
        self._position += 1
        return client

# Ітератор для юридичних осіб
class CorporateClientIterator(ClientIterator):
    def __init__(self, client_records):
        self._client_records = client_records
        self._position = 0

    def has_next(self):
        while self._position < len(self._client_records):
            if isinstance(self._client_records[self._position], CorporateClientRecord):
                return True
            self._position += 1
        return False

    def next(self):
        client = self._client_records[self._position]
        self._position += 1
        return client

# Ітератор для всіх записів
class AllClientsIterator(ClientIterator):
    def __init__(self, client_records):
        self._client_records = client_records
        self._position = 0

    def has_next(self):
        return self._position < len(self._client_records)

    def next(self):
        client = self._client_records[self._position]
        self._position += 1
        return client

if __name__ == "__main__":
    collection = ClientRecordsCollection()
    collection.add_client(IndividualClientRecord("John Doe", "10:00 AM"))
    collection.add_client(CorporateClientRecord("ABC Corp", "11:00 AM"))
    collection.add_client(IndividualClientRecord("Jane Smith", "12:00 PM"))

    # Ітерація фізичних осіб
    print("Individual Clients:")
    individual_iterator = collection.create_individual_iterator()
    while individual_iterator.has_next():
        client = individual_iterator.next()
        print(f"Client: {client.name}, Appointment: {client.appointment_time}")

    # Ітерація юридичних осіб
    print("\nCorporate Clients:")
    corporate_iterator = collection.create_corporate_iterator()
    while corporate_iterator.has_next():
        client = corporate_iterator.next()
        print(f"Client: {client.name}, Appointment: {client.appointment_time}")

    # Ітерація всіх клієнтів
    print("\nAll Clients:")
    all_clients_iterator = collection.create_all_clients_iterator()
    while all_clients_iterator.has_next():
        client = all_clients_iterator.next()
        print(f"Client: {client.name}, Appointment: {client.appointment_time}")
