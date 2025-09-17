using ProEventos.Domain.Classes;
using ProEventos.Infrastructure.Repositories.Eventos;
using ProEventos.Infrastructure.Repositories.General;
using System;
using System.Threading.Tasks;

namespace ProEventos.Application.UseCases.Eventos
{
    public class EventoUseCase : IEventoUseCase
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly IEventoRepository _eventoRepository;

        public EventoUseCase(IGeneralRepository generalRepository, IEventoRepository eventoRepository)
        {
            _generalRepository = generalRepository;
            _eventoRepository = eventoRepository;
        }


        public async Task<Evento> AddEvento(Evento evento)
        {
            try
            {
                _generalRepository.Add<Evento>(evento);

                if(await _generalRepository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventoByIdAsync(evento.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento evento)
        {
            try
            {
                var eventoAtual = await _eventoRepository.GetEventoByIdAsync(eventoId, false);

                if (eventoAtual == null) return null;

                evento.Id = eventoAtual.Id;

                _generalRepository.Update(evento);

                if (await _generalRepository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventoByIdAsync(evento.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);

                if (evento == null) throw new Exception("Evento não encontrado para deletar");

                _generalRepository.Delete<Evento>(evento);    
                
                return await _generalRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventos(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosAsync(includePalestrantes);

                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTema(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosByTemaAsync(tema, includePalestrantes);

                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoById(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, includePalestrantes);

                if (evento == null) return null;

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
