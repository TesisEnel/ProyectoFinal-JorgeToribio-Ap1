using System.ComponentModel.DataAnnotations;

public class VentaDetalle
{
    [Key]
    public int VentaDetalleId { get; set; }
    public int VentaId { get; set; }
    public int cuota { get; set; }
    public double Capital { get; set; }
    public double interes { get; set; }
    public double interesMasCapital { get; set; }
    public double ValorAdeudado { get; set; }

}
