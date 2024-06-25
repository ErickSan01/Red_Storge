using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Gestiona la funcionalidad del menú de conceptos del CVR en la interfaz de usuario.
/// </summary>
public class ConceptosCVRManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement cvrMenu;
    private VisualElement generalMenu;
    private Button cvr;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        cvrMenu = uiDocument2.rootVisualElement;
        
        // Encuentra el botón y el menú en el diseño.
        cvr = rootElement.Q<Button>("cvr");
        volver = cvrMenu.Q<Button>("volver");
        cvrMenu = cvrMenu.Q("cvrMenu");
        generalMenu = rootElement.Q("contenedor");

        cvr.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la visualización del menú del CVR y el menú general.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y lo cambia.
        if (cvrMenu.resolvedStyle.display == DisplayStyle.None)
        {
            cvrMenu.style.display = DisplayStyle.Flex;
            generalMenu.style.display = DisplayStyle.None;
        }
        else
        {
            cvrMenu.style.display = DisplayStyle.None;
            generalMenu.style.display = DisplayStyle.Flex;
        }
    }
}
