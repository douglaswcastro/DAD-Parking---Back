using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAD_Parking___Back.Model
{  
    [Table("veiculo")]
    public class Veiculo
    { 
        [Key]        
        public string Placa { get; set; }

        [Required(ErrorMessage = "Campo Marca é obrigatório")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Campo Modelo é obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Campo Ano é obrigatório")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Campo TipoVeiculo é obrigatório")]
        public string TipoVeiculo { get; set; }
    }        
}