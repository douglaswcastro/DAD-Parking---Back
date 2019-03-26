using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAD_Parking___Back.Contracts;
using Newtonsoft.Json;

namespace DAD_Parking___Back.Model
{  
    public class Vinculo : IEntity
    {   
        [Key]
        [Column("vinculoId")]
        public Guid Id { get; set;}    

        [JsonIgnore]
        public Guid VagaId { get; set; }

        [ForeignKey("VagaId")]
        public Vaga Vaga { get; set; }

        [JsonIgnore]
        public Guid ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        
        [JsonIgnore]
        public Guid TarifaId { get; set; }

        [ForeignKey("TarifaId")]
        public Tarifa Tarifa { get; set; }

        [Required]
        [DisplayFormat(DataFormatString="dd/MM/yyyy hh:mm")]
        public DateTime DataHoraInicio { get; set; }
        
        [DisplayFormat(DataFormatString="dd/MM/yyyy hh:mm")]
        public Nullable<DateTime> DataHoraFim { get; set; }
        public double? ValorTotal { get; set; }
    }        
}