namespace DefaultNamespace;

using System;
using System.ComponentModel.DataAnnotations;

public class TarefaRequest
{
    [Required(ErrorMessage = "Título não pode ser nulo/vazio")]
    public string Titulo { get; set; }

    public string Descricao { get; set; }

    [Required(ErrorMessage = "Data não pode ser nula")]
    public DateTime Data { get; set; }

    [Required(ErrorMessage = "Status não pode ser nulo/vazio")]
    [RegularExpression("Pendente|Finalizado", ErrorMessage = "Status deve ser 'Pendente' ou 'Finalizado'")]
    public string Status { get; set; }
}
