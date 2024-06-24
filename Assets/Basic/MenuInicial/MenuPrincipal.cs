using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que representa el menú principal del juego.
/// </summary>
public class MenuPrincipal : MonoBehaviour
{
    UIDocument MenuPrincipalTemplate;
    Button btn_jugar;

    void OnEnable()
    {
        MenuPrincipalTemplate = GetComponent<UIDocument>();
        VisualElement root = MenuPrincipalTemplate.rootVisualElement;
        btn_jugar = root.Q<Button>("Jugar");
        btn_jugar.clicked += OnBtnJugarClick;
    }

    /// <summary>
    /// Método que se ejecutará cuando se haga clic en el botón "btn_jugar".
    /// Cambia a la escena "MenuPrincipal".
    /// </summary>
    private void OnBtnJugarClick()
    {
        SceneManager.LoadScene("MenuPrincipal");
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
