using System;
using System.Collections.Generic;
using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Contracts
{
    public interface ITarifaRepository : IRepositoryBase<Tarifa>
    { 
        IEnumerable<Tarifa> GetAllTarifas();
        Tarifa GetTarifaById(Guid tarifaId);
        void CreateTarifa(Tarifa tarifa);
    }
}