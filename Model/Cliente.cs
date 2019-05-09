using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAD_Parking___Back.Contracts;
using Newtonsoft.Json;

namespace DAD_Parking___Back.Model
{  
    [Table("cliente")]
    public class Cliente : IEntity
    {
        [Key]
        [Column("clienteId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(60, ErrorMessage = "Campo Nome não pode ter mais que 60 caracteres")]
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }        

        [JsonIgnore]
        public Guid VeiculoId { get; set; }
        
        [ForeignKey("VeiculoId")]
        [Required(ErrorMessage = "Campo Veiculo é obrigatório")]
        public virtual Veiculo Veiculo { get; set; }        
    }    
}