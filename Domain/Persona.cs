﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domain;

public partial class Persona
{
    public int PersonaId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public byte[]? FotoUsuario { get; set; }

    public int? EstadoCivil { get; set; }

    public bool TieneHermanos { get; set; }
}
