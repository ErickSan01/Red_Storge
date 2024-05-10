using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Models;
using JsonUtils;
//Esta clase contiene un método el cual cuando el juegador colisiona con un pergamino fija este como pergamino actual 
//y lo manda a la interface de la pregunta
public class PergaminoAccion : MonoBehaviour
{
    public string clavePergamino;

    private void FijarPergaminoActual(string clavePergamino){
        ProgresoGeneral progresoGeneral = ProgresoGeneralJson.CargarProgreso();
        int modulo = progresoGeneral.moduloActual;
        string json = File.ReadAllText(Application.dataPath+"/Modulos/Modulo"+modulo+"/Documentos/Progreso/Progreso.json");
        ProgresoModulo progreso = JsonUtility.FromJson<ProgresoModulo>(json);
        progreso.pergaminoActual = clavePergamino;
        json = JsonUtility.ToJson(progreso, true);
        File.WriteAllText(Application.dataPath+"/Modulos/Modulo"+modulo+"/Documentos/Progreso/Progreso.json", json);
    }


    //Método que manda a la interface del pergamino
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProgresoGeneral progresoGeneral = ProgresoGeneralJson.CargarProgreso();
        int modulo = progresoGeneral.moduloActual;
        if (collision.gameObject.CompareTag("Player"))
        {
            FijarPergaminoActual(clavePergamino);
            if(modulo == 2)
            {
                SceneManager.LoadScene("PergaminoMod2");
        
            }
            if(modulo == 3)
            {
                SceneManager.LoadScene("PergaminoMod3");
            }
            if(modulo == 4)
            {
                SceneManager.LoadScene("PergaminoMod4");
            }
        
        }
                
    }
}



