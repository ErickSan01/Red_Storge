using UnityEngine;
using UnityEngine.UIElements;
public class ConceptosViolentometroManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement violentometroMenu;
    private VisualElement generalMenu;
    private Button violentometro;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        violentometroMenu = uiDocument2.rootVisualElement;
        
        // Encuentra el bot�n y el men� en el dise�o.
        violentometro = rootElement.Q<Button>("violentometro");
        volver = violentometroMenu.Q<Button>("volver");
        violentometroMenu = violentometroMenu.Q("violentometroMenu");
        generalMenu = rootElement.Q("contenedor");

        violentometro.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    public void TogglePause()
    {
        // Comprueba el estado actual del men� y c�mbialo.
        if (violentometroMenu.resolvedStyle.display == DisplayStyle.None)
        {
            violentometroMenu.style.display = DisplayStyle.Flex;
            generalMenu.style.display = DisplayStyle.None;

        }
        else
        {
            violentometroMenu.style.display = DisplayStyle.None;
            generalMenu.style.display = DisplayStyle.Flex;

        }
    }
}
