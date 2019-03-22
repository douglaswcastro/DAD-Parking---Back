using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAD_Parking___Back.Model
{  
    public class Vinculo
    {   
        [Key]
        [Column("vinculoId")]
        public Guid Id { get; set;}       
        public Vaga Vaga { get; set; }
        public Cliente Cliente { get; set; }
        public Tarifa Tarifa { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public double ValorTotal { get; set; }
    }        
}