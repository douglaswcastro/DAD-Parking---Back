using System;
using System.Collections.Generic;
using System.Linq;
using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Model;
using DAD_Parking___Back.Data;

namespace DAD_Parking___Back.Repository
{
    public class VeiculoRepository : RepositoryBase<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(DADParkingDbContext repositoryContext)
            :base(repositoryContext)
        {            
        }

        public void CreateVeiculo(Veiculo veiculo)
        {
            Create(veiculo);
            Save();
        }

        public IEnumerable<Veiculo> GetAllVeiculos()
        {
            return FindAll()
                    .OrderBy(veiculo => veiculo.Modelo);
        }

        public Veiculo GetVeiculoByPlaca(String placaVeiculo)
        {
            return FindByCondition(veiculo => veiculo.Placa == placaVeiculo)
                    .FirstOrDefault();
        }
    }
}