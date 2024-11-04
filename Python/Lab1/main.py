class ConfigurationManager:
    __instance = None

    def __init__(self):
        if ConfigurationManager.__instance is not None:
            raise Exception("This class is a singleton!")
        else:
            self.db_connection_string = "sqlite:///mydatabase.db"
            ConfigurationManager.__instance = self

    @staticmethod
    def get_instance():
        if ConfigurationManager.__instance is None:
            ConfigurationManager()
        return ConfigurationManager.__instance

    def get_connection_string(self):
        return self.db_connection_string


# Приклад використання
if __name__ == "__main__":
    # Отримання єдиного екземпляра класу ConfigurationManager
    config_manager = ConfigurationManager.get_instance()

    # Використання методу get_connection_string для отримання рядка підключення до бази даних
    connection_string = config_manager.get_connection_string()

    # Виведення рядка підключення на консоль
    print("Connection String:", connection_string)

    # Використання того ж екземпляра ConfigurationManager в іншому місці програми
    another_config_manager = ConfigurationManager.get_instance()
    print("Are both instances the same?", config_manager is another_config_manager)
