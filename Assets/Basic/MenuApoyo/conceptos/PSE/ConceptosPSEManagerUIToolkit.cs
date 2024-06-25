using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Clase que gestiona la interfaz de usuario para el menú de conceptos de PSE.
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
    /// Alterna la visualización del menú de PSE.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y cambialo.
        if (pseMenu.resolvedStyle.display == DisplayStyle.None)
        {
            pseMenu.style.display = DisplayStyle.Flex;
        }
        else
        {
            pseMenu.style.display = DisplayStyle.None;
        }
    }
}
