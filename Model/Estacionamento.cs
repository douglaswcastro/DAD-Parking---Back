using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAD_Parking___Back.Contracts;

namespace DAD_Parking___Back.Model
{  
    [Table("estacionamento")]
    public class Estacionamento : IEntity
    {
        [Key]
        [Column("estacionamentoId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(60, ErrorMessage = "Campo Nome não pode ter mais que 60 caracteres")]
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo TotalVagasMoto é obrigatório")]
        public int TotalVagasMoto { get; set; }

        [Required(ErrorMessage = "Campo TotalVagasCarro é obrigatório")]
        public int TotalVagasCarro { get; set; } 
    }    
}