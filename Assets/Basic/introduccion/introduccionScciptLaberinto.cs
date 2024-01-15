using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class introduccionScciptLaberinto : MonoBehaviour
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

    // Método que se ejecutará cuando se haga clic en el botón "btn_jugar"
    private void OnBtnJugarClick()
    {
        // Cambiar de escena a "nivel1"
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
