class ClientFlyweight:
    def __init__(self, name, surname, address):
        self.name = name
        self.surname = surname
        self.address = address

    def display_client_info(self, appointment_date, service_type):
        print(f"Client: {self.name} {self.surname}, Address: {self.address}, "
              f"Appointment: {appointment_date}, Service: {service_type}")


class ClientFactory:
    def __init__(self):
        self.clients = {}

    def get_client(self, name, surname, address):
        key = f"{name}-{surname}-{address}"
        if key not in self.clients:
            self.clients[key] = ClientFlyweight(name, surname, address)
        return self.clients[key]


class NotaryAppointment:
    def __init__(self, client, appointment_date, service_type):
        self.client = client
        self.appointment_date = appointment_date
        self.service_type = service_type

    def display_appointment_info(self):
        self.client.display_client_info(self.appointment_date, self.service_type)


if __name__ == "__main__":
    client_factory = ClientFactory()
    client1 = client_factory.get_client("John", "Doe", "123 Main St")
    appointment1 = NotaryAppointment(client1, "2024-10-15", "Document Signing")
    appointment1.display_appointment_info()

    client2 = client_factory.get_client("Jane", "Smith", "456 Oak St")
    appointment2 = NotaryAppointment(client2, "2024-10-16", "Consultation")
    appointment2.display_appointment_info()

    # Reuse the same client object
    appointment3 = NotaryAppointment(client1, "2024-10-17", "Will Preparation")
    appointment3.display_appointment_info()