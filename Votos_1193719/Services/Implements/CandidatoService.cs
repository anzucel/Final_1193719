using Votos_1193719.Models;
using Votos_1193719.Repositories;

namespace Votos_1193719.Services.Implements
{
    public class CandidatoService : GenericService<newCandidato>, ICandidatoService
    {
        private ICandidatoRepository _candidatoRepository;
        public CandidatoService(ICandidatoRepository candidatoRepository) : base(candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }
    }
}
