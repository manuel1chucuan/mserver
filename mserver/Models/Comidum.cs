using System;
using System.Collections.Generic;

namespace mserver.Models;

public partial class Comidum
{
    public int ComidaId { get; set; }

    public string? NombreComida { get; set; }

    public int? TipoComidaId { get; set; }

    public virtual TipoComidum? TipoComida { get; set; }
}
