class ICommand:
    def execute(self):
        raise NotImplementedError()

    def undo(self):
        raise NotImplementedError()


class CreateAppointmentCommand(ICommand):
    def __init__(self, notary_system, client_name, service_type):
        self.notary_system = notary_system
        self.client_name = client_name
        self.service_type = service_type

    def execute(self):
        self.notary_system.create_appointment(self.client_name, self.service_type)

    def undo(self):
        self.notary_system.cancel_appointment(self.client_name)


class NotarySystem:
    def create_appointment(self, client_name, service_type):
        print(f"Appointment created for {client_name} on service: {service_type}")

    def cancel_appointment(self, client_name):
        print(f"Appointment for {client_name} canceled.")


class Invoker:
    def __init__(self):
        self.command = None

    def set_command(self, command):
        self.command = command

    def execute_command(self):
        if self.command:
            self.command.execute()

    def undo_command(self):
        if self.command:
            self.command.undo()


if __name__ == "__main__":
    notary_system = NotarySystem()
    create_appointment = CreateAppointmentCommand(notary_system, "John Doe", "Document Signing")

    invoker = Invoker()
    invoker.set_command(create_appointment)

    # Виконати команду
    invoker.execute_command()

    # Скасувати команду
    invoker.undo_command()
