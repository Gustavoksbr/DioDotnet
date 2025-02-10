using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DefaultNamespace;

namespace TrilhaApiDesafio.Models
{
    public class Tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [EnumDataType(typeof(EnumStatusTarefa))]
        [Column(TypeName = "varchar(20)")]
        public EnumStatusTarefa Status { get; set; }

        public Tarefa() { }

        public Tarefa(TarefaRequest tarefaRequest)
        {
            Titulo = tarefaRequest.Titulo;
            Descricao = tarefaRequest.Descricao;
            Data = tarefaRequest.Data;
            Status = Enum.Parse<EnumStatusTarefa>(tarefaRequest.Status);
        }

        public void Atualizar(TarefaRequest tarefaRequest)
        {
            Titulo = tarefaRequest.Titulo;
            Descricao = tarefaRequest.Descricao;
            Data = tarefaRequest.Data;
            Status = Enum.Parse<EnumStatusTarefa>(tarefaRequest.Status);
        }
    }
}