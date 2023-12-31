﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace spoofy.streaming.application.Dto
{
    public class BandaDto
    {
        public Guid Id { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Descricao { get; set; }
        [Required]
        public String Genero { get; set; }
        public List<AlbumDto> Albums { get; set; }
    }

    public class BandaUpdateDto
    {
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Descricao { get; set; }
        [Required]
        public String Genero { get; set; }
    }

    public class AlbumDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public List<MusicaDto> Musicas { get; set; }
    }

    public class MusicaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }
    }
}
