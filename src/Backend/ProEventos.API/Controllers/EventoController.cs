using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProEventos.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[]
        {
            new Evento()
            {
                Id = 1,
                Tema = "Angular 11 e .NET 5",
                Local = "Belo Horizonte",
                Lote = "1º Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemUrl = "foto.png"
            },
            new Evento()
            {
                Id = 2,
                Tema = "Angular e suas novidades",
                Local = "Sao Paulo",
                Lote = "2º Lote",
                QtdPessoas = 350,
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                ImagemUrl = "foto1.png"
            }
        };

        public EventoController() { }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }


        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(e => e.Id == id);
        }
    }
}
