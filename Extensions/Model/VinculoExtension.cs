using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Extensions.Model
{
    public static class VinculoExtension
    {
        public static void Map(this Vinculo dbVinculo, Vinculo vinculo)
        {
            dbVinculo.Tarifa = vinculo.Tarifa;
            dbVinculo.DataHoraInicio = vinculo.DataHoraInicio;
            dbVinculo.DataHoraFim = vinculo.DataHoraFim;
            dbVinculo.Vaga = vinculo.Vaga;
        }
    }
}