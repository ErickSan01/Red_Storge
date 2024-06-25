using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Gestiona la funcionalidad del menú de conceptos del CNV en la interfaz de usuario.
/// </summary>
public class ConceptosCNVManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement cnvMenu;
    private VisualElement generalMenu;
    private Button cnv;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        cnvMenu = uiDocument2.rootVisualElement;
        
        // Encuentra el botón y el menú en el diseño.
        cnv = rootElement.Q<Button>("cnv");
        volver = cnvMenu.Q<Button>("volver");
        cnvMenu = cnvMenu.Q("cnvMenu");
        generalMenu = rootElement.Q("contenedor");

        cnv.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la visualización del menú del CNV y el menú general.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y lo cambia.
        if (cnvMenu.resolvedStyle.display == DisplayStyle.None)
        {
            cnvMenu.style.display = DisplayStyle.Flex;
            generalMenu.style.display = DisplayStyle.None;
        }
        else
        {
            cnvMenu.style.display = DisplayStyle.None;
            generalMenu.style.display = DisplayStyle.Flex;
        }
    }
}
