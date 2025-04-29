using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiBinance.Models;

public class TradeMethod
{
    [Required]
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; } = string.Empty;

    [Required]
    [JsonPropertyName("payId")]
    public string PayId { get; set; } = string.Empty;

    [Required]
    [JsonPropertyName("payType")]
    public string PayType { get; set; } = string.Empty;
}
