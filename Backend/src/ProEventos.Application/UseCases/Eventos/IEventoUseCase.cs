using ProEventos.Domain.Classes;
using System.Threading.Tasks;

namespace ProEventos.Application.UseCases.Eventos
{
    public interface IEventoUseCase
    {
        Task<Evento> AddEvento(Evento evento);
        Task<Evento> UpdateEvento(int eventoId, Evento evento);
        Task<bool> DeleteEvento(int eventoId);

        Task<Evento[]> GetAllEventos(bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByTema(string tema, bool includePalestrantes = false);
        Task<Evento> GetEventoById(int eventoId, bool includePalestrantes = false);
    }

}
