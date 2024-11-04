from datetime import datetime


class Record:
    def __init__(self, client_name, appointment_date):
        self._client_name = client_name
        self._appointment_date = appointment_date

    def set_appointment_date(self, date):
        self._appointment_date = date

    def save(self):
        return RecordMemento(self._client_name, self._appointment_date)

    def restore(self, memento):
        self._client_name = memento.client_name
        self._appointment_date = memento.appointment_date

    def __str__(self):
        return f"Client: {self._client_name}, Appointment: {self._appointment_date}"


class RecordMemento:
    def __init__(self, client_name, appointment_date):
        self.client_name = client_name
        self.appointment_date = appointment_date


class RecordHistory:
    def __init__(self):
        self._history = []

    def save_state(self, record):
        self._history.append(record.save())

    def restore_state(self, record):
        if self._history:
            record.restore(self._history.pop())


if __name__ == "__main__":
    record = Record("John Doe", datetime.now())
    history = RecordHistory()

    print("Initial state:", record)

    history.save_state(record)

    record.set_appointment_date(datetime.now().replace(hour=10))
    print("Updated state:", record)

    history.restore_state(record)
    print("Restored state:", record)
