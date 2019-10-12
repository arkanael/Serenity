using Serenity.Infra.Data.Entities;

namespace Serenity.Infra.Data.Contacts.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, int>
    {
        Usuario Get(string login);
        Usuario Get(string login, string senha);
    }
}
