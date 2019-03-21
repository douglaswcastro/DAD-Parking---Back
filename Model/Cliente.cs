using System;
using System.ComponentModel.DataAnnotations;

namespace DAD_Parking___Back.Model
{  
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public Veiculo Veiculo { get; set; }        
    }    
}