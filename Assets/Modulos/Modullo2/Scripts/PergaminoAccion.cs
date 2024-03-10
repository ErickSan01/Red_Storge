using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Models;

public class PergaminoAccion : MonoBehaviour
{
    public string clavePergamino;

    private void FijarPergaminoActual(string clavePergamino){
        string json = File.ReadAllText(Application.dataPath+"/Modulos/Modullo2/Documentos/Progreso/Progreso.json");
        ProgresoModulo progreso = JsonUtility.FromJson<ProgresoModulo>(json);
        progreso.pergaminoActual = clavePergamino;
        json = JsonUtility.ToJson(progreso, true);
        File.WriteAllText(Application.dataPath+"/Modulos/Modullo2/Documentos/Progreso/Progreso.json", json);
    }


    //Método que manda a la interface del pergamino
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FijarPergaminoActual(clavePergamino);
            SceneManager.LoadScene("PergaminoMod2");
        }
    }
}



