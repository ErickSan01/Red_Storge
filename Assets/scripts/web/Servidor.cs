using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//para acceder a internet
using UnityEngine.Networking;
[CreateAssetMenu(fileName = "Servidor", menuName ="RedStorge/Servidor", order = 1)]
public class Servidor : ScriptableObject
{
    //En esta propiedad se pone el url, en nuestro caso es http://localhost/redStorge/
    public string server;
    public Servicio[] servicios;
    //Para saber si se está consumiendo algun servicio;
    public bool ocupado = false;
    public Respuesta respuesta;
    // Se consumira un servicio en un hilo distinto al principal
    //Que servicio se va a consumir y cuales datos
    public IEnumerator consumirServicio(string nombre, string[] datos){
        ocupado = true;
        WWWForm formulario = new WWWForm();
        Servicio s = new Servicio();
        for(int i = 0; i < servicios.Length; i++){
            if(servicios[i].Equals(nombre)){
                s = servicios[i];
            }
        }
        for(int i = 0; i < s.parametros.Length; i++){
            formulario.AddField(s.parametros[i], datos[i]);
        }
        //En los PHP deben remplazar el GET por POST
        //Aqui se contruye la URL con los parametros
        UnityWebRequest www = UnityWebRequest.Post(server+"/"+s.URL, formulario);
        Debug.Log(server+"/"+s.URL);
        yield return www.SendWebRequest();
        //Comprobacion para saber si se llego la info
        if(www.result != UnityWebRequest.Result.Success){
            respuesta = new Respuesta();
        }else{
            Debug.Log(server+"/"+s.URL);
            respuesta = JsonUtility.FromJson<Respuesta>(www.downloadHandler.text);
        }

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
