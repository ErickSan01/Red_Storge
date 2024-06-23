using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Clase que gestiona el menú de conceptos EGO en la interfaz de usuario.
/// </summary>
public class ConceptosEGOManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement egoMenu;
    private Button ego;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        egoMenu = uiDocument2.rootVisualElement;
        // Encuentra el botón y el menú en el diseño.
        ego = rootElement.Q<Button>("ego");
        volver = egoMenu.Q<Button>("volver");
        egoMenu = egoMenu.Q("egoMenu");
        ego.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la visibilidad del menú de EGO y el botón de EGO.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y cambialo.
        if (egoMenu.resolvedStyle.display == DisplayStyle.None)
        {
            egoMenu.style.display = DisplayStyle.Flex;
            ego.style.display = DisplayStyle.None;
        }
        else
        {
            egoMenu.style.display = DisplayStyle.None;
            ego.style.display = DisplayStyle.Flex;
        }
    }
}
