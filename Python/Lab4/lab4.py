from abc import ABC, abstractmethod
from datetime import datetime


class Client:
    def __init__(self, name, email, phone_number):
        self.name = name
        self.email = email
        self.phone_number = phone_number


class Appointment(ABC):
    def __init__(self, client, date):
        self.client = client
        self.date = date

    @abstractmethod
    def schedule(self):
        pass


class StandardAppointment(Appointment):
    def schedule(self):
        print("Standard appointment scheduled.")


class VIPAppointment(Appointment):
    def schedule(self):
        print("VIP appointment scheduled with extra services.")


class AppointmentFactory(ABC):
    @abstractmethod
    def create_appointment(self, client, date):
        pass


class StandardAppointmentFactory(AppointmentFactory):
    def create_appointment(self, client, date):
        return StandardAppointment(client, date)


class VIPAppointmentFactory(AppointmentFactory):
    def create_appointment(self, client, date):
        return VIPAppointment(client, date)


factory = StandardAppointmentFactory()
client = Client(name="John Doe", email="john.doe@example.com", phone_number="123456789")
appointment = factory.create_appointment(client, datetime.now())
appointment.schedule()
