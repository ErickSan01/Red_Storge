using System;
using System.Collections.Generic;
namespace Models{
     /// <summary>
     /// Clase que representa una opción de respuesta para una pregunta.
     /// </summary>
     [System.Serializable]
     public class Opcion
     {
         public string Inciso;
         public string OpcionTexto;
         public bool Correcta;
     }

     /// <summary>
     /// Clase que representa una pregunta.
     /// </summary>
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
