using System;
using System.Collections.Generic;
namespace Models{
    public class ProgresoGeneral{
        public List<int> modulosTerminados;
        public int moduloActual;

        public List<int> getModulos(){
            return modulosTerminados;
        }
    }
}