using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


/// <summary>
/// Clase que maneja el inicio de sesión en el juego.
/// </summary>
public class Login : MonoBehaviour
{
    public Servidor servidor;

    public InputField inpUsuario;
    public InputField inpPass;
    public GameObject imLoading;

    /// <summary>
    /// Método que se llama al hacer clic en el botón de iniciar sesión.
    /// </summary>
    public void IniciarSesion()
    {
        StartCoroutine(Iniciar());
    }

    /// <summary>
    /// Corrutina que realiza el inicio de sesión.
    /// </summary>
    IEnumerator Iniciar()
    {
        imLoading.SetActive(true);

        WWWForm form = new WWWForm();
        form.AddField("nombre_usuario", inpUsuario.text);
        form.AddField("password", inpPass.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/redstorge/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                LoadScene("colision");
            }
        }
        
        imLoading.SetActive(false);
    }

    /// <summary>
    /// Método que carga una escena específica.
    /// </summary>
    /// <param name="sceneName">Nombre de la escena a cargar.</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}

