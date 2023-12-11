using spoofy.core;
using spoofy.streaming.application.Dto;
using spoofy.streaming.repository;
using Streaming.domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spoofy.streaming.application
{
    public class BandaService
    {
        public BandaRepository Repository = new BandaRepository();
        public BandaService() { }

        public BandaDto Criar(BandaDto dto)
        {
            Banda banda = new Banda()
            {
                Descricao = dto.Descricao,
                Nome = dto.Nome,
                Genero = dto.Genero,
            };

            if (dto.Albums != null)
            {
                foreach (var item in dto.Albums)
                {
                    Album album = new Album()
                    {
                        Id = Guid.NewGuid(),
                        Nome = item.Nome,
                    };

                    if (item.Musicas != null)
                    {
                        foreach (var musica in item.Musicas)
                        {
                            album.AdicionarMusicas(new Musica()
                            {
                                Duracao = musica.Duracao,
                                Nome = musica.Nome,
                                Album = album,
                                Id = Guid.NewGuid()
                            });
                        }
                    }

                    banda.AdicionarAlbum(album);
                }
            }

            this.Repository.Criar(banda);
            dto.Id = banda.Id;

            return dto;

        }

        public BandaDto ObterBanda(Guid id)
        {
            var banda = this.Repository.ObterBanda(id);

            if (banda == null)
                return null;

            BandaDto dto = new BandaDto()
            {
                Id = banda.Id,
                Descricao = banda.Descricao,
                Nome = banda.Nome,
                Genero = banda.Genero,
            };

            if (banda.Albums != null)
            {
                dto.Albums = new List<AlbumDto>();

                foreach (var album in banda.Albums)
                {
                    AlbumDto albumDto = new AlbumDto()
                    {
                        Id = album.Id,
                        Nome = album.Nome,
                        Musicas = new List<MusicaDto>()
                    };

                    album.Musicas?.ForEach(m =>
                    {
                        albumDto.Musicas.Add(new MusicaDto()
                        {
                            Id = m.Id,
                            Duracao = m.Duracao,
                            Nome = m.Nome
                        });
                    });

                    dto.Albums.Add(albumDto);
                }
            }

            return dto;

        }

        public MusicaDto ObterMusica(Guid idMusica)
        {
            var musica = Repository.ObterMusica(idMusica);


            if (musica == null)
                return null;

            return new MusicaDto()
            {
                Duracao = musica.Duracao,
                Id = musica.Id,
                Nome = musica.Nome
            };
        }
        public AlbumDto ObterAlbum(Guid idAlbum)
        {
            var album = Repository.ObterAlbum(idAlbum);


            if (album == null)
                return null;

            AlbumDto albumDto = new AlbumDto()
            {
                Id = album.Id,
                Nome = album.Nome,
                Musicas = new List<MusicaDto>()
            };

            album.Musicas?.ForEach(m =>
            {
                albumDto.Musicas.Add(new MusicaDto()
                {
                    Id = m.Id,
                    Duracao = m.Duracao,
                    Nome = m.Nome
                });
            });

            return albumDto;
        }


        public void AtualizarBanda(Guid idBanda, BandaDto dto)
        {
            var banda = Repository.ObterBanda(idBanda);
            
            if (banda == null)
            {
                throw new BusinessException(new BusinessValidation()
                {
                    ErrorMessage = "Nao encontrei banda",
                    ErrorName = nameof(AtualizarBanda)
                });
            }

            banda.Nome = dto.Nome;
            banda.Genero = dto.Genero;
            banda.Descricao = dto.Descricao;
            Repository.UpdateBanda(banda);
        }

        public List<object> SearchQuery(string query)
        {
            var bandas = Repository.GetBandas();
            query = query.ToLower();
            List<object> results = new List<object>();

            foreach (var banda in bandas)
            {
                var bandaDto = new BandaQueryDto()
                {
                    Id = banda.Id,
                    Nome = banda.Nome,
                    Genero = banda.Genero
                };
                var albums = banda.Albums;
                foreach (var album in albums)
                {
                    var albumDto = new AlbumQueryDto()
                    {
                        Id = album.Id,
                        Nome = album.Nome,
                        Banda = banda.Nome
                    };
                    var musicas = album.Musicas;
                    
                    foreach (var musica in musicas)
                    {
                        var musicaDto = new MusicaQueryDto()
                        {
                            Duracao = musica.Duracao,
                            Id = musica.Id,
                            Nome = musica.Nome,
                            Banda = banda.Nome,
                            Album = album.Nome
                        };

                        if (musica.Nome.ToLower().Contains(query))
                        {
                            results.Add(musicaDto);
                        }
                    }

                    if (album.Nome.ToLower().Contains(query))
                    {
                        results.Add(albumDto);
                    }
                }
                if (banda.Nome.ToLower().Contains(query))
                {
                    results.Add(bandaDto); 
                }
            }
            return results;
        }
    }
}
