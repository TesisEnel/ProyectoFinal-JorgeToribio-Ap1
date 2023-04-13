using System.ComponentModel.DataAnnotations;

public class Pago 
{
    [Key]
    public int PagoId { get; set; }
    public int clienteId { get; set; }
    public int ventaId { get; set; }
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public string? Concepto { get; set; }

}