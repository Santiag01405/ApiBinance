using System.ComponentModel.DataAnnotations;

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
}
