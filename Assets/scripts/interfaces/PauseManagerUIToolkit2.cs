using UnityEngine;
using UnityEngine.UIElements;

public class PauseManagerUIToolkit2 : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    public Player_Script player;
    private VisualElement rootElement;
    private VisualElement pauseMenu;
    private VisualElement pergamino;
    private Button pauseButton;
    private Button continueButton;


    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        pauseMenu = uiDocument2.rootVisualElement;
        // Encuentra el botón y el menú en el diseño.
        pauseButton = rootElement.Q<Button>("PauseButton");
        pergamino = rootElement.Q("contenedor");
        continueButton = pauseMenu.Q<Button>("continueButton");
        pauseMenu = pauseMenu.Q("PauseMenu");

        pauseButton.clicked += TogglePause;
        continueButton.clicked += TogglePause;
    }

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
}