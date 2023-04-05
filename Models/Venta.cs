using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Venta
{
    [Key]
    public int VentaId { get; set; }
    public string? Concepto { get; set; }
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public int clienteId { get; set; }
    public int CarroId { get; set; }
    public double PrecioVenta { get; set; }
    public int Cantidad { get; set; }
    
    [ForeignKey("VentaId")]
    public List<VentaDetalle> VentaDetalle { get; set; }

}