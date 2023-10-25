using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class GbpAcceso
{
    public long IdAcceso { get; set; }

    public string? CodigoAcceso { get; set; }

    public string? DescripcionAcceso { get; set; }

    public virtual ICollection<GbpUsuario> GbpUsuarios { get; set; } = new List<GbpUsuario>();
}
