from datetime import datetime

# Інтерфейс реалізації
class IClientRegistrationImplementor:
    def register_client(self, client_name: str, date: datetime, service: str):
        raise NotImplementedError("Subclasses should implement this!")

    def complete_client_registration(self):
        raise NotImplementedError("Subclasses should implement this!")

# Конкретна реалізація для Email
class EmailRegistrationImplementor(IClientRegistrationImplementor):
    def register_client(self, client_name: str, date: datetime, service: str):
        print(f"[Email] Реєстрація клієнта {client_name} на {date} для послуги {service}")

    def complete_client_registration(self):
        print("[Email] Завершено реєстрацію клієнта")

# Конкретна реалізація для SMS
class SmsRegistrationImplementor(IClientRegistrationImplementor):
    def register_client(self, client_name: str, date: datetime, service: str):
        print(f"[SMS] Реєстрація клієнта {client_name} на {date} для послуги {service}")

    def complete_client_registration(self):
        print("[SMS] Завершено реєстрацію клієнта")

# Абстракція
class ClientRegistrationBridge:
    def __init__(self, implementor: IClientRegistrationImplementor):
        self._implementor = implementor

    def register(self, client_name: str, date: datetime, service: str):
        raise NotImplementedError("Subclasses should implement this!")

    def complete_registration(self):
        raise NotImplementedError("Subclasses should implement this!")

# Уточнена абстракція для Email
class EmailClientRegistrationBridge(ClientRegistrationBridge):
    def register(self, client_name: str, date: datetime, service: str):
        print("[Email Client] Початок реєстрації")
        self._implementor.register_client(client_name, date, service)

    def complete_registration(self):
        print("[Email Client] Завершення реєстрації")
        self._implementor.complete_client_registration()

# Уточнена абстракція для SMS
class SmsClientRegistrationBridge(ClientRegistrationBridge):
    def register(self, client_name: str, date: datetime, service: str):
        print("[SMS Client] Початок реєстрації")
        self._implementor.register_client(client_name, date, service)

    def complete_registration(self):
        print("[SMS Client] Завершення реєстрації")
        self._implementor.complete_client_registration()

# Тестування
if __name__ == "__main__":
    email_implementor = EmailRegistrationImplementor()
    sms_implementor = SmsRegistrationImplementor()

    email_bridge = EmailClientRegistrationBridge(email_implementor)
    sms_bridge = SmsClientRegistrationBridge(sms_implementor)

    email_bridge.register("John Doe", datetime.now(), "Notary")
    email_bridge.complete_registration()

    sms_bridge.register("Jane Doe", datetime.now(), "Notary")
    sms_bridge.complete_registration()
