using System;
using System.Collections.Generic;
using System.Linq;
using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Model;
using DAD_Parking___Back.Data;
using DAD_Parking___Back.Extensions.Model;

namespace DAD_Parking___Back.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(DADParkingDbContext repositoryContext)
            :base(repositoryContext)
        {            
        }

        public void CreateCliente(Cliente cliente)
        {
            cliente.Id = Guid.NewGuid();
            Create(cliente);
            Save();
        }

        public void DeleteCliente(Cliente cliente)
        {
            Delete(cliente);
            Save();
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return FindAll()
                    .OrderBy(Cliente => Cliente.Nome);
        }

        public Cliente GetClienteById(Guid clienteId)
        {
            return FindByCondition(cliente => cliente.Id.Equals(clienteId))
                    .FirstOrDefault();
        }

        public void UpdateCliente(Cliente dbCliente, Cliente cliente)
        {
            dbCliente.Map(cliente);
            Update(dbCliente);
            Save();
        }
    }
}