using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using minimal_api.Dominio.Enuns;

namespace minimal_api.Dominio.Entidades;

public class Administrador
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; } = default!;

    [Required]
    [StringLength(255)]
    public string Email { get;set; } = default!;

    [Required]
    [StringLength(50)]
    public string Senha { get;set; } = default!;

    [Required]
    [StringLength(10)]
    [EnumDataType(typeof(Perfil), ErrorMessage = "O Perfil deve ser um valor válido (Adm ou Editor).")]
    public string Perfil  { get;set; } = default!;
}