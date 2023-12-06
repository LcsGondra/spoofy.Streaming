using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.domain.Aggregates
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Banda Banda { get; set; }

        public List<Musica> Musicas { get; set; }

        public Album()
        {
            Musicas = new List<Musica>();
        }

        public void AdicionarMusicas(List<Musica> musicas)
        {
            Musicas.AddRange(musicas);
        }

        public void AdicionarMusicas(Musica musicas)
        {
            Musicas.Add(musicas);
        }


    }
}
