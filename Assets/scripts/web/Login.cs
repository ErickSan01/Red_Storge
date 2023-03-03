using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class Login : MonoBehaviour
{
    public Servidor servidor;

    public InputField inpUsuario;
    public InputField inpPass;
    public GameObject imLoading;

    public void IniciarSesion()
    {
        StartCoroutine(Iniciar());
    }

    IEnumerator Iniciar()
    {
        imLoading.SetActive(true);
        //string[] datos = new string[2];
        //datos[0] = inpUsuario.text;
        //datos[1] = inpPass.text;
        //StartCoroutine(servidor.consumirServicio("login",datos)); 
        //yield return new WaitForSeconds(0.5f);     
        //yield return new WaitUntil(()=> !servidor.ocupado);


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

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}

