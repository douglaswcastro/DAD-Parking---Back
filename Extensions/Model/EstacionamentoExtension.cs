using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Extensions.Model
{
    public static class EstacionamentoExtension
    {
        public static void Map(this Estacionamento dbEstacionamento, Estacionamento estacionamento)
        {
            dbEstacionamento.Nome = estacionamento.Nome;
            dbEstacionamento.Telefone = estacionamento.Telefone;
            dbEstacionamento.TotalVagasCarro = estacionamento.TotalVagasCarro;
            dbEstacionamento.TotalVagasMoto = estacionamento.TotalVagasMoto;
        }
    }
}