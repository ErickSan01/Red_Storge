using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Gestiona la funcionalidad del menú de conceptos del NNAJ en la interfaz de usuario.
/// </summary>
public class ConceptosNNAJManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement nnajMenu;
    private VisualElement generalMenu;
    private Button nnaj;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        nnajMenu = uiDocument2.rootVisualElement;
        
        // Encuentra el botón y el menú en el diseño.
        nnaj = rootElement.Q<Button>("nnaj");
        volver = nnajMenu.Q<Button>("volver");
        nnajMenu = nnajMenu.Q("nnajMenu");
        generalMenu = rootElement.Q("contenedor");

        nnaj.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la visualización del menú del NNAJ y el menú general.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y lo cambia.
        if (nnajMenu.resolvedStyle.display == DisplayStyle.None)
        {
            nnajMenu.style.display = DisplayStyle.Flex;
            generalMenu.style.display = DisplayStyle.None;
        }
        else
        {
            nnajMenu.style.display = DisplayStyle.None;
            generalMenu.style.display = DisplayStyle.Flex;
        }
    }
}
