using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiBinance.Models;

public class AdUpdateRequest
{
    [Required]
    [JsonPropertyName("advNo")]
    public string AdvNo { get; set; } = string.Empty;

    [Required]
    [JsonPropertyName("adStatus")]
    public int AdvStatus { get; set; }

    [Required]
    [JsonPropertyName("asset")]
    public string Asset { get; set; } = string.Empty;

    [JsonPropertyName("authType")]
    public string AuthType { get; set; } = "FID02";

    [JsonPropertyName("autoReplyMsg")]
    public string AutoReplyMsg { get; set; } = string.Empty;

    [JsonPropertyName("buyerBtcPositionLimit")]
    public int BuyerBtcPositionLimit { get; set; }

    [JsonPropertyName("buyerKycLimit")]
    public int BuyerKycLimit { get; set; }

    [JsonPropertyName("buyerRegDaysLimit")]
    public int BuyerRegDaysLimit { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("emailVerifyCode")]
    public string EmailVerifyCode { get; set; } = string.Empty;

    [Required]
    [JsonPropertyName("fiatUnit")]
    public string FiatUnit { get; set; } = string.Empty;

    [JsonPropertyName("googleVerifyCode")]
    public string GoogleVerifyCode { get; set; } = string.Empty;

    [JsonPropertyName("initAmount")]
    public decimal InitAmount { get; set; }

    [Required]
    [JsonPropertyName("maxSingleTransAmount")]
    public decimal MaxSingleTransAmount { get; set; }

    [Required]
    [JsonPropertyName("minSingleTransAmount")]
    public decimal MinSingleTransAmount { get; set; }

    [JsonPropertyName("mobileVerifyCode")]
    public string MobileVerifyCode { get; set; } = string.Empty;

    [JsonPropertyName("payTimeLimit")]
    public int PayTimeLimit { get; set; }

    [Required]
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("priceFloatingRatio")]
    public decimal PriceFloatingRatio { get; set; }

    [JsonPropertyName("priceType")]
    public string PriceType { get; set; } = string.Empty;

    [JsonPropertyName("rateFloatingRatio")]
    public decimal RateFloatingRatio { get; set; }

    [JsonPropertyName("remark")]
    public string Remarks { get; set; } = string.Empty;

    [JsonPropertyName("saveAsTemplate")]
    public bool SaveAsTemplate { get; set; }

    [JsonPropertyName("takerAdditionalKycRequired")]
    public bool TakerAdditionalKycRequired { get; set; }

    [JsonPropertyName("tempAdName")]
    public string TemplateName { get; set; } = string.Empty;

    [JsonPropertyName("tradeMethods")]
    public List<TradeMethod> TradeMethods { get; set; } = new();

    [Required]
    [JsonPropertyName("tradeType")]
    public string TradeType { get; set; } = string.Empty;

    [JsonPropertyName("updateMode")]
    public string UpdateMode { get; set; } = string.Empty;

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

    [JsonPropertyName("userTradeCompleteCountMin")]
    public int UserTradeCompleteCountMin { get; set; }

    [JsonPropertyName("userTradeCompleteRateFilterTime")]
    public int UserTradeCompleteRateFilterTime { get; set; }

    [JsonPropertyName("userTradeCompleteRateMin")]
    public int UserTradeCompleteRateMin { get; set; }

    [JsonPropertyName("userTradeCountFilterTime")]
    public int UserTradeCountFilterTime { get; set; }

    [JsonPropertyName("userTradeType")]
    public int UserTradeType { get; set; }

    [JsonPropertyName("userTradeVolumeAsset")]
    public string UserTradeVolumeAsset { get; set; } = string.Empty;

    [JsonPropertyName("userTradeVolumeFilterTime")]
    public int UserTradeVolumeFilterTime { get; set; }

    [JsonPropertyName("userTradeVolumeMax")]
    public decimal UserTradeVolumeMax { get; set; }

    [JsonPropertyName("userTradeVolumeMin")]
    public decimal UserTradeVolumeMin { get; set; }

    [JsonPropertyName("yubikeyVerifyCode")]
    public string YubikeyVerifyCode { get; set; } = string.Empty;
}

