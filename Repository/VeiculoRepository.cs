using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Model;
using DAD_Parking___Back.Data;

namespace DAD_Parking___Back.Repository
{
    public class VeiculoRepository : RepositoryBase<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(DADParkingDbContext repositoryContext)
            :base(repositoryContext)
        {            
        }
    }
}