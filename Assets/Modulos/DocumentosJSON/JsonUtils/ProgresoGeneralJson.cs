using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Models;

namespace JsonUtils{
    /// <summary>
    /// Clase de utilidades para el manejo de archivos JSON relacionados con el progreso general.
    /// </summary>
    public class ProgresoGeneralJson{
        /// <summary>
        /// Carga el progreso general desde un archivo JSON.
        /// </summary>
        /// <returns>El objeto ProgresoGeneral cargado desde el archivo JSON.</returns>
        public static ProgresoGeneral CargarProgreso(){
            string json = File.ReadAllText(Application.dataPath+"/Modulos/General/Documentos/ProgresoGeneral/Progreso.json");
            ProgresoGeneral progreso = JsonUtility.FromJson<ProgresoGeneral>(json);
            return progreso;
        }


        /// <summary>
        /// Actualiza el progreso general con el módulo actualizado.
        /// </summary>
        /// <param name="modulo">El número del módulo actualizado.</param>
        public static void ActualizarProgreso(int modulo){
            //Cargamos progreso actual
            ProgresoGeneral progreso = CargarProgreso();

            //Actualizamos datos del progreso 
            progreso.modulosTerminados.Add(progreso.moduloActual);
            progreso.moduloActual = modulo;

            //Guardamos el progreso
            string json = JsonUtility.ToJson(progreso, true);
            File.WriteAllText(Application.dataPath+"/Modulos/General/Documentos/ProgresoGeneral/Progreso.json", json);
        }
    }
}