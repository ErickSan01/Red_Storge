using System;
using System.Collections.Generic;
namespace Models{
    /// <summary>
    /// Clase que representa el progreso de los módulos completados.
    /// </summary>
    public class ProgresoModulosCompletados{
        public List<string> modulosTerminados;

        /// <summary>
        /// Obtiene la lista de módulos completados.
        /// </summary>
        /// <returns>La lista de módulos completados.</returns>
        public List<string> getModulos(){
            return modulosTerminados;
        }
    }
}