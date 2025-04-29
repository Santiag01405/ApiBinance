using System.Text.Json.Serialization;

namespace ApiBinance.Models;

public class UserOrderListRequest
{
    [JsonPropertyName("page")]
    public int Page { get; set; } = 1;

    [JsonPropertyName("rows")]
    public int Rows { get; set; } = 50;

    [JsonPropertyName("tradeType")]
    public string TradeType { get; set; } = "SELL"; // o "BUY"

    [JsonPropertyName("asset")]
    public string Asset { get; set; } = "USDT";

    [JsonPropertyName("fiat")]
    public string Fiat { get; set; } = "ARS";
}
