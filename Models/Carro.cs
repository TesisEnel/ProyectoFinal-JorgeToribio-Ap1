using System.ComponentModel.DataAnnotations;

public class Carro
{
    [Key]
    public int CarroId { get; set; }
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
    [Range(0, 1000000, ErrorMessage = "El precio debe estar entre 0 y 1000000")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "El lugar es requerido")]
    public string? Lugar { get; set; } 
}