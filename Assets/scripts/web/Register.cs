using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Register : MonoBehaviour
{
    public Servidor servidor;

    public InputField inpUsername;
    public InputField inpFullname;
    public InputField inpEmail;
    public InputField inpPass;
    public GameObject imLoading;

    public void RegistrarUsuario()
    {
        StartCoroutine(Registrar());
    }

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
