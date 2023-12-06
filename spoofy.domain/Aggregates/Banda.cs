using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.domain.Aggregates
{
    public class Banda
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Genero { get; set; }

        public List<Album> Albums { get; set; }
        public Banda()
        {
            Albums = new List<Album>();
        }

        public void AdicionarAlbum(Album album)
        {
            Albums.Add(album);
        }
    }
}
