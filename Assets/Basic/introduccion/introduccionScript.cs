using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que representa el script de introducción.
/// </summary>
public class introduccionScript : MonoBehaviour
{
    UIDocument Introduccion;
    Button btn_jugar;

    void OnEnable()
    {
        Introduccion = GetComponent<UIDocument>();
        VisualElement root = Introduccion.rootVisualElement;
        btn_jugar = root.Q<Button>("Comenzar");

        // Agregar el evento de clic al botón "btn_jugar"
        btn_jugar.clicked += OnBtnJugarClick;
    }

    /// <summary>
    /// Método que se ejecutará cuando se haga clic en el botón "btn_jugar".
    /// Cambia de escena a "nivel1".
    /// </summary>
    private void OnBtnJugarClick()
    {
        SceneManager.LoadScene("PergaminoMod2");
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
