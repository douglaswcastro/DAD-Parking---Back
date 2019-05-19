using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Extensions.Model
{
    public static class VinculoExtension
    {
        public static void Map(this Vinculo dbVinculo, Vinculo vinculo)
        {
            dbVinculo.Vaga.Map(vinculo.Vaga);
            dbVinculo.Tarifa.Map(vinculo.Tarifa);
            dbVinculo.Cliente.Map(vinculo.Cliente);
            dbVinculo.DataHoraInicio = vinculo.DataHoraInicio;
        }
    }
}