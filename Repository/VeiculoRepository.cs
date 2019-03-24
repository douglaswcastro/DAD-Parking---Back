using System;
using System.Collections.Generic;
using System.Linq;
using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Model;
using DAD_Parking___Back.Data;
using DAD_Parking___Back.Extensions.Model;

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

        public void DeleteVeiculo(Veiculo veiculo)
        {
            Delete(veiculo);
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

        public void UpdateVeiculo(Veiculo dbVeiculo, Veiculo veiculo)
        {
            dbVeiculo.Map(veiculo);
            Update(dbVeiculo);
            Save();
        }
    }
}