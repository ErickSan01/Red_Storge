using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Clase que gestiona la interfaz de usuario para el menú de conceptos MEGO.
/// </summary>
public class ConceptosMEGOManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement megoMenu;
    private Button mego;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        megoMenu = uiDocument2.rootVisualElement;
        // Encuentra el botón y el menú en el diseño.
        mego = rootElement.Q<Button>("mego");
        volver = megoMenu.Q<Button>("volver");
        megoMenu = megoMenu.Q("megoMenu");
        mego.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la visibilidad del menú de MEGO y el botón correspondiente.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y lo cambia.
        if (megoMenu.resolvedStyle.display == DisplayStyle.None)
        {
            megoMenu.style.display = DisplayStyle.Flex;
            mego.style.display = DisplayStyle.None;
        }
        else
        {
            megoMenu.style.display = DisplayStyle.None;
            mego.style.display = DisplayStyle.Flex;
        }
    }
}
