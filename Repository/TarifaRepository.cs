using System;
using System.Collections.Generic;
using System.Linq;
using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Model;
using DAD_Parking___Back.Data;
using DAD_Parking___Back.Extensions.Model;

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

        public void DeleteTarifa(Tarifa tarifa)
        {
            Delete(tarifa);
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

        public void UpdateTarifa(Tarifa dbTarifa, Tarifa tarifa)
        {
            dbTarifa.Map(tarifa);
            Update(dbTarifa);
            Save();
        }
    }
}