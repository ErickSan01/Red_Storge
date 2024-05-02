using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Models;

namespace JsonUtils{
    public class ProgresoGeneralJson{
        public static ProgresoGeneral CargarProgreso(){
            string json = File.ReadAllText(Application.dataPath+"/Modulos/General/Documentos/ProgresoGeneral/Progreso.json");
            ProgresoGeneral progreso = JsonUtility.FromJson<ProgresoGeneral>(json);
            return progreso;
        }

        public static void GuardarProgreso(ProgresoGeneral progreso, int modulo){
            progreso.modulosTerminados.Add(progreso.moduloActual);
            progreso.moduloActual = modulo;
        }

        public static void ActualizarProgreso(int modulo){
            //Cargamos progreso actual
            ProgresoGeneral progreso = CargarProgreso();

            //Actualizamos datos del progreso 
            GuardarProgreso(progreso, modulo);

            //Guardamos el progreso
            string json = JsonUtility.ToJson(progreso, true);
            File.WriteAllText(Application.dataPath+"/Modulos/General/Documentos/ProgresoGeneral/Progreso.jsonn", json);
        }
    }
}