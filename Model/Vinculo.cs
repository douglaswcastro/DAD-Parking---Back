using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAD_Parking___Back.Contracts;

namespace DAD_Parking___Back.Model
{  
    public class Vinculo : IEntity
    {   
        [Key]
        [Column("vinculoId")]
        public Guid Id { get; set;}       
        public Vaga Vaga { get; set; }
        public Cliente Cliente { get; set; }
        public Tarifa Tarifa { get; set; }

        [DisplayFormat(DataFormatString="dd/MM/yyyy hh:mm")]
        public DateTime DataHoraInicio { get; set; }
        
        [DisplayFormat(DataFormatString="dd/MM/yyyy hh:mm")]
        public DateTime DataHoraFim { get; set; }
        public double ValorTotal { get; set; }
    }        
}