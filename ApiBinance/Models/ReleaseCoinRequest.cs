using System.ComponentModel.DataAnnotations;

namespace ApiBinance.Models;

public class ReleaseCoinRequest
{
    public string AuthType { get; set; } = "FID02";

    [Required]
    public string Code { get; set; } = string.Empty;

    public string ConfirmPaidType { get; set; } = string.Empty;
    public string EmailVerifyCode { get; set; } = string.Empty;
    public string GoogleVerifyCode { get; set; } = string.Empty;
    public string MobileVerifyCode { get; set; } = string.Empty;

    [Required]
    public string OrderNumber { get; set; } = string.Empty;

    public int PayId { get; set; }
    public string YubikeyVerifyCode { get; set; } = string.Empty;
}
