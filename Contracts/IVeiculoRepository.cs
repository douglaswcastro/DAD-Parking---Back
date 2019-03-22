using System;
using System.Collections.Generic;
using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Contracts
{
    public interface IVeiculoRepository : IRepositoryBase<Veiculo>
    {
        IEnumerable<Veiculo> GetAllVeiculos();
        Veiculo GetVeiculoByPlaca(String placaVeiculo);
        void CreateVeiculo(Veiculo veiculo);
    }
}