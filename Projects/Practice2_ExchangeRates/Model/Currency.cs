namespace Model;

public class Currency
{
    public string Code {get;set;}
    public string Name {get;set;}
    public decimal Rate {get;set;}

    public Currency(string code, string name, decimal rate)
    {
        Code = code;
        Name = name;
        Rate = rate;
    }
}