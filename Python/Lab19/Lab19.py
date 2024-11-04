class Subject:
    def __init__(self):
        self._observers = []

    def register_observer(self, observer):
        self._observers.append(observer)

    def remove_observer(self, observer):
        self._observers.remove(observer)

    def notify_observers(self, appointment_details):
        for observer in self._observers:
            observer.update(appointment_details)

class Observer:
    def update(self, appointment_details):
        pass

class Appointment(Subject):
    def __init__(self):
        super().__init__()
        self._appointment_details = None

    @property
    def appointment_details(self):
        return self._appointment_details

    @appointment_details.setter
    def appointment_details(self, details):
        self._appointment_details = details
        self.notify_observers(details)

class Admin(Observer):
    def __init__(self, name):
        self._name = name

    def update(self, appointment_details):
        print(f"{self._name} отримав оновлення запису: {appointment_details}")

class NotaryEmployee(Observer):
    def __init__(self, name):
        self._name = name

    def update(self, appointment_details):
        print(f"{self._name} отримав оновлення запису: {appointment_details}")

if __name__ == "__main__":
    # Створюємо суб'єкт - запис на зустріч
    appointment = Appointment()

    # Створюємо спостерігачів
    admin = Admin("Admin")
    notary = NotaryEmployee("Notary Employee")

    # Реєструємо спостерігачів
    appointment.register_observer(admin)
    appointment.register_observer(notary)

    # Змінюємо стан запису і сповіщаємо спостерігачів
    appointment.appointment_details = "Запис на 15 жовтня 2024, 10:00"

    appointment.remove_observer(notary)
    appointment.appointment_details = "Запис перенесено на 16 жовтня 2024, 14:00"
