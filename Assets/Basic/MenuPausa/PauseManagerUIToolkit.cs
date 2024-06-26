using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Clase que gestiona la pausa del juego utilizando el UIToolkit de Unity.
/// </summary>
public class PauseManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    public Player_Script player;
    private VisualElement rootElement;
    private VisualElement pauseMenu;
    private Button pauseButton;
    private Button continueButton;

    /// <summary>
    /// Método que se llama al iniciar el objeto.
    /// </summary>
    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        pauseMenu = uiDocument2.rootVisualElement;
        // Encuentra el botón y el menú en el diseño.
        pauseButton = rootElement.Q<Button>("PauseButton");
        continueButton = pauseMenu.Q<Button>("continueButton");
        pauseMenu = pauseMenu.Q("PauseMenu");

        pauseButton.clicked += TogglePause;
        continueButton.clicked += TogglePause;
    }

    /// <summary>
    /// Método que alterna entre pausar y reanudar el juego.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y cámbialo.
        if (pauseMenu.resolvedStyle.display == DisplayStyle.None)
        {
            pauseMenu.style.display = DisplayStyle.Flex;
            pauseButton.style.display = DisplayStyle.None;
            // player.walk = false;
        }
        else
        {
            pauseMenu.style.display = DisplayStyle.None;
            pauseButton.style.display = DisplayStyle.Flex;
            // player.walk = true;
        }
    }
}