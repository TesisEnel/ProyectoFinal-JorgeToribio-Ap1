using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Key]
    public int ClienteId { get; set; }
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required(ErrorMessage = "El nombre es requerido.")]
    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El apellido es requerido.")]
    [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El apellido solo puede contener letras y espacios.")]
    public string? Apellido { get; set; }

    [Required(ErrorMessage = "El correo electrónico es requerido.")]
    [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
    public string? CorreoElectronico { get; set; }

    [Required(ErrorMessage = "El teléfono es requerido.")]
    [RegularExpression(@"^\d{8,10}$", ErrorMessage = "El teléfono debe ser un número de 8 a 10 dígitos.")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "El balance es requerido")]
    [Range(1, 100000000000, ErrorMessage = "El balance debe ser mayor que cero")]
    public double balance { get; set; }
}
