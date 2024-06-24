using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Clase que gestiona el menú de conceptos CEGO en la interfaz de usuario.
/// </summary>
public class ConceptosCEGOManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement cegoMenu;
    private Button cego;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        cegoMenu = uiDocument2.rootVisualElement;
        // Encuentra el botón y el menú en el diseño.
        cego = rootElement.Q<Button>("cego");
        volver = cegoMenu.Q<Button>("volver");
        cegoMenu = cegoMenu.Q("cegoMenu");
        cego.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la visibilidad del menú de conceptos CEGO.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y lo cambia.
        if (cegoMenu.resolvedStyle.display == DisplayStyle.None)
        {
            cegoMenu.style.display = DisplayStyle.Flex;
            cego.style.display = DisplayStyle.None;
        }
        else
        {
            cegoMenu.style.display = DisplayStyle.None;
            cego.style.display = DisplayStyle.Flex;
        }
    }
}
