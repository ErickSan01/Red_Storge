using System;
using System.Collections.Generic;
namespace Models{
    [System.Serializable]
    public class Opcion
    {
       public string Inciso;
       public string OpcionTexto;
       public bool Correcta;
    }
[System.Serializable]
public class Pregunta
    {
       public string Clave;
       public int Modulo;
       public string Fase;
       public string Planteamiento;
       public List<Opcion> Opciones;
    }

}
