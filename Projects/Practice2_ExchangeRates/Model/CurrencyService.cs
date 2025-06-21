namespace Model;

public class CurrencyService
{
    private readonly Dictionary<string, decimal> valueByRate = [];
    public IReadOnlyList<Currency> Rates { get; }
 
    public CurrencyService()
    {
        Rates = ConfigurationRates.GetConfiguration();
 
        valueByRate.Add("Доллар США", 1m);
        valueByRate.Add("Евро", 0.93m);
        valueByRate.Add("Фунт стерлингов", 0.8m);
        valueByRate.Add("Иена", 151.5m);
        valueByRate.Add("Рубль", 92.5m);
    }

    public IReadOnlyList<Currency> GetAllCurrencies()
    {
        return Rates;
    }
    public decimal Convert(string nameFrom, string nameTo, decimal amount) 
    {
        return amount / valueByRate[nameFrom] * valueByRate[nameTo];
    } 
}