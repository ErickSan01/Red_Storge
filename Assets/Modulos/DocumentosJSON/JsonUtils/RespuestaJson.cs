using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Models;

namespace JsonUtils{
    public class RespuestaJson{
        public static void GuardarRespuesta(DatosRespuesta respuesta, int modulo){
            string json = JsonUtility.ToJson(respuesta, true);
            Debug.Log("modulo de respuesta" + modulo);
            File.WriteAllText(Application.dataPath+"/Modulos/Modulo"+modulo+"/Documentos/Respuestas/Respuesta"+respuesta.ClavePregunta+".json", json);


        }
    }
}