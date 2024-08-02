using System;
using System.Collections.Generic;

namespace FirstDataGrid;

public partial class Persona
{
    public string Id { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateTime? Fecnac { get; set; }

    public double? Salario { get; set; }

    public double? Estatura { get; set; }
}
