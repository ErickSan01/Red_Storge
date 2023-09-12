using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changelvl : MonoBehaviour
{
    public string nombreDelNivel; // Nombre del nivel al que deseas moverte
    public static string textoParaSegundaEscena;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cargar el siguiente nivel
            textoParaSegundaEscena = "Texto que quieres pasar a la segunda escena";
            SceneManager.LoadScene(nombreDelNivel);
        }
    }
}