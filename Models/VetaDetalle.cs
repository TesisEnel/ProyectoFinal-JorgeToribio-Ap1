using System.ComponentModel.DataAnnotations;

public class VentaDetalle
{
    [Key]
    public int VentaDetalleId { get; set; }

    [Required(ErrorMessage ="El id es requerido.")]
    public int CarroId { get; set; }

    [Required(ErrorMessage ="El id es requerido.")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage ="El tiempo tiene que ser mayor que 0.")]
    [Range(1, int.MaxValue)]
    public int Tiempo { get; set; }

    [Required(ErrorMessage ="El saldo tiene que ser mayor que 0.")]
    [Range(0, double.MaxValue)]
    public double SaldoInicial { get; set; }

    [Required(ErrorMessage ="La cuota tiene que ser mayor que 0.")]
    [Range(0, double.MaxValue)]
    public double Cuota { get; set; }
    [Required(ErrorMessage ="La cuota tiene que ser mayor que 0.")]
    [Range(0, double.MaxValue)]
    public double Interes { get; set; }

    [Range(0, double.MaxValue)]
    public double Inicial { get; set; }

    [Range(0, double.MaxValue)]
    public double Amortizacion { get; set; }

    [Range(0, double.MaxValue)]
    public double SaldoFinal { get; set; }
    public int Cantidad { get; set; }
}
