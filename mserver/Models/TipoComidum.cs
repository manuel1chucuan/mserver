using System;
using System.Collections.Generic;

namespace mserver.Models;

public partial class TipoComidum
{
    public int TipoComidaId { get; set; }

    public string? TipoComida { get; set; }

    public virtual ICollection<Comidum> Comida { get; set; } = new List<Comidum>();
}
