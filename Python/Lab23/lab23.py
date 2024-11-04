class ClientElement:
    def accept(self, visitor):
        pass

class StandardClient(ClientElement):
    def __init__(self, name):
        self.name = name

    def accept(self, visitor):
        visitor.visit_standard_client(self)

class VIPClient(ClientElement):
    def __init__(self, name):
        self.name = name

    def accept(self, visitor):
        visitor.visit_vip_client(self)

class Visitor:
    def visit_standard_client(self, standard_client):
        pass

    def visit_vip_client(self, vip_client):
        pass

class RegistrationVisitor(Visitor):
    def visit_standard_client(self, standard_client):
        print(f"Реєстрація стандартного клієнта: {standard_client.name}")

    def visit_vip_client(self, vip_client):
        print(f"Реєстрація VIP клієнта: {vip_client.name}")

class NotificationVisitor(Visitor):
    def visit_standard_client(self, standard_client):
        print(f"Надсилання сповіщення стандартному клієнту: {standard_client.name}")

    def visit_vip_client(self, vip_client):
        print(f"Надсилання сповіщення VIP клієнту: {vip_client.name}")

# Виконання
if __name__ == "__main__":
    client1 = StandardClient("Олег")
    client2 = VIPClient("Анна")

    registration_visitor = RegistrationVisitor()
    notification_visitor = NotificationVisitor()

    client1.accept(registration_visitor)
    client1.accept(notification_visitor)

    client2.accept(registration_visitor)
    client2.accept(notification_visitor)
