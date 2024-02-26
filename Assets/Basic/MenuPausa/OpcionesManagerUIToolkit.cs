using UnityEngine;
using UnityEngine.UIElements;

public class OpcionesManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    public AudioSource audioSource;
    private VisualElement rootElement;
    private VisualElement confMenu;
    private Button opcionesButton;
    private Button salirButtom;
    private SliderInt volumen;



    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        confMenu = uiDocument2.rootVisualElement;
        // Encuentra el bot�n y el men� en el dise�o.
        opcionesButton = rootElement.Q<Button>("opcionesButton");
        salirButtom = confMenu.Q<Button>("salirButtom");
        confMenu = confMenu.Q("ConfigMenu");
        volumen = confMenu.Q<SliderInt>("Volumen");

        // Configura el deslizador con valores que tengan sentido para el volumen (0 a 100 por ejemplo).
        volumen.lowValue = 1;
        volumen.highValue = 100;
        volumen.value = (int)(audioSource.volume * 100); // Asume que el volumen inicial del AudioSource est� entre 0 y 1.
        // A�ade un listener para manejar el cambio en el deslizador.
        volumen.RegisterValueChangedCallback(OnVolumeChanged);

        opcionesButton.clicked += TogglePause;
        salirButtom.clicked += TogglePause;
    }

    private void OnVolumeChanged(ChangeEvent<int> evt)
    {
        // Actualiza el volumen del AudioSource basado en la posici�n del deslizador.
        audioSource.volume = evt.newValue / 100f;
    }

    public void TogglePause()
    {
        // Comprueba el estado actual del men� y c�mbialo.
        if (confMenu.resolvedStyle.display == DisplayStyle.None)
        {
            confMenu.style.display = DisplayStyle.Flex;
            opcionesButton.style.display = DisplayStyle.None;

        }
        else
        {
            confMenu.style.display = DisplayStyle.None;
            opcionesButton.style.display = DisplayStyle.Flex;

        }
    }


}