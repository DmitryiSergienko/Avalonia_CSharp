using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    public CurrencyService _currencyService = new();
    public ObservableCollection<Currency> ListRatesFromContent { get; } = new();
    public ObservableCollection<string> NameFromListRates { get; } = new();
    private string _selectedFromRate;
    private string _selectedToRate;
    public string SelectedFromRate
    {
        get => _selectedFromRate;
        set
        {
            _selectedFromRate = value;
            OnPropertyChanged();
        }
    }
    public string SelectedToRate
    {
        get => _selectedToRate;
        set
        {
            _selectedToRate = value;
            OnPropertyChanged();
        }
    }
    public MainViewModel()
    {
        var listRates = _currencyService.GetAllCurrencies();
        foreach (var rate in listRates)
        {
            ListRatesFromContent.Add(rate);
            NameFromListRates.Add(rate.Name);
        }
        SelectedFromRate = NameFromListRates[0];
        SelectedToRate = NameFromListRates[1];
    }
    
    public string AmountOfMoney { get; set; }
    private string _resultOfMoney;
    public string ResultOfMoney
    {
        get => _resultOfMoney;
        set
        {
            _resultOfMoney = value;
            OnPropertyChanged();
        }
    }
    public void TakeResult()
    {
        if (!decimal.TryParse(AmountOfMoney, out var amount))
        {
            ResultOfMoney = "Введите корректную сумму.";
            return;
        }
        try
        {
            decimal result = _currencyService.Convert(SelectedFromRate, SelectedToRate, amount);
            ResultOfMoney = result.ToString("F2");
        }
        catch (Exception ex)
        {
            ResultOfMoney = $"Ошибка: {ex.Message}";
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}