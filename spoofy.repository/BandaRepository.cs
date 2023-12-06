﻿using Streaming.domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return Bandas.Select(x =>
            {
                return (from y in x.Albums
                        select y.Musicas.FirstOrDefault(m => m.Id == idMusica))
                       .FirstOrDefault();
            }).FirstOrDefault();
        }
    }
}