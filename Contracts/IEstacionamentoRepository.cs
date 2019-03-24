using System;
using System.Collections.Generic;
using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Contracts
{
    public interface IEstacionamentoRepository : IRepositoryBase<Estacionamento>
    {        
        IEnumerable<Estacionamento> GetAllEstacionamentos();
        Estacionamento GetEstacionamentoById(Guid estacionamentoId);
        void CreateEstacionamento(Estacionamento estacionamento);
        void UpdateEstacionamento(Estacionamento dbEstacionamento, Estacionamento estacionamento);
        void DeleteEstacionamento(Estacionamento estacionamento);
    }
}