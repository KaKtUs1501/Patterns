# Інтерфейс посередника
class Mediator:
    def send_message(self, message, participant):
        raise NotImplementedError

# Абстрактний клас учасника
class Participant:
    def __init__(self, mediator, name):
        self._mediator = mediator
        self.name = name

    def send(self, message):
        raise NotImplementedError

    def receive(self, message):
        raise NotImplementedError

# Клас для клієнтів
class Client(Participant):
    def send(self, message):
        print(f"{self.name} (Client) sends message: {message}")
        self._mediator.send_message(message, self)

    def receive(self, message):
        print(f"{self.name} (Client) receives message: {message}")

# Клас для нотаріусів
class NotaryEmployee(Participant):
    def send(self, message):
        print(f"{self.name} (Notary Employee) sends message: {message}")
        self._mediator.send_message(message, self)

    def receive(self, message):
        print(f"{self.name} (Notary Employee) receives message: {message}")

# Клас для адміністратора
class Admin(Participant):
    def send(self, message):
        print(f"{self.name} (Admin) sends message: {message}")
        self._mediator.send_message(message, self)

    def receive(self, message):
        print(f"{self.name} (Admin) receives message: {message}")

# Реалізація посередника
class NotaryOfficeMediator(Mediator):
    def __init__(self):
        self._client = None
        self._notary_employee = None
        self._admin = None

    def register_client(self, client):
        self._client = client

    def register_notary_employee(self, notary_employee):
        self._notary_employee = notary_employee

    def register_admin(self, admin):
        self._admin = admin

    def send_message(self, message, participant):
        if isinstance(participant, Client):
            self._notary_employee.receive(message)
        elif isinstance(participant, NotaryEmployee):
            self._client.receive(message)
        elif isinstance(participant, Admin):
            self._client.receive(message)
            self._notary_employee.receive(message)


if __name__ == "__main__":
    mediator = NotaryOfficeMediator()

    client = Client(mediator, "John Doe")
    notary_employee = NotaryEmployee(mediator, "Jane Smith")
    admin = Admin(mediator, "Admin")

    mediator.register_client(client)
    mediator.register_notary_employee(notary_employee)
    mediator.register_admin(admin)

    client.send("I want to schedule an appointment.")
    notary_employee.send("Appointment confirmed.")
    admin.send("Reminder for upcoming appointments.")
