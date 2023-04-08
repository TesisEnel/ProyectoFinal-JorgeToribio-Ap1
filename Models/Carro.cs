using System.ComponentModel.DataAnnotations;

public class Carro
{
    [Key]
    public int CarroId { get; set; }
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [Required(ErrorMessage = "El modelo es requerido")]
    public string? Modelo { get; set; }
    [Required(ErrorMessage = "La marca es requerida")]
    public string? Marca { get; set; }
    [Required(ErrorMessage = "El color es requerido")]
    public string? Color { get; set; }
    [Required(ErrorMessage = "El motor es requerido")]
    public string? Motor { get; set; }
    [Required(ErrorMessage = "El año es requerido")]
    [Range(1960, 2024, ErrorMessage = "El año debe estar entre 1960 y 2024")]
    public int Anio { get; set; }
    [Required(ErrorMessage = "El precio es requerido")]
    [Range(1, 100000000000, ErrorMessage = "El precio debe ser mayor que cero")]
    public double Precio { get; set; }
    [Required(ErrorMessage = "El lugar es requerido")]
    public string? Lugar { get; set; } 
    [Required(ErrorMessage = "El estado del vehiculo es requerido.")]
    public string? Estado { get; set; }
    [Required(ErrorMessage = "El combustible del vehiculo es requerido.")]
    public string? Combustible { get; set; }
    [Required(ErrorMessage = "La transmisión es requerida.")]
    public string? Transmision { get; set; }
    [Required(ErrorMessage = "EL tipo de vehiculo es requerida.")]
    public string? TipoVehiculo { get; set; }
    [Required(ErrorMessage = "La cantidad de pasajeros es requerida.")]
    [Range(1, 20, ErrorMessage = "La cantidad debe ser mayor que cero.")]
    public int CaantidadPasajeros { get; set; }
}