using techTutor.Domain.Entity;

namespace techTutor.Domain.Interfaces
{
    public interface IScore
    {
        bool AddScore(Usuario usuario);
        Usuario GetScore(Usuario usuario);
    }
}
