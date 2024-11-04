from abc import ABC, abstractmethod
from datetime import datetime

class Client:
    def __init__(self, name, email, phone_number):
        self.name = name
        self.email = email
        self.phone_number = phone_number

class Appointment:
    def __init__(self, client, date, notary):
        self.client = client
        self.date = date
        self.notary = notary

class AppointmentFactory(ABC):
    @abstractmethod
    def create_appointment(self, client, date, notary):
        pass

class ConcreteAppointmentFactory(AppointmentFactory):
    def create_appointment(self, client, date, notary):
        return Appointment(client, date, notary)

factory = ConcreteAppointmentFactory()
client = Client(name="John Doe", email="john.doe@example.com", phone_number="123456789")
appointment = factory.create_appointment(client, datetime.now(), "Notary A")
print(f"Appointment for {appointment.client.name} with {appointment.notary} on {appointment.date}")
