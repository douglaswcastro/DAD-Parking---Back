using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAD_Parking___Back.Model
{  
    [Table("vaga")]
    public class Vaga
    {
        [Key]
        [Column("vagaId")]
        public Guid Id { get; set;}  

        [Required(ErrorMessage = "Campo TipoVeiculo é obrigatório")]
        public string TipoVeiculo { get; set; }
    }        
}