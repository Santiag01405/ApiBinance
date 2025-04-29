using System.ComponentModel.DataAnnotations;

namespace ApiBinance.Models;

public class MarkMessagesReadRequest
{
    [Required]
    public string OrderNo { get; set; } = string.Empty;

    [Required]
    public long UserId { get; set; }
}
