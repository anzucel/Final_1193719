using System;
using System.Collections.Generic;

namespace Votos_1193719.Models;

public partial class Voto
{
    public int Id { get; set; }

    public int IdCandidato { get; set; }

    public int IdVotante { get; set; }

    public virtual Candidato IdCandidatoNavigation { get; set; } = null!;

    public virtual Votante IdVotanteNavigation { get; set; } = null!;
}
