using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Clase que gestiona la interfaz de usuario para los conceptos de PSE.
/// </summary>
public class ConceptosPSEManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement pseMenu;
    private Button pse;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        pseMenu = uiDocument2.rootVisualElement;
        // Encuentra el botón y el menú en el diseño.
        pse = rootElement.Q<Button>("pse");
        volver = pseMenu.Q<Button>("volver");
        pseMenu = pseMenu.Q("pseMenu");
        pse.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la pausa del menú.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y lo cambia.
        if (pseMenu.resolvedStyle.display == DisplayStyle.None)
        {
            pseMenu.style.display = DisplayStyle.Flex;
            pse.style.display = DisplayStyle.None;
        }
        else
        {
            pseMenu.style.display = DisplayStyle.None;
            pse.style.display = DisplayStyle.Flex;
        }
    }
}
