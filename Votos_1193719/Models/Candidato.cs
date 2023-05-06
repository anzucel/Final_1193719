using System;
using System.Collections.Generic;

namespace Votos_1193719.Models;

public partial class Candidato
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string PartidoPolitico { get; set; } = null!;

    public int Edad { get; set; }

    public virtual ICollection<Voto> Votos { get; set; } = new List<Voto>();
}
