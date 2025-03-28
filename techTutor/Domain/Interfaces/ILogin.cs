using techTutor.Domain.Entity;

namespace techTutor.Domain.Interfaces
{
    public interface ILogin
    {
        bool GetLogin(Usuario usuario);

        bool AddLogin(Usuario usuario);
    }
}
