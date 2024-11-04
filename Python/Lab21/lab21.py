from abc import ABC, abstractmethod

# Інтерфейс стратегії
class IAppointmentStrategy(ABC):
    @abstractmethod
    def process_appointment(self, client_name):
        pass

# Контекст (Система запису клієнтів)
class AppointmentSystem:
    def __init__(self):
        self._strategy = None

    def set_strategy(self, strategy):
        self._strategy = strategy

    def process(self, client_name):
        self._strategy.process_appointment(client_name)

# Стратегія онлайн-запису
class OnlineStrategy(IAppointmentStrategy):
    def process_appointment(self, client_name):
        print(f"Обробка онлайн-запису для клієнта {client_name}")

# Стратегія телефонного запису
class PhoneStrategy(IAppointmentStrategy):
    def process_appointment(self, client_name):
        print(f"Обробка телефонного запису для клієнта {client_name}")

# Стратегія особистого запису
class InPersonStrategy(IAppointmentStrategy):
    def process_appointment(self, client_name):
        print(f"Обробка запису при особистому візиті для клієнта {client_name}")

# Головна програма
if __name__ == "__main__":
    system = AppointmentSystem()

    # Використання стратегії для онлайн-запису
    system.set_strategy(OnlineStrategy())
    system.process("John Doe")

    # Використання стратегії для телефонного запису
    system.set_strategy(PhoneStrategy())
    system.process("Jane Smith")

    # Використання стратегії для особистого запису
    system.set_strategy(InPersonStrategy())
    system.process("Alice Johnson")
