using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Data;

namespace DAD_Parking___Back.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DADParkingDbContext _repoContext;
        private IClienteRepository _cliente;
        private IEstacionamentoRepository _estacionamento;
        private ITarifaRepository _tarifa;
        private IVagaRepository _vaga;
        private IVeiculoRepository _veiculo;
        private IVinculoRepository _vinculo;

        public RepositoryWrapper(DADParkingDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IClienteRepository Cliente
        {
            get {
                if (_cliente == null)
                {
                    _cliente = new ClienteRepository(_repoContext);
                }
                return _cliente;
            }
        }
        public IEstacionamentoRepository Estacionamento
        {
            get {
                if (_estacionamento == null)
                {
                    _estacionamento = new EstacionamentoRepository(_repoContext);
                }
                return _estacionamento;
            }
        }
        public ITarifaRepository Tarifa
        {
            get {
                if (_tarifa == null)
                {
                    _tarifa = new TarifaRepository(_repoContext);
                }
                return _tarifa;
            }
        }
        public IVagaRepository Vaga
        {
            get {
                if (_vaga == null)
                {
                    _vaga = new VagaRepository(_repoContext);
                }
                return _vaga;
            }
        }
        public IVeiculoRepository Veiculo
        {
            get {
                if (_veiculo == null)
                {
                    _veiculo = new VeiculoRepository(_repoContext);
                }
                return _veiculo;
            }
        }
        public IVinculoRepository Vinculo
        {
            get {
                if (_vinculo == null)
                {
                    _vinculo = new VinculoRepository(_repoContext);
                }
                return _vinculo;
            }
        }
        
    }
}