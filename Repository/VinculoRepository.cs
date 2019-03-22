using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Model;
using DAD_Parking___Back.Data;

namespace DAD_Parking___Back.Repository
{
    public class VinculoRepository : RepositoryBase<Vinculo>, IVinculoRepository
    {
        public VinculoRepository(DADParkingDbContext repositoryContext)
            :base(repositoryContext)
        {            
        }
    }
}