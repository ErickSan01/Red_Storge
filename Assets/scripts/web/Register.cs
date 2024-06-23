using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// Clase que maneja el registro de usuarios.
/// </summary>
public class Register : MonoBehaviour
{
    public Servidor servidor;

    public InputField inpUsername;
    public InputField inpFullname;
    public InputField inpEmail;
    public InputField inpPass;
    public GameObject imLoading;

    /// <summary>
    /// Método que se llama al hacer clic en el botón de registro de usuario.
    /// </summary>
    public void RegistrarUsuario()
    {
        StartCoroutine(Registrar());
    }

    /// <summary>
    /// Corrutina que realiza el registro del usuario.
    /// </summary>
    IEnumerator Registrar()
    {   
        imLoading.SetActive(true);
        string[] datos = new string[5];
        datos[0] = inpUsername.text;
        datos[1] = inpFullname.text;
        datos[2] = inpEmail.text;
        datos[3] = inpPass.text;
        datos[4] = "c";
        Debug.Log(datos[0]);
        Debug.Log(datos[1]);
        Debug.Log(datos[2]);
        Debug.Log(datos[3]);

        StartCoroutine(servidor.consumirServicio("reg_usuario", datos));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        imLoading.SetActive(false);
    }
}
