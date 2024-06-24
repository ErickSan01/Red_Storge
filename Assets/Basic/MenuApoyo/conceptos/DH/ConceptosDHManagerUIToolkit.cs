using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Gestiona el menú de conceptos de derechos humanos en una interfaz de usuario.
/// </summary>
public class ConceptosDHManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement dhMenu;
    private Button dh;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        dhMenu = uiDocument2.rootVisualElement;
        // Encuentra el botón y el menú en el diseño.
        dh = rootElement.Q<Button>("dh");
        volver = dhMenu.Q<Button>("volver");
        dhMenu = dhMenu.Q("dhMenu");
        dh.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la visibilidad del menú de conceptos de derechos humanos.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y cambialo.
        if (dhMenu.resolvedStyle.display == DisplayStyle.None)
        {
            dhMenu.style.display = DisplayStyle.Flex;
            dh.style.display = DisplayStyle.None;
        }
        else
        {
            dhMenu.style.display = DisplayStyle.None;
            dh.style.display = DisplayStyle.Flex;
        }
    }
}
