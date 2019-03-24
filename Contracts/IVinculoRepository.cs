using System;
using System.Collections.Generic;
using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Contracts
{
    public interface IVinculoRepository : IRepositoryBase<Vinculo>
    {      
        IEnumerable<Vinculo> GetAllVinculos();
        Vinculo GetVinculoById(Guid vinculodId);
        void CreateVinculo(Vinculo vinculo);
        void UpdateVinculo(Vinculo dbVinculo, Vinculo vinculo);
        void DeleteVinculo(Vinculo vinculo);
    }
}