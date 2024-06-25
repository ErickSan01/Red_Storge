using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Models;

namespace JsonUtils{
    /// <summary>
    /// Clase que proporciona métodos para guardar y cargar preguntas en formato JSON.
    /// </summary>
    public class PreguntaJson{
        /// <summary>
        /// Guarda una pregunta en formato JSON en la ubicación especificada.
        /// </summary>
        /// <param name="pregunta">La pregunta a guardar.</param>
        public static void GuardarPregunta(Pregunta pregunta){
            string json = JsonUtility.ToJson(pregunta, true);
            File.WriteAllText(Application.dataPath+"/Modulos/"+pregunta.Modulo+"/Documentos/Preguntas/"+pregunta.Clave+".json", json);
        }

        /// <summary>
        /// Carga una pregunta en formato JSON desde la ubicación especificada.
        /// </summary>
        /// <param name="clave">La clave de la pregunta a cargar.</param>
        /// <returns>La pregunta cargada.</returns>
        public static Pregunta CargarPregunta(string clave){
            
            //TextAsset txtAsset = Resources.Load<TextAsset>("JSON/Modulo"+clave[1]+"/Preguntas/"+clave) as TextAsset;
            string json = File.ReadAllText(Application.dataPath+"/Modulos/Modulo"+clave[1]+"/Documentos/Preguntas/"+clave+".json");
            //string json = txtAsset.text;
            
            Pregunta pregunta = JsonUtility.FromJson<Pregunta>(json);
            return pregunta;
        }
    }
}