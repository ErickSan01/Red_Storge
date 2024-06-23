using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador de la cámara que sigue al personaje en el juego.
/// </summary>
public class CameraController : MonoBehaviour
{
    public Transform personaje;

    private float tamañoCamara;
    private float alturaPantalla;

    // Start is called before the first frame update
    void Start()
    {
        tamañoCamara = Camera.main.orthographicSize;
        alturaPantalla = tamañoCamara * 2;
    }

    // Update is called once per frame
    void Update()
    {
        CalcularPosicionCamara();
    }

    /// <summary>
    /// Calcula la posición de la cámara en función de la posición del personaje.
    /// </summary>
    void CalcularPosicionCamara()
    {
        int pantallaPersonaje = (int)(personaje.position.y / alturaPantalla);
        float alturaCamara = (pantallaPersonaje * alturaPantalla) + tamañoCamara;

        transform.position = new Vector3(transform.position.x, alturaCamara, transform.position.z);
    }
}