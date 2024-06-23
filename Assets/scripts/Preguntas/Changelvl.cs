using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que permite cambiar de nivel al colisionar con un objeto.
/// </summary>
public class Changelvl : MonoBehaviour
{
    /// <summary>
    /// El nombre del nivel al que se desea mover.
    /// </summary>
    public string nombreDelNivel;

    /// <summary>
    /// El texto dinámico asociado al cambio de nivel.
    /// </summary>
    public string textoDinamico;

    /// <summary>
    /// El texto para la segunda escena.
    /// </summary>
    public static string textoParaSegundaEscena;

    /// <summary>
    /// Método que se ejecuta cuando se produce una colisión 2D.
    /// </summary>
    /// <param name="collision">La información de la colisión.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cargar el siguiente nivel
            textoParaSegundaEscena = textoDinamico;
            SceneManager.LoadScene(nombreDelNivel);
        }
    }
}