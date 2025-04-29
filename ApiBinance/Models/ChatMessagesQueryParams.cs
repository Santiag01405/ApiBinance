using System.ComponentModel.DataAnnotations;

namespace ApiBinance.Models;

public class ChatMessagesQueryParams
{
    public string? ChatMessageType { get; set; }
    public long? Id { get; set; }
    public string? Order { get; set; }
    public string? OrderNo { get; set; }

    [Required]
    public int Page { get; set; }

    [Required]
    public int Rows { get; set; }

    public string? Sort { get; set; }
}

