from abc import ABC, abstractmethod

class ClientRegistrationTemplate(ABC):
    def register_client(self):
        self.retrieve_client_data()
        self.validate_client_data()
        self.save_client_to_database()
        self.notify_client()

    @abstractmethod
    def retrieve_client_data(self):
        pass

    @abstractmethod
    def validate_client_data(self):
        pass

    @abstractmethod
    def save_client_to_database(self):
        pass

    @abstractmethod
    def notify_client(self):
        pass

class StandardClientRegistration(ClientRegistrationTemplate):
    def retrieve_client_data(self):
        print("Отримання даних для стандартного клієнта.")
        # Код для отримання даних клієнта

    def validate_client_data(self):
        print("Валідація даних для стандартного клієнта.")
        # Код для валідації даних клієнта

    def save_client_to_database(self):
        print("Збереження даних стандартного клієнта в базу.")
        # Код для збереження даних клієнта в БД

    def notify_client(self):
        print("Надсилання сповіщення стандартному клієнту.")
        # Код для сповіщення клієнта

class VIPClientRegistration(ClientRegistrationTemplate):
    def retrieve_client_data(self):
        print("Отримання даних для VIP-клієнта.")
        # Код для отримання даних VIP-клієнта

    def validate_client_data(self):
        print("Валідація даних для VIP-клієнта.")
        # Код для валідації даних VIP-клієнта

    def save_client_to_database(self):
        print("Збереження даних VIP-клієнта в базу.")
        # Код для збереження даних VIP-клієнта в БД

    def notify_client(self):
        print("Надсилання сповіщення VIP-клієнту.")
        # Код для сповіщення VIP-клієнта

# Виконання
if __name__ == "__main__":
    standard_client = StandardClientRegistration()
    standard_client.register_client()

    print()

    vip_client = VIPClientRegistration()
    vip_client.register_client()
