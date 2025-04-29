using System.ComponentModel.DataAnnotations;

namespace ApiBinance.Models;

public class ChatImageUrlRequest
{
    [Required]
    [Display(Name = "Nombre de la imagen")]
    public string ImageName { get; set; } = string.Empty;
}
