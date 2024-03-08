using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Models;

public class PergaminoManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(Application.dataPath+"/Modulos/Modullo2/Documentos/Progreso/Progreso.json");
        ProgresoModulo progreso = JsonUtility.FromJson<ProgresoModulo>(json);
        List<string> pergaminosContestados = progreso.pergaminosContestados;
        for (int i = 0; i < pergaminosContestados.Count; i++)
        {
            GameObject objetoEncontrado = GameObject.Find(pergaminosContestados[i]);
             if (objetoEncontrado != null)
             {
                Debug.Log("Se encontró el objeto: " + objetoEncontrado.name);
                Destroy(objetoEncontrado);
             }
            else
            {
                Debug.LogError("No se encontró el objeto con el nombre: ");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
