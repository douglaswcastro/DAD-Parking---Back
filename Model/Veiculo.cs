using System;
using System.ComponentModel.DataAnnotations;

namespace DAD_Parking___Back.Model
{  
    public class Veiculo
    {        
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }

        public TipoVeiculo TipoVeiculo { get; set; }
    }    

    public enum TipoVeiculo { Carro, Moto }
}