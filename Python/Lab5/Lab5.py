from datetime import datetime

# Клас ClientRegistration
class ClientRegistration:
    def __init__(self):
        self.client_name = None
        self.appointment_date = None
        self.service_type = None
        self.contact_info = None

# Інтерфейс IClientRegistrationBuilder
class IClientRegistrationBuilder:
    def set_client_name(self, name):
        pass

    def set_appointment_date(self, date):
        pass

    def set_service_type(self, service):
        pass

    def set_contact_info(self, contact_info):
        pass

    def build(self):
        pass

# Стандартний будівельник
class StandardRegistrationBuilder(IClientRegistrationBuilder):
    def __init__(self):
        self._registration = ClientRegistration()

    def set_client_name(self, name):
        self._registration.client_name = name

    def set_appointment_date(self, date):
        self._registration.appointment_date = date

    def set_service_type(self, service):
        self._registration.service_type = service

    def set_contact_info(self, contact_info):
        self._registration.contact_info = contact_info

    def build(self):
        return self._registration

# VIP будівельник
class VIPRegistrationBuilder(IClientRegistrationBuilder):
    def __init__(self):
        self._registration = ClientRegistration()

    def set_client_name(self, name):
        self._registration.client_name = f"VIP: {name}"

    def set_appointment_date(self, date):
        self._registration.appointment_date = date

    def set_service_type(self, service):
        self._registration.service_type = f"VIP {service}"

    def set_contact_info(self, contact_info):
        self._registration.contact_info = contact_info

    def build(self):
        return self._registration

# Клас директор
class RegistrationDirector:
    def __init__(self, builder):
        self._builder = builder

    def construct_registration(self, name, date, service, contact_info):
        self._builder.set_client_name(name)
        self._builder.set_appointment_date(date)
        self._builder.set_service_type(service)
        self._builder.set_contact_info(contact_info)

    def get_result(self):
        return self._builder.build()

# Використання
if __name__ == "__main__":
    # Використання стандартного будівельника
    standard_builder = StandardRegistrationBuilder()
    director = RegistrationDirector(standard_builder)
    director.construct_registration("John Doe", datetime.now(), "Notary", "123-456-789")
    standard_registration = director.get_result()
    print(f"Клієнт: {standard_registration.client_name}, Дата: {standard_registration.appointment_date}, Послуга: {standard_registration.service_type}")

    # Використання VIP будівельника
    vip_builder = VIPRegistrationBuilder()
    director = RegistrationDirector(vip_builder)
    director.construct_registration("Jane Doe", datetime.now(), "Notary", "987-654-321")
    vip_registration = director.get_result()
    print(f"Клієнт: {vip_registration.client_name}, Дата: {vip_registration.appointment_date}, Послуга: {vip_registration.service_type}")
