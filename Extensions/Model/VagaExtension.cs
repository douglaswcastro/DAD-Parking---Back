using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Extensions.Model
{
    public static class VagaExtension
    {
        public static void Map(this Vaga dbVaga, Vaga vaga)
        {
            dbVaga.TipoVeiculo = vaga.TipoVeiculo;
            dbVaga.NumeroVaga = vaga.NumeroVaga;
        }
    }
}