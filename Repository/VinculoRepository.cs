using System;
using System.Collections.Generic;
using System.Linq;
using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Model;
using DAD_Parking___Back.Data;
using DAD_Parking___Back.Extensions.Model;

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

        public void DeleteVinculo(Vinculo vinculo)
        {
            Delete(vinculo);
            Save();
        }

        public IEnumerable<Vinculo> GetAllVinculos()
        {
            return FindAll()
                    .OrderBy(vinculo => vinculo.Cliente.Nome);
        }

        public Vinculo GetVinculoById(Guid vinculodId)
        {
            return FindByCondition(vinculo => vinculo.Id.Equals(vinculodId))
                    .FirstOrDefault();
        }

        public void UpdateVinculo(Vinculo dbVinculo, Vinculo vinculo)
        {
            dbVinculo.Map(vinculo);
            Update(dbVinculo);
            Save();
        }

        public void UpdateVinculo(Vinculo vinculo)
        {
            Update(vinculo);
            Save();
        }
    }
}