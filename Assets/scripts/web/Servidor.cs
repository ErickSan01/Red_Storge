using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//para acceder a internet
using UnityEngine.Networking;
/// <summary>
/// Clase que representa un servidor para consumir servicios web.
/// </summary>
[CreateAssetMenu(fileName = "Servidor", menuName = "RedStorge/Servidor", order = 1)]
public class Servidor : ScriptableObject
{
    /// <summary>
    /// URL del servidor. Por ejemplo, "http://localhost/redStorge/".
    /// </summary>
    public string server;

    /// <summary>
    /// Arreglo de servicios disponibles en el servidor.
    /// </summary>
    public Servicio[] servicios;

    /// <summary>
    /// Indica si se está consumiendo algún servicio en el servidor.
    /// </summary>
    public bool ocupado = false;

    /// <summary>
    /// Respuesta obtenida al consumir un servicio en el servidor.
    /// </summary>
    public Respuesta respuesta;

    /// <summary>
    /// Consumir un servicio en un hilo distinto al principal.
    /// </summary>
    /// <param name="nombre">Nombre del servicio a consumir.</param>
    /// <param name="datos">Datos necesarios para consumir el servicio.</param>
    /// <returns>Coroutine para consumir el servicio.</returns>
    public IEnumerator consumirServicio(string nombre, string[] datos)
    {
        ocupado = true;
        WWWForm formulario = new WWWForm();
        Servicio s = new Servicio();
        for (int i = 0; i < servicios.Length; i++)
        {
            if (servicios[i].nombre.Equals(nombre))
            {
                s = servicios[i];
            }
        }
        for (int i = 0; i < s.parametros.Length; i++)
        {
            formulario.AddField(s.parametros[i], datos[i]);
            Debug.Log(s.parametros[i]);
        }

        // En los PHP deben remplazar el GET por POST
        // Aquí se construye la URL con los parámetros
        UnityWebRequest www = UnityWebRequest.Post(server + "/" + s.URL, formulario);
        Debug.Log(server + "/" + s.URL);
        yield return www.SendWebRequest();
        // Comprobación para saber si se llegó la información
        if (www.result != UnityWebRequest.Result.Success)
        {
            respuesta = new Respuesta();
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            respuesta = JsonUtility.FromJson<Respuesta>(www.downloadHandler.text);
        }
        ocupado = false;
    }
}
[System.Serializable]
public class Servicio{
    //Nombre del servicio
    public string nombre;
    //Que archivo de php es 
    public string URL;
    //Los parametros que se deben introducir
    public string[] parametros;
}
//Esta clase es la respuesta para los codigos de error
[System.Serializable]
public class Respuesta{
    public int codigo;
    public string mensaje;

    public Respuesta(){
        codigo = 404;
        mensaje = "error";
    }

}
