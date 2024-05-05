using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Models;

namespace JsonUtils{
    public class PreguntaJson{
        public static void GuardarPregunta(Pregunta pregunta){
            string json = JsonUtility.ToJson(pregunta, true);
            File.WriteAllText(Application.dataPath+"/Modulos/"+pregunta.Modulo+"/Documentos/Preguntas/"+pregunta.Clave+".json", json);
        }

        public static Pregunta CargarPregunta(string clave){
            string json = File.ReadAllText(Application.dataPath+"/Modulos/Modulo"+clave[1]+"/Documentos/Preguntas/"+clave+".json");
            Pregunta pregunta = JsonUtility.FromJson<Pregunta>(json);
            return pregunta;
        }


    }
}