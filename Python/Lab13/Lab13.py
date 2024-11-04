class IClientData:
    def get_client_info(self):
        raise NotImplementedError("This method should be overridden.")

class ClientData(IClientData):
    def __init__(self, name, surname, address):
        self.name = name
        self.surname = surname
        self.address = address

    def get_client_info(self):
        print(f"Client: {self.name} {self.surname}, Address: {self.address}")

class ClientDataProxy(IClientData):
    def __init__(self, name, surname, address, user_role):
        self.client_data = ClientData(name, surname, address)
        self.user_role = user_role

    def get_client_info(self):
        if self.user_role == "admin":
            self.client_data.get_client_info()
        else:
            print("Access denied. You do not have the required permissions.")

if __name__ == "__main__":
    client_proxy = ClientDataProxy("John", "Doe", "123 Main St", "admin")
    client_proxy.get_client_info()

    client_proxy_user = ClientDataProxy("Jane", "Smith", "456 Oak St", "user")
    client_proxy_user.get_client_info()
