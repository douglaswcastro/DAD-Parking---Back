using System;
using System.Collections.Generic;
using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Contracts
{
    public interface IVagaRepository : IRepositoryBase<Vaga>
    {        
        IEnumerable<Vaga> GetAllVagas();
        Vaga GetVagaById(Guid vagaId);
        void CreateVaga(Vaga vaga);
        void UpdateVaga(Vaga dbVaga, Vaga vaga);
        void DeleteVaga(Vaga vaga);
    }
}