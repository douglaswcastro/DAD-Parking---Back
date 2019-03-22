using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CreateVinculo(Vinculo vinculo)
        {
            vinculo.Id = Guid.NewGuid();
            Create(vinculo);
            Save();
        }

        public IEnumerable<Vinculo> GetAllVinculos()
        {
            return FindAll()
                    .OrderBy(vinculo => vinculo.Cliente);
        }

        public Vinculo GetVinculoById(Guid vinculodId)
        {
            return FindByCondition(vinculo => vinculo.Id.Equals(vinculodId))
                    .FirstOrDefault();
        }
    }
}