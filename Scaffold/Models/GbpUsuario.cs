using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class GbpUsuario
{
    public long IdUsuario { get; set; }

    public string DniUsuario { get; set; } = null!;

    public string? NombreUsuario { get; set; }

    public string? ApellidosUsuario { get; set; }

    public string? TlfUsuario { get; set; }

    public string? EmailUsuario { get; set; }

    public string? ClaveUsuario { get; set; }

    public bool? EstaBloqueadoUsuario { get; set; }

    public DateTime? FchFinBloqueoUsuario { get; set; }

    public long? IdAcceso { get; set; }

    public DateTime? FchAltaUsuario { get; set; }

    public DateTime? FchBajaUsuario { get; set; }

    public virtual GbpAcceso? IdAccesoNavigation { get; set; }
}
