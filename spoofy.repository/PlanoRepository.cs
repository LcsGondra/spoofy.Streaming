using Streaming.domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spoofy.streaming.repository
{
    public class PlanoRepository
    {
        private static List<Plano> Planos;
        public PlanoRepository()
        {
            if (Planos == null)
            {
                Planos = new List<Plano>();
                Planos.Add(new Plano()
                {
                    Descricao = "Plano inicial gratis para quem acabou de criar a sua conta, direito a musicas ilimitadas com anuncio",
                    Nome = "Spoofy Basic",
                    Valor = 0M,
                    Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
                });
            }
        }

        public void SalvarPlano(Plano plano)
        {
            plano.Id = Guid.NewGuid();
            Planos.Add(plano);
        }

        public Plano PlanoPorId(Guid id)
        {
            return Planos.FirstOrDefault(x => x.Id == id);
        }

        public List<Plano> GetPlanos()
        {
            var planos = Planos;
            return planos;
        }

        public void Update(Plano plano)
        {
            Plano planoOld = PlanoPorId(plano.Id);
            Planos.Remove(planoOld);
            Planos.Add(plano);
        }
    }
}
