using System.ComponentModel.DataAnnotations;

namespace ApiBinance.Models;

public class AdUpdateStatusRequest
{
    [Required]
    public List<string> AdvNos { get; set; } = new();

    [Required]
    [Range(0, 1)]
    public int AdvStatus { get; set; } // 0 = OFFLINE, 1 = ONLINE
}

