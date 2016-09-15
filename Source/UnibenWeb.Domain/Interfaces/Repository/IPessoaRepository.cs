using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Domain.Interfaces.Repository
{
    public interface IPessoaRepository: IBaseRepository<Pessoa>
    {
        Pessoa BuscaPorCPF(string cpf);
    }
}
