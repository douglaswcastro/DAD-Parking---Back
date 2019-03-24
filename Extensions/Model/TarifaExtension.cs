using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Extensions.Model
{
    public static class TarifaExtension
    {
        public static void Map(this Tarifa dbTarifa, Tarifa tarifa)
        {
            dbTarifa.TipoTarifa = tarifa.TipoTarifa;
            dbTarifa.TipoVeiculo = tarifa.TipoVeiculo;
            dbTarifa.Valor = tarifa.Valor;
        }
    }
}