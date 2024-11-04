# Підсистема перевірки документів
class DocumentVerificationSubsystem:
    def verify_documents(self, client_data):
        print(f"Verifying documents for {client_data}")

# Підсистема бронювання
class AppointmentBookingSubsystem:
    def book_appointment(self, client_data):
        print(f"Booking appointment for {client_data}")

# Підсистема сповіщень
class NotificationSubsystem:
    def send_notification(self, client_data):
        print(f"Sending notification to {client_data}")

# Підсистема архівування
class ArchiveSubsystem:
    def save_client_record(self, client_data):
        print(f"Saving client record for {client_data}")

# Фасад
class NotaryFacade:
    def __init__(self):
        self._doc_verification = DocumentVerificationSubsystem()
        self._booking = AppointmentBookingSubsystem()
        self._notification = NotificationSubsystem()
        self._archive = ArchiveSubsystem()

    def register_client(self, client_data):
        self._doc_verification.verify_documents(client_data)
        self._booking.book_appointment(client_data)
        self._notification.send_notification(client_data)
        self._archive.save_client_record(client_data)

# Використання фасаду
if __name__ == "__main__":
    facade = NotaryFacade()
    facade.register_client("John Doe")
