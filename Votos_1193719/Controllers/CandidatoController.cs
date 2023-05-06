using Microsoft.AspNetCore.Mvc;
using Votos_1193719.Models;
using Votos_1193719.Repositories;
using Votos_1193719.Repositories.Implements;
using Votos_1193719.Services.Implements;

namespace Votos_1193719.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : Controller
    {
        private readonly IGenericRepository<Candidato> _repositoryCandidato;

        public CandidatoController(IGenericRepository<Candidato> repositoryCandidato)
        {
            _repositoryCandidato = repositoryCandidato;
        }

        [HttpPost]
        public async Task<IActionResult> add(newCandidato candidato)
        {
            //var candidatoService = new CandidatoService(new CandidatoRepository(_votesContext));
            //await candidatoService.Insert(candidato);
            Candidato newCandidato = new Candidato
            {
                Id = candidato.Id,
                Nombre = candidato.Nombre,
                Apellido = candidato.Apellido,
                PartidoPolitico = candidato.PartidoPolitico,
                Edad = candidato.Edad,
            };

            await _repositoryCandidato.Insert(newCandidato);
            //_votesContext.Candidatos.Add(newCandidato);
            //await _votesContext.SaveChangesAsync();


            return Ok("Candidato Agregado");
        }
    }
}
