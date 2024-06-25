using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
/// <summary>
/// Gestiona las opciones del menú de pausa utilizando el UIToolkit de Unity.
/// </summary>
public class OpcionesManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    public UIDocument uiDocument3;
    public AudioSource audioSource;
    private VisualElement rootElement;
    private VisualElement confMenu;
    private VisualElement apoMenu;
    private Button opcionesButton;
    private Button salirButtom;
    private Button menuPrincipalButton;
    private Button jugarButtom;
    private Button apoyoButton;
    private SliderInt volumen;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        confMenu = uiDocument2.rootVisualElement;
        apoMenu = uiDocument3.rootVisualElement;
        // Encuentra el botón y el menú en el diseño.
        opcionesButton = rootElement.Q<Button>("opcionesButton");
        salirButtom = confMenu.Q<Button>("salirButtom");
        menuPrincipalButton = rootElement.Q<Button>("menuPrincipalButton");
        apoyoButton = rootElement.Q<Button>("apoyoButton");        
        jugarButtom = apoMenu.Q<Button>("Jugar");

        confMenu = confMenu.Q("ConfigMenu");
        volumen = confMenu.Q<SliderInt>("Volumen");
        apoMenu = apoMenu.Q("contenedor");

        // Configura el deslizador con valores que tengan sentido para el volumen (0 a 100 por ejemplo).
        volumen.lowValue = 1;
        volumen.highValue = 100;
        volumen.value = (int)(audioSource.volume * 100); // Asume que el volumen inicial del AudioSource está entre 0 y 1.
        // Añade un listener para manejar el cambio en el deslizador.
        volumen.RegisterValueChangedCallback(OnVolumeChanged);

        opcionesButton.clicked += TogglePause;
        salirButtom.clicked += TogglePause;
        menuPrincipalButton.clicked += SalirScene;
        apoyoButton.clicked += TogglePause2;
        jugarButtom.clicked += TogglePause2;
    }

    private void OnVolumeChanged(ChangeEvent<int> evt)
    {
        // Actualiza el volumen del AudioSource basado en la posición del deslizador.
        audioSource.volume = evt.newValue / 100f;
    }

    /// <summary>
    /// Alterna la visualización del menú de opciones y el menú principal.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y cámbialo.
        if (confMenu.resolvedStyle.display == DisplayStyle.None)
        {
            confMenu.style.display = DisplayStyle.Flex;
            rootElement.style.display = DisplayStyle.None;
        }
        else
        {
            confMenu.style.display = DisplayStyle.None;
            rootElement.style.display = DisplayStyle.Flex;
        }
    }

    /// <summary>
    /// Alterna la visualización del menú de apoyo y el menú principal.
    /// </summary>
    public void TogglePause2()
    {
        // Comprueba el estado actual del menú y cámbialo.
        if (apoMenu.resolvedStyle.display == DisplayStyle.None)
        {
            apoMenu.style.display = DisplayStyle.Flex;
            rootElement.style.display = DisplayStyle.None;
        }
        else
        {
            apoMenu.style.display = DisplayStyle.None;
            rootElement.style.display = DisplayStyle.Flex;
        }
    }

    public void SalirScene()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}