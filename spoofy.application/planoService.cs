using spoofy.streaming.application.Dto;
using spoofy.streaming.repository;
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
    }
}
