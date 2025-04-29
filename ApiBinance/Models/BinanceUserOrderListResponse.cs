using System.Text.Json.Serialization;

namespace ApiBinance.Models;
public class BinanceUserOrderListResponse
{
    public List<UserOrder> Data { get; set; } = new();
}

public class UserOrder
{
    public string OrderNumber { get; set; }
    public string TotalPrice { get; set; }
    public List<TradeMethoddd> TradeMethods { get; set; } = new();
}

public class TradeMethoddd
{
    public string PayType { get; set; }
}


/*using System.Text.Json.Serialization;

namespace ApiBinance.Models;

public class BinanceUserOrderListResponse
{
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("data")]
    public List<BinanceUserOrder> Data { get; set; } = new();
}

public class BinanceUserOrder
{
    [JsonPropertyName("orderNumber")]
    public string OrderNumber { get; set; }

    [JsonPropertyName("asset")]
    public string Asset { get; set; }

    [JsonPropertyName("fiat")]
    public string Fiat { get; set; }

    [JsonPropertyName("tradeType")]
    public string TradeType { get; set; }

    [JsonPropertyName("totalPrice")]
    public string TotalPrice { get; set; }

    [JsonPropertyName("unitPrice")]
    public string UnitPrice { get; set; }

    [JsonPropertyName("tradeMethods")]
    public List<BinanceTradeMethod> TradeMethods { get; set; } = new();
}

public class BinanceTradeMethod
{
    [JsonPropertyName("payType")]
    public string PayType { get; set; }

    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }
}*/
