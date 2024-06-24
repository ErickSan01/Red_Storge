using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que representa el script de introducción y recuperación del laberinto.
/// </summary>
public class introduccionScciptRecuperacion : MonoBehaviour
{
    UIDocument Introduccion_laberinto;
    Button btn_jugar;

    void OnEnable()
    {
        Introduccion_laberinto = GetComponent<UIDocument>();
        VisualElement root = Introduccion_laberinto.rootVisualElement;
        btn_jugar = root.Q<Button>("Comenzar");

        // Agregar el evento de clic al botón "btn_jugar"
        btn_jugar.clicked += OnBtnJugarClick;
    }

    /// <summary>
    /// Método que se ejecutará cuando se haga clic en el botón "btn_jugar".
    /// Cambia a la escena "Laberinto".
    /// </summary>
    private void OnBtnJugarClick()
    {
        SceneManager.LoadScene("Laberinto");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
