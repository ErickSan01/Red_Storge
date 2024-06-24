using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Models;

namespace JsonUtils{
    /// <summary>
    /// Clase que contiene métodos para trabajar con respuestas en formato JSON.
    /// </summary>
    public class RespuestaJson{
        /// <summary>
        /// Guarda la respuesta en formato JSON en un archivo.
        /// </summary>
        /// <param name="respuesta">La respuesta a guardar.</param>
        /// <param name="modulo">El número del módulo.</param>
        public static void GuardarRespuesta(DatosRespuesta respuesta, int modulo){
            string json = JsonUtility.ToJson(respuesta, true);
            Debug.Log("modulo de respuesta" + modulo);
            File.WriteAllText(Application.dataPath+"/Modulos/Modulo"+modulo+"/Documentos/Respuestas/Respuesta"+respuesta.ClavePregunta+".json", json);
        }
    }
}