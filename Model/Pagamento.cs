using System;

namespace DAD_Parking___Back.Model
{  
    public class Pagamento
    {        
        public Cliente Cliente { get; set; }
        public double Valor { get; set; }
        public DateTime DataHoraPagamento { get; set; }
    }    
}