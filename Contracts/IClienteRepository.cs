using System;
using System.Collections.Generic;
using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Contracts
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {   
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetClienteById(Guid clienteId);
        void CreateCliente(Cliente cliente);
    }
}