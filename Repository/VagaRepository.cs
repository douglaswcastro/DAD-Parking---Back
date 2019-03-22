using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Model;
using DAD_Parking___Back.Data;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace DAD_Parking___Back.Repository
{
    public class VagaRepository : RepositoryBase<Vaga>, IVagaRepository
    {
        public VagaRepository(DADParkingDbContext repositoryContext)
            :base(repositoryContext)
        {            
        }

        public void CreateVaga(Vaga vaga)
        {
            vaga.Id = Guid.NewGuid();
            Create(vaga);
            Save();            
        }

        public IEnumerable<Vaga> GetAllVagas()
        {
            return FindAll()
                    .OrderBy(vaga => vaga.Id);
        }

        public Vaga GetVagaById(Guid vagaId)
        {
            return FindByCondition(vaga => vaga.Id.Equals(vagaId))
                    .FirstOrDefault();
        }        
    }
}