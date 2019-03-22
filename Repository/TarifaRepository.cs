using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CreateTarifa(Tarifa tarifa)
        {
            tarifa.Id = Guid.NewGuid();
            Create(tarifa);
            Save();
        }

        public IEnumerable<Tarifa> GetAllTarifas()
        {
            return FindAll()
                    .OrderBy(tarifa => tarifa.TipoTarifa);
        }

        public Tarifa GetTarifaById(Guid tarifaId)
        {
            return FindByCondition(tarifa => tarifa.Id.Equals(tarifaId))
                    .FirstOrDefault();
        }
    }
}