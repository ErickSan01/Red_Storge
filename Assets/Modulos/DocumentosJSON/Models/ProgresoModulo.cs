using System;
using System.Collections.Generic;
/// <summary>
/// Clase que representa el progreso de un módulo.
/// </summary>
namespace Models{
    public class ProgresoModulo{
        public string pergaminoActual;
        public List<string> pergaminosContestados;
        public Dictionary<string, string> secuencia;
    }
}