using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Model;
using DAD_Parking___Back.Data;

namespace DAD_Parking___Back.Repository
{
    public class TarifaRepository : RepositoryBase<Tarifa>, ITarifaRepository
    {
        public TarifaRepository(DADParkingDbContext repositoryContext)
            :base(repositoryContext)
        {            
        }
    }
}