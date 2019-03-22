using System;
using System.Collections.Generic;
using System.Linq;
using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Model;
using DAD_Parking___Back.Data;

namespace DAD_Parking___Back.Repository
{
    public class EstacionamentoRepository : RepositoryBase<Estacionamento>, IEstacionamentoRepository
    {
        public EstacionamentoRepository(DADParkingDbContext repositoryContext)
            :base(repositoryContext)
        {            
        }

        public void CreateEstacionamento(Estacionamento estacionamento)
        {
            estacionamento.Id = Guid.NewGuid();
            Create(estacionamento);
            Save();
        }

        public IEnumerable<Estacionamento> GetAllEstacionamentos()
        {
            return FindAll()
                    .OrderBy(estacionamento => estacionamento.Nome);
        }

        public Estacionamento GetEstacionamentoById(Guid estacionamentoId)
        {
            return FindByCondition(estacionamento => estacionamento.Id.Equals(estacionamentoId))
                    .FirstOrDefault();
        }
    }
}