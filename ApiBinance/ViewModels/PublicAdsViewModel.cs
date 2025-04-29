namespace ApiBinance.Models;

public class PublicAdsViewModel
{
    public string SelectedAsset { get; set; } = "USDT";
    public string SelectedFiat { get; set; } = "VES";
    public string SelectedTradeType { get; set; } = "SELL";

    public List<string> Assets { get; set; } = new();
    public List<string> Fiats { get; set; } = new();
    public List<string> TradeTypes { get; set; } = new();

    public PublicAdvSearchResponse Data { get; set; } = new();
}
