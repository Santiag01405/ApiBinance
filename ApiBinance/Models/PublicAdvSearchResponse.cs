namespace ApiBinance.Models;

public class PublicAdvSearchResponse
{
    public List<AdvItem> Data { get; set; } = new();
}

public class AdvItem
{
    public Adv Adv { get; set; } = new();
    public Advertiser Advertiser { get; set; } = new();
}

public class Adv
{
    public string AdvNo { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public string SurplusAmount { get; set; } = string.Empty;
    public string MinSingleTransAmount { get; set; } = string.Empty;
    public string MaxSingleTransAmount { get; set; } = string.Empty;
    public List<TradeMethodd> TradeMethods { get; set; } = new();
}

public class TradeMethodd
{
    public string TradeMethodName { get; set; } = string.Empty;
    public string TradeMethodBgColor { get; set; } = "#cccccc";
}

public class Advertiser
{
    public string NickName { get; set; } = string.Empty;
    public int MonthOrderCount { get; set; }
    public decimal MonthFinishRate { get; set; }
    public int? VipLevel { get; set; }
    public List<string> Badges { get; set; } = new();
}



/*using System.Text.Json.Serialization;

namespace ApiBinance.Models;

public class PublicAdvSearchResponse
{
    [JsonPropertyName("data")]
    public List<AdvWrapper> Data { get; set; } = new();
}

public class AdvWrapper
{
    [JsonPropertyName("adv")]
    public Adv Adv { get; set; }

    [JsonPropertyName("advertiser")]
    public Advertiser Advertiser { get; set; }
}

public class Adv
{
    public string AdvNo { get; set; }
    public string Price { get; set; }
    public string FiatUnit { get; set; }
    public string Asset { get; set; }
    public string TradeType { get; set; }

    public List<TradeMethod> TradeMethods { get; set; } = new(); // ya existente
    public string MinSingleTransAmount { get; set; }
    public string MaxSingleTransAmount { get; set; }
}

public class Advertiser
{
    public string NickName { get; set; }
    public int MonthOrderCount { get; set; }
    public decimal PositiveRate { get; set; }
}*/
