using Domain.ApiSecond;

namespace Repository.ApiSecond.Intefaces
{
    public interface IClienteRepository
    {
        List<Cliente> ClientesActivos();
    }
}
