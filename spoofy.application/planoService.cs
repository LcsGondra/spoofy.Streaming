using Microsoft.VisualBasic;
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
    public class PlanoService
    {
        public PlanoRepository PlanoRepository { get; set; }
        public PlanoService() 
        {
            PlanoRepository = new PlanoRepository();
        }

        public PlanoDto CriarPlano(PlanoDto dto)
        {
            Plano plano = new Plano();
            plano.Descricao = dto.Descricao;
            plano.Valor = dto.Valor;
            plano.Nome = dto.Nome;
            
            if(PlanoRepository.GetPlanos().Any(x => x.Nome == plano.Nome) == true)
            {
                throw new BusinessException(new BusinessValidation()
                {
                    ErrorMessage = "Ja existe um plano com esse nome",
                    ErrorName = nameof(CriarPlano)
                });
            }

            PlanoRepository.SalvarPlano(plano);
            dto.Id = plano.Id;
            return dto;
        }

        public PlanoDto ObterPlano(Guid id)
        {
            var plano = this.PlanoRepository.PlanoPorId(id);

            if (plano == null)
                return null;

            return new PlanoDto()
            {
                Descricao = plano.Descricao,
                Id = plano.Id,
                Nome = plano.Nome,
                Valor = plano.Valor,
            };

        }

        public void AtualizarPlano(Guid id, PlanoDto dto)
        {
            var planoOld = this.PlanoRepository.PlanoPorId(id);

            if (planoOld == null)
            {
                throw new BusinessException(new BusinessValidation()
                {
                    ErrorMessage = "Nao encontrei plano",
                    ErrorName = nameof(AtualizarPlano)
                });
            }

           var plano = new Plano()
           {
               Descricao = dto.Descricao,
               Id = planoOld.Id,
               Nome = dto.Nome,
               Valor = dto.Valor
           };

            PlanoRepository.Update(plano);
        }
    }
}
