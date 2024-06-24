using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Models;
using JsonUtils;
/*
Esta clase inicia al entrar a Nivel2, lee el json de progreso del modulo, busca y elimina los pergaminos los cuales este marcado como
contestados para quitalos del camino del jugador. 
*/
/// <summary>
/// Gestiona la eliminación de pergaminos contestados en el juego.
/// </summary>
public class PergaminoManager : MonoBehaviour
{
    /// <summary>
    /// Método que se llama al iniciar el juego.
    /// Carga el progreso general y elimina los pergaminos contestados.
    /// </summary>
    void Start()
    {
        ProgresoGeneral progresoGeneral = ProgresoGeneralJson.CargarProgreso();
        int modulo = progresoGeneral.moduloActual;
        string json = File.ReadAllText(Application.dataPath+"/Modulos/Modulo"+modulo+"/Documentos/Progreso/Progreso.json");
        ProgresoModulo progreso = JsonUtility.FromJson<ProgresoModulo>(json);
        List<string> pergaminosContestados = progreso.pergaminosContestados;
        for (int i = 0; i < pergaminosContestados.Count; i++)
        {
            GameObject objetoEncontrado = GameObject.Find(pergaminosContestados[i]);
             if (objetoEncontrado != null)
             {
                Destroy(objetoEncontrado);
             }
            else
            {
                Debug.LogError("No se encontró el objeto con el nombre: ");
            }
        }
    }

    /// <summary>
    /// Método que se llama en cada frame del juego.
    /// </summary>
    void Update()
    {
        
    }
}
