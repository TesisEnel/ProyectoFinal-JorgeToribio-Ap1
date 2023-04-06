using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Venta
{
    [Key]
    public int VentaId { get; set; }

    [Required(ErrorMessage = "El concepto de la venta es obligatorio.")]
    public string? Concepto { get; set; }

    [Required(ErrorMessage = "La fecha de la venta es obligatoria.")]
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "El ID del carro es obligatorio.")]
    public int CarroId { get; set; }

    [Required(ErrorMessage = "El precio de venta es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "El precio de venta debe ser mayor que cero.")]
    public double PrecioVenta { get; set; }

    [Required(ErrorMessage = "La cantidad vendida es obligatoria.")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad vendida debe ser mayor que cero.")]
    public int Cantidad { get; set; }
    public int PeriodoTiempo { get; set; }

    [ForeignKey("VentaId")]
    public List<VentaDetalle> VentaDetalle { get; set; }

}