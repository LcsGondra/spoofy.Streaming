using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spoofy.streaming.application.Dto
{
    public class BandaQueryDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
    }
    public class AlbumQueryDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Banda { get; set; }
    }
    public class MusicaQueryDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }
        public string Banda { get; set; }
        public string Album { get; set; }
    }
}
