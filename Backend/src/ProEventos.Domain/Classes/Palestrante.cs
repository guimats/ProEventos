using System.Collections.Generic;

namespace ProEventos.Domain.Classes
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImageUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IList<RedeSocial> RedesSociais { get; set; }
        public IList<PalestranteEvento> PalestrantesEventos { get; set; }
    }

}
