using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAD_Parking___Back.Contracts;

namespace DAD_Parking___Back.Model
{  
    [Table("vaga")]
    public class Vaga : IEntity
    {
        [Key]
        [Column("vagaId")]
        public Guid Id { get; set;}  

        [Required(ErrorMessage = "Campo NumeroVaga é obrigatório")]
        public int NumeroVaga { get; set; }

        [Required(ErrorMessage = "Campo TipoVeiculo é obrigatório")]
        public string TipoVeiculo { get; set; }
    }        
}