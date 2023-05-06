using Votos_1193719.Models;

namespace Votos_1193719.Repositories.Implements
{
    public class CandidatoRepository : GenericRepository<newCandidato>, ICandidatoRepository
    {
        public CandidatoRepository(VotesContext votesContext) : base(votesContext) 
        {

        }
    }
}
