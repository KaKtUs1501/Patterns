from datetime import datetime

# Клас ClientRegistration
class ClientRegistration:
    def __init__(self):
        self.client_name = None
        self.appointment_date = None
        self.service_type = None

# Пул об'єктів для реєстрацій клієнтів
class ClientPool:
    def __init__(self):
        self.available_registrations = []
        self.in_use_registrations = []

    def get_client_registration(self):
        if self.available_registrations:
            registration = self.available_registrations.pop(0)
            self.in_use_registrations.append(registration)
            return registration
        else:
            new_registration = ClientRegistration()
            self.in_use_registrations.append(new_registration)
            return new_registration

    def release_client_registration(self, registration):
        self.in_use_registrations.remove(registration)
        self.available_registrations.append(registration)

# Клас для керування нотаріальною конторою
class NotaryOffice:
    def __init__(self, client_pool):
        self.client_pool = client_pool

    def register_client(self, client_name, date, service):
        registration = self.client_pool.get_client_registration()
        registration.client_name = client_name
        registration.appointment_date = date
        registration.service_type = service
        print(f"Зареєстровано клієнта {client_name} на {date}")
        return registration

    def complete_registration(self, registration):
        if registration.client_name:
            print(f"Завершено реєстрацію для {registration.client_name}")
        else:
            print("Ім'я клієнта відсутнє!")
        self.client_pool.release_client_registration(registration)

# Приклад використання
if __name__ == "__main__":
    pool = ClientPool()
    notary_office = NotaryOffice(pool)

    # Реєстрація клієнта "John Doe"
    registration1 = notary_office.register_client("John Doe", datetime.now(), "Notary")

    # Завершення реєстрації "John Doe"
    notary_office.complete_registration(registration1)

    # Реєстрація клієнта "Jane Doe"
    registration2 = notary_office.register_client("Jane Doe", datetime.now().replace(hour=datetime.now().hour + 1), "Notary")

    # Завершення реєстрації "Jane Doe"
    notary_office.complete_registration(registration2)
