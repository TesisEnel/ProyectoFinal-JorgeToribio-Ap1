using System.ComponentModel.DataAnnotations;

public class VentaDetalle
{
    [Key]
    public int VentaDetalleId { get; set; }
    public string? Descripcion { get; set; }
    public int CarroId { get; set; }
    public int ClienteID { get; set; }
    public int Cantidad { get; set; }
}