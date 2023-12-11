using Streaming.domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace spoofy.streaming.repository
{
    public class BandaRepository
    {
        private static List<Banda> Bandas = new List<Banda>();

        public void Criar(Banda banda)
        {
            banda.Id = Guid.NewGuid();
            Bandas.Add(banda);
        }

        public Banda ObterBanda(Guid id)
        {
            return Bandas.FirstOrDefault(x => x.Id == id);
        }

        public Musica ObterMusica(Guid idMusica)
        {
            Musica result = null;

            foreach (var banda in Bandas)
            {
                foreach (var album in banda.Albums)
                {
                    result = album.Musicas.FirstOrDefault(x => x.Id == idMusica);

                    if (result != null)
                        break;
                }
            }

            return result;
        }

        public Album ObterAlbum(Guid idAlbum)
        {
            Album result = null;
            foreach (var banda in Bandas)
            {
                result = banda.Albums.FirstOrDefault(x => x.Id == idAlbum);

                if (result != null)
                    break;
            }

            return result;
        }

        public List<Banda> GetBandas()
        {
            var bandas = Bandas;
            return bandas;
        }

        public void UpdateBanda(Banda banda)
        {
            Banda bandaOld = ObterBanda(banda.Id);
            Bandas.Remove(bandaOld);
            Bandas.Add(banda);
        }
    }
}