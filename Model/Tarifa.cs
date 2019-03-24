using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAD_Parking___Back.Contracts;

namespace DAD_Parking___Back.Model
{  
    [Table("tarifa")]
    public class Tarifa : IEntity
    {
        [Key]
        [Column("tarifaId")]
        public Guid Id { get; set; }
        public string TipoTarifa { get; set; }
        public string TipoVeiculo { get; set; }
        public double Valor { get; set; }
    }    
}