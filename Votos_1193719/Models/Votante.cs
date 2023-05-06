using System;
using System.Collections.Generic;

namespace Votos_1193719.Models;

public partial class Votante
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Ip { get; set; } = null!;

    public virtual ICollection<Voto> Votos { get; set; } = new List<Voto>();
}
