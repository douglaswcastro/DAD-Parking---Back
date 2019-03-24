using System;
using System.Collections.Generic;
using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Contracts
{
    public interface IVeiculoRepository : IRepositoryBase<Veiculo>
    {
        IEnumerable<Veiculo> GetAllVeiculos();
        Veiculo GetVeiculoById(Guid id);
        void CreateVeiculo(Veiculo veiculo);
        void UpdateVeiculo(Veiculo dbVeiculo, Veiculo veiculo);
        void DeleteVeiculo(Veiculo veiculo);
    }
}