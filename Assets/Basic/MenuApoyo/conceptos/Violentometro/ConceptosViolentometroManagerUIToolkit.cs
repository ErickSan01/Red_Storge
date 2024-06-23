using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Gestiona la funcionalidad del menú de conceptos del violentómetro en la interfaz de usuario.
/// </summary>
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
        
        // Encuentra el botón y el menú en el diseño.
        violentometro = rootElement.Q<Button>("violentometro");
        volver = violentometroMenu.Q<Button>("volver");
        violentometroMenu = violentometroMenu.Q("violentometroMenu");
        generalMenu = rootElement.Q("contenedor");

        violentometro.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la visualización del menú del violentómetro y el menú general.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y lo cambia.
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
