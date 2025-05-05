using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiBinance.Models;

public class AdPublishRequest
{
    [Required]
    [JsonPropertyName("asset")]
    public string Asset { get; set; } = "USDT";

    [Required]
    [JsonPropertyName("fiatUnit")]
    public string FiatUnit { get; set; } = "ARS";

    [Required]
    [JsonPropertyName("tradeType")]
    public string TradeType { get; set; } = "SELL";

    [JsonPropertyName("authType")]
    public string AuthType { get; set; } = "FID02";

    [JsonPropertyName("autoReplyMsg")]
    public string AutoReplyMsg { get; set; } = "";

    [JsonPropertyName("buyerBtcPositionLimit")]
    public int BuyerBtcPositionLimit { get; set; }

    [JsonPropertyName("buyerKycLimit")]
    public int BuyerKycLimit { get; set; }

    [JsonPropertyName("buyerRegDaysLimit")]
    public int BuyerRegDaysLimit { get; set; }

    [JsonPropertyName("classify")]
    public int Classify { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; } = "";

    [JsonPropertyName("googleVerifyCode")]
    public string GoogleVerifyCode { get; set; }

    [JsonPropertyName("mobileVerifyCode")]
    public string MobileVerifyCode { get; set; }

    [JsonPropertyName("yubikeyVerifyCode")]
    public string YubikeyVerifyCode { get; set; }

    [JsonPropertyName("initAmount")]
    public decimal InitAmount { get; set; }

    [Required]
    [JsonPropertyName("minSingleTransAmount")]
    public decimal MinSingleTransAmount { get; set; }

    [Required]
    [JsonPropertyName("maxSingleTransAmount")]
    public decimal MaxSingleTransAmount { get; set; }

    [JsonPropertyName("onlineDelayTime")]
    public int OnlineDelayTime { get; set; }

    [JsonPropertyName("onlineNow")]
    public bool OnlineNow { get; set; } = true;

    [JsonPropertyName("payTimeLimit")]
    public int PayTimeLimit { get; set; }

    [Required]
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("priceFloatingRatio")]
    public decimal PriceFloatingRatio { get; set; }

    [JsonPropertyName("priceType")]
    public string PriceType { get; set; }

    [JsonPropertyName("rateFloatingRatio")]
    public decimal RateFloatingRatio { get; set; }

    [JsonPropertyName("remark")]
    public string Remark { get; set; }

    [JsonPropertyName("saveAsTemplate")]
    public bool SaveAsTemplate { get; set; }

    [JsonPropertyName("takerAdditionalKycRequired")]
    public bool TakerAdditionalKycRequired { get; set; }

    [JsonPropertyName("tempAdName")]
    public string TempAdName { get; set; }

    [JsonPropertyName("tradeMethods")]
    public List<TradeMethod> TradeMethods { get; set; } = new();

    [JsonPropertyName("userAllTradeCountMax")]
    public int UserAllTradeCountMax { get; set; }

    [JsonPropertyName("userAllTradeCountMin")]
    public int UserAllTradeCountMin { get; set; }

    [JsonPropertyName("userBuyTradeCountMax")]
    public int UserBuyTradeCountMax { get; set; }

    [JsonPropertyName("userBuyTradeCountMin")]
    public int UserBuyTradeCountMin { get; set; }

    [JsonPropertyName("userSellTradeCountMax")]
    public int UserSellTradeCountMax { get; set; }

    [JsonPropertyName("userSellTradeCountMin")]
    public int UserSellTradeCountMin { get; set; }

    [JsonPropertyName("userCancelOrderCountMin")]
    public int UserCancelOrderCountMin { get; set; }

    [JsonPropertyName("userTradeCompleteRateFilterTime")]
    public int UserTradeCompleteRateFilterTime { get; set; }

    [JsonPropertyName("userTradeCompleteRateMin")]
    public decimal UserTradeCompleteRateMin { get; set; }

    [JsonPropertyName("userTradeType")]
    public int UserTradeType { get; set; }

    [JsonPropertyName("userTradeVolumeAsset")]
    public string UserTradeVolumeAsset { get; set; }

    [JsonPropertyName("userTradeVolumeFilterTime")]
    public int UserTradeVolumeFilterTime { get; set; }

    [JsonPropertyName("userTradeVolumeMax")]
    public decimal UserTradeVolumeMax { get; set; }

    [JsonPropertyName("userTradeVolumeMin")]
    public decimal UserTradeVolumeMin { get; set; }
}






/*using System.ComponentModel.DataAnnotations;
=======
>>>>>>> 69616524e48364b9a76f7dd7d4bee73fb178d9c1

namespace ApiBinance.Models;

public class AdPublishRequest
{
    [Required]
    [Display(Name = "Activo")]
    public string Asset { get; set; } = "USDT";

    [Required]
    [Display(Name = "Moneda Fiat")]
    public string FiatUnit { get; set; } = "ARS";

    [Required]
    [Display(Name = "Tipo de operación")]
    public string TradeType { get; set; } = "SELL";

    [Display(Name = "Autenticación")]
    public string AuthType { get; set; } = "FID02";

    [Display(Name = "Mensaje automático")]
    public string AutoReplyMsg { get; set; } = "";

    public int Classify { get; set; }

    public string Code { get; set; } = "";

    [Required]
    [Range(1, 1000000)]
    [Display(Name = "Precio")]
    public decimal Price { get; set; }

    [Required]
    [Display(Name = "Mínimo por transacción")]
    public decimal MinSingleTransAmount { get; set; }

    [Required]
    [Display(Name = "Máximo por transacción")]
    public decimal MaxSingleTransAmount { get; set; }

    public bool OnlineNow { get; set; } = true;

    public List<TradeMethod> TradeMethods { get; set; } = new();
}

public class TradeMethod
{
    [Required]
    public string Identifier { get; set; } = "";

    [Required]
    public string PayId { get; set; } = "";

    [Required]
    public string PayType { get; set; } = "";
<<<<<<< HEAD
}*/


