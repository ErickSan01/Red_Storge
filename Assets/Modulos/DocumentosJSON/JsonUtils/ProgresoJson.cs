using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Models;

namespace JsonUtils{
    public class ProgresoJson{
        public static ProgresoModulo CargarProgreso(int modulo){
            string json = File.ReadAllText(Application.dataPath+"/Modulos/Modulo"+modulo+"/Documentos/Progreso/Progreso.json");
            ProgresoModulo progreso = JsonUtility.FromJson<ProgresoModulo>(json);
            return progreso;
        }

        public static void GuardarProgreso(ProgresoModulo progreso, int modulo){
            string json = JsonUtility.ToJson(progreso, true);
            File.WriteAllText(Application.dataPath+"/Modulos/Modulo"+modulo+"/Documentos/Progreso/Progreso.json", json);
        }

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