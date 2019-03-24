using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Extensions.Model
{
    public static class VeiculoExtension
    {
        public static void Map(this Veiculo dbVeiculo, Veiculo veiculo)
        {
            dbVeiculo.Marca = veiculo.Marca;
            dbVeiculo.Modelo = veiculo.Modelo;
            dbVeiculo.TipoVeiculo = veiculo.TipoVeiculo;
            dbVeiculo.Ano = veiculo.Ano;
        }
    }
}