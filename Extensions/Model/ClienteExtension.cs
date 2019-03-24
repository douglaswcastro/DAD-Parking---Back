using DAD_Parking___Back.Model;

namespace DAD_Parking___Back.Extensions.Model
{
    public static class ClienteExtension
    {
        public static void Map(this Cliente dbCliente, Cliente cliente)
        {
            dbCliente.CPF = cliente.CPF;
            dbCliente.Celular = cliente.Celular;
            dbCliente.Nome = cliente.Nome;
            dbCliente.Veiculo = cliente.Veiculo;
        }
    }
}