namespace Model;

public class ConfigurationRates
{
    public static IReadOnlyList<Currency> GetConfiguration()
    {
        return 
        [
            new("USD", "Доллар США", 1m), 
            new("EUR", "Евро", 0.93m), 
            new("GBP", "Фунт стерлингов", 0.8m), 
            new("JPY", "Иена", 151.5m), 
            new("RUB", "Рубль", 92.5m)
        ];
    }
}