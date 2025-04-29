using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiBinance.Models;

public class AdUpdateStatusRequest
{
    [Required]
    [JsonPropertyName("advNos")]
    public List<string> AdvNos { get; set; } = new();

    [Required]
    [Range(0, 1)]
    [JsonPropertyName("advStatus")]
    public int AdvStatus { get; set; } // 0 = OFFLINE, 1 = ONLINE
}
