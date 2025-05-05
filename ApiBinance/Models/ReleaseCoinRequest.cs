using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ApiBinance.Models;

public class ReleaseCoinRequest
{
    [JsonPropertyName("authType")]
    public string AuthType { get; set; } = "FID02";

    [Required]
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("confirmPaidType")]
    public string ConfirmPaidType { get; set; } = string.Empty;

    [JsonPropertyName("emailVerifyCode")]
    public string EmailVerifyCode { get; set; } = string.Empty;

    [JsonPropertyName("googleVerifyCode")]
    public string GoogleVerifyCode { get; set; } = string.Empty;

    [JsonPropertyName("mobileVerifyCode")]
    public string MobileVerifyCode { get; set; } = string.Empty;

    [Required]
    [JsonPropertyName("orderNumber")]
    public string OrderNumber { get; set; } = string.Empty;

    [JsonPropertyName("payId")]
    public int PayId { get; set; }

    public string YubikeyVerifyCode { get; set; } = string.Empty;
        }

    /*public string AuthType { get; set; } = "FID02";

    [Required]
    public string Code { get; set; } = string.Empty;

    public string ConfirmPaidType { get; set; } = string.Empty;
    public string EmailVerifyCode { get; set; } = string.Empty;
    public string GoogleVerifyCode { get; set; } = string.Empty;
    public string MobileVerifyCode { get; set; } = string.Empty;

    [Required]
    public string OrderNumber { get; set; } = string.Empty;

    public int PayId { get; set; }
    public string YubikeyVerifyCode { get; set; } = string.Empty;*/

