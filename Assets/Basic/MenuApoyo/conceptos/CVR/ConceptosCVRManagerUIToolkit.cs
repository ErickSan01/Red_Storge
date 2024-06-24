using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Gestiona el menú de conceptos CVR en la interfaz de usuario.
/// </summary>
public class ConceptosCVRManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement cvrMenu;
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
        cvr.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la visibilidad del menú de pausa.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y cambialo.
        if (cvrMenu.resolvedStyle.display == DisplayStyle.None)
        {
            cvrMenu.style.display = DisplayStyle.Flex;
            cvr.style.display = DisplayStyle.None;
        }
        else
        {
            cvrMenu.style.display = DisplayStyle.None;
            cvr.style.display = DisplayStyle.Flex;
        }
    }
}
