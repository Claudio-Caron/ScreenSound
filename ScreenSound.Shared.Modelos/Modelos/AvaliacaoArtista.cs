using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Modelos.Modelos
{
    public class AvaliacaoArtista
    {
        public int Nota { get; set; }
        public int ArtistaId { get; set; }
        public virtual Artista? Artista { get; set; }
        public int PessoaId { get; set; }
    }
}
