class State:
    def confirm(self, appointment):
        pass

    def cancel(self, appointment):
        pass

    def complete(self, appointment):
        pass


class Appointment:
    def __init__(self, state):
        self._state = state

    def set_state(self, state):
        self._state = state

    def confirm(self):
        self._state.confirm(self)

    def cancel(self):
        self._state.cancel(self)

    def complete(self):
        self._state.complete(self)


class ScheduledState(State):
    def confirm(self, appointment):
        print("Запис вже підтверджено.")

    def cancel(self, appointment):
        print("Запис скасовано.")
        appointment.set_state(CancelledState())

    def complete(self, appointment):
        print("Запис виконано.")
        appointment.set_state(CompletedState())


class CancelledState(State):
    def confirm(self, appointment):
        print("Неможливо підтвердити скасований запис.")

    def cancel(self, appointment):
        print("Запис вже скасовано.")

    def complete(self, appointment):
        print("Неможливо завершити скасований запис.")


class CompletedState(State):
    def confirm(self, appointment):
        print("Запис вже завершено, підтвердження не потрібне.")

    def cancel(self, appointment):
        print("Неможливо скасувати завершений запис.")

    def complete(self, appointment):
        print("Запис вже завершено.")


if __name__ == "__main__":
    appointment = Appointment(ScheduledState())

    appointment.confirm()  # Запис вже підтверджено.
    appointment.complete()  # Запис виконано.

    appointment.cancel()  # Неможливо скасувати завершений запис.
