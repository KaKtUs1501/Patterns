from datetime import datetime

# Інтерфейс нової системи реєстрації
class IClientRegistration:
    def register(self, client_name: str, date: datetime, service_type: str):
        raise NotImplementedError("Subclasses should implement this!")

# Старий API для реєстрації
class OldClientService:
    def add_client_info(self, full_name: str, appointment: datetime, service: str):
        print(f"[Старий API] Додано клієнта {full_name}, дата: {appointment}, послуга: {service}")

# Адаптер для старого API
class ClientAdapter(IClientRegistration):
    def __init__(self, old_service: OldClientService):
        self._old_service = old_service

    def register(self, client_name: str, date: datetime, service_type: str):
        print(f"[Адаптер] Перетворюємо новий інтерфейс для клієнта {client_name}")
        self._old_service.add_client_info(client_name, date, service_type)

# Клас нотаріальної контори
class NotaryOffice:
    def __init__(self, registration: IClientRegistration):
        self._registration = registration

    def register_client(self, client_name: str, date: datetime, service: str):
        print(f"[Нова система] Реєструємо клієнта {client_name}")
        self._registration.register(client_name, date, service)

# Тестування
if __name__ == "__main__":
    old_service = OldClientService()
    adapter = ClientAdapter(old_service)
    office = NotaryOffice(adapter)

    office.register_client("John Doe", datetime.now(), "Notary")
