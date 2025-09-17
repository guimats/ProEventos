using ProEventos.Domain.Classes;
using System.Threading.Tasks;

namespace ProEventos.Infrastructure.Repositories.Eventos
{
    public interface IEventoRepository
    {
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}
