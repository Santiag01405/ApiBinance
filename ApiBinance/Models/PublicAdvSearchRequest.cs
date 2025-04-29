namespace ApiBinance.Models;

public class PublicAdvSearchRequest
{
    public int Page { get; set; } = 1;
    public int Rows { get; set; } = 20;
    public List<string> PayTypes { get; set; } = new();
    public string Asset { get; set; } = "USDT";
    public string Fiat { get; set; } = "VES";
    public string TradeType { get; set; } = "SELL";
}

