namespace DAD_Parking___Back.Contracts
{
    public interface IRepositoryWrapper
    {
        IClienteRepository Cliente { get; }
        IEstacionamentoRepository Estacionamento { get; }
        ITarifaRepository Tarifa { get; }
        IVagaRepository Vaga { get; }
        IVeiculoRepository Veiculo { get; }
        IVinculoRepository Vinculo { get; }
    }
}