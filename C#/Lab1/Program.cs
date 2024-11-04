using System;

public class ConfigurationManager
{
    private static ConfigurationManager instance;
    private string dbConnectionString;

    // Приватний конструктор
    private ConfigurationManager()
    {
        dbConnectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;";
    }

    // Метод для отримання єдиного екземпляра класу
    public static ConfigurationManager GetInstance()
    {
        if (instance == null)
        {
            instance = new ConfigurationManager();
        }
        return instance;
    }

    public string GetConnectionString()
    {
        return dbConnectionString;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Отримання єдиного екземпляра класу ConfigurationManager
        ConfigurationManager configManager = ConfigurationManager.GetInstance();

        // Використання методу GetConnectionString для отримання рядка підключення до бази даних
        string connectionString = configManager.GetConnectionString();

        // Виведення рядка підключення на консоль
        Console.WriteLine("Connection String: " + connectionString);

        // Використання того ж екземпляра ConfigurationManager в іншому місці програми
        ConfigurationManager anotherConfigManager = ConfigurationManager.GetInstance();
        Console.WriteLine("Are both instances the same? " + (configManager == anotherConfigManager));
    }
}
