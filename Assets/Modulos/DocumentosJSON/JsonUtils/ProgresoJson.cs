using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Models;

namespace JsonUtils{
    /// <summary>
    /// Clase que proporciona métodos para cargar, guardar y actualizar el progreso en formato JSON.
    /// </summary>
    public class ProgresoJson{
        /// <summary>
        /// Carga el progreso de un módulo específico desde un archivo JSON.
        /// </summary>
        /// <param name="modulo">El número del módulo.</param>
        /// <returns>El objeto ProgresoModulo que representa el progreso cargado.</returns>
        public static ProgresoModulo CargarProgreso(int modulo){
            string json = File.ReadAllText(Application.dataPath+"/Modulos/Modulo"+modulo+"/Documentos/Progreso/Progreso.json");
            ProgresoModulo progreso = JsonUtility.FromJson<ProgresoModulo>(json);
            return progreso;
        }

        /// <summary>
        /// Guarda el progreso en un archivo JSON para un módulo específico.
        /// </summary>
        /// <param name="progreso">El objeto ProgresoModulo que representa el progreso a guardar.</param>
        /// <param name="modulo">El número del módulo.</param>
        public static void GuardarProgreso(ProgresoModulo progreso, int modulo){
            string json = JsonUtility.ToJson(progreso, true);
            File.WriteAllText(Application.dataPath+"/Modulos/Modulo"+modulo+"/Documentos/Progreso/Progreso.json", json);
        }

        /// <summary>
        /// Actualiza el progreso de un módulo específico con una clave y la siguiente clave.
        /// </summary>
        /// <param name="modulo">El número del módulo.</param>
        /// <param name="clave">La clave del progreso actual.</param>
        /// <param name="claveSiguiente">La clave del progreso siguiente.</param>
        public static void ActualizarProgreso(int modulo, string clave, string claveSiguiente){
            //Cargamos progreso actual
            ProgresoModulo progreso = CargarProgreso(modulo);
            
            //Actualizamos datos del progreso 
            progreso.pergaminosContestados.Add(clave);
            progreso.pergaminoActual = claveSiguiente;

            //Guardamos el progreso
            GuardarProgreso(progreso, modulo);
        }

    }
}