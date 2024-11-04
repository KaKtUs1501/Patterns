class Client:
    """Клієнт (Інформаційний експерт)"""
    def __init__(self, name, surname, email, phone, is_vip):
        self.name = name
        self.surname = surname
        self.email = email
        self.phone = phone
        self.is_vip = is_vip

    def display_info(self):
        print(f"Клієнт: {self.name} {self.surname}, Email: {self.email}, "
              f"Телефон: {self.phone}, VIP: {self.is_vip}")

class RegistrationStrategy:
    """Інтерфейс для стратегій реєстрації(Поліморфізм)"""
    def register(self, client):
        pass

class StandardRegistration(RegistrationStrategy):
    """Стандартна реєстрація"""
    def register(self, client):
        print(f"Реєстрація стандартного клієнта: {client.name} {client.surname}")

class VIPRegistration(RegistrationStrategy):
    """VIP реєстрація"""
    def register(self, client):
        print(f"Реєстрація VIP клієнта: {client.name} {client.surname}")

class Logger:
    """Логгер для подій (Штучний об’єкт)"""
    def log(self, message):
        print(f"ЛОГ: {message}")

class RegistrationController:
    """Контролер для реєстрації клієнтів (Контролер та Перенаправлення)"""
    def __init__(self, strategy, logger):
        self._strategy = strategy
        self._logger = logger

    def register_client(self, client):
        try:
            self._strategy.register(client)
            self._logger.log(f"Клієнт {client.name} {client.surname} успішно зареєстрований.")
        except Exception as e:
            self._logger.log(f"Помилка реєстрації клієнта: {str(e)}")

class NotificationService:
    """Служба сповіщень (Штучний об’єкт)"""
    def notify(self, client, message):
        print(f"Надсилання повідомлення клієнту {client.name}: {message}")

if __name__ == "__main__":
    # Створення клієнтів
    client1 = Client("Олег", "Петров", "oleg@example.com", "+380501234567", False)
    client2 = Client("Анна", "Іванова", "anna@example.com", "+380671234567", True)

    # Створення логера
    logger = Logger()

    # Вибір стратегії та створення контролера
    controller1 = RegistrationController(StandardRegistration(), logger)
    controller2 = RegistrationController(VIPRegistration(), logger)

    # Реєстрація клієнтів
    controller1.register_client(client1)
    controller2.register_client(client2)

    # Створення служби сповіщення
    notification_service = NotificationService()

    # Надсилання сповіщень клієнтам
    notification_service.notify(client1, "Ваш запис підтверджено.")
    notification_service.notify(client2, "Дякуємо за використання VIP-сервісу!")
