using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Model;
using DAD_Parking___Back.Data;

namespace DAD_Parking___Back.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(DADParkingDbContext repositoryContext)
            :base(repositoryContext)
        {            
        }
    }
}