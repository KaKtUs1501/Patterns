class RequestHandler:
    def __init__(self):
        self.next_handler = None

    def set_next(self, handler):
        self.next_handler = handler

    def handle_request(self, request):
        raise NotImplementedError("You should implement this method")


class ClientRequest:
    def __init__(self, client_name, service_type):
        self.client_name = client_name
        self.service_type = service_type


class AuthorizationHandler(RequestHandler):
    def handle_request(self, request):
        if request.client_name == "authorizedUser":
            print("Authorization successful.")
            if self.next_handler:
                self.next_handler.handle_request(request)
        else:
            print("Authorization failed.")


class ServiceValidationHandler(RequestHandler):
    def handle_request(self, request):
        if request.service_type == "Document Signing":
            print("Service is available.")
            if self.next_handler:
                self.next_handler.handle_request(request)
        else:
            print("Service not available.")


class AppointmentCreationHandler(RequestHandler):
    def handle_request(self, request):
        print(f"Appointment created for {request.client_name} on service: {request.service_type}")


if __name__ == "__main__":
    # Створюємо ланцюжок обробників
    auth_handler = AuthorizationHandler()
    service_handler = ServiceValidationHandler()
    appointment_handler = AppointmentCreationHandler()

    # Встановлюємо порядок у ланцюжку
    auth_handler.set_next(service_handler)
    service_handler.set_next(appointment_handler)

    # Створюємо запит клієнта
    client_request = ClientRequest("authorizedUser", "Document Signing")

    # Передаємо запит через ланцюжок
    auth_handler.handle_request(client_request)
