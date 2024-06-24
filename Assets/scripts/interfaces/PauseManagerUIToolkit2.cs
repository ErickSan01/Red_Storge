using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Models;
using JsonUtils;
/// <summary>
/// Clase que gestiona la pausa y la ayuda en la interfaz de usuario utilizando UIToolkit.
/// </summary>
public class PauseManagerUIToolkit2 : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    public Player_Script player;
    private VisualElement rootElement;
    private VisualElement pauseMenu;
    private VisualElement pergamino;
    private Button pauseButton;
    private Button ayudaButton;
    private Button continueButton;

    /// <summary>
    /// Método que se llama al inicio del juego.
    /// </summary>
    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        pauseMenu = uiDocument2.rootVisualElement;
        // Encuentra el botón y el menú en el diseño.
        pauseButton = rootElement.Q<Button>("PauseButton");
        ayudaButton = rootElement.Q<Button>("AyudaButton");
        pergamino = rootElement.Q("contenedor");
        continueButton = pauseMenu.Q<Button>("continueButton");
        pauseMenu = pauseMenu.Q("PauseMenu");

        pauseButton.clicked += TogglePause;
        continueButton.clicked += TogglePause;
        ayudaButton.clicked += ToggleAyuda;
    }

    /// <summary>
    /// Método que cambia el estado de pausa del juego.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y cámbialo.
        if (pauseMenu.resolvedStyle.display == DisplayStyle.None)
        {
            pauseMenu.style.display = DisplayStyle.Flex;
            pauseButton.style.display = DisplayStyle.None;
            pergamino.style.display = DisplayStyle.None;
            // player.walk = false;
        }
        else
        {
            pauseMenu.style.display = DisplayStyle.None;
            pauseButton.style.display = DisplayStyle.Flex;
            pergamino.style.display = DisplayStyle.Flex;
            // player.walk = true;
        }
    }

    /// <summary>
    /// Método que maneja el evento de clic en el botón de ayuda.
    /// </summary>
    public void ToggleAyuda()
    {
        if (SceneManager.GetActiveScene().name == "PergaminoMod2")
        {
            SceneManager.LoadScene("introduccion");
        }
    }
}