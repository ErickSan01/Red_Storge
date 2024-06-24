using System;
using System.Collections.Generic;
namespace Models{
    /// <summary>
    /// Clase que representa el progreso general de un usuario en los módulos.
    /// </summary>
    public class ProgresoGeneral{
        public List<int> modulosTerminados;
        public int moduloActual;

        /// <summary>
        /// Obtiene la lista de módulos terminados.
        /// </summary>
        /// <returns>La lista de módulos terminados.</returns>
        public List<int> getModulos(){
            return modulosTerminados;
        }
    }
}