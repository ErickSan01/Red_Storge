using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Gestiona la interfaz de usuario para el menú de conceptos CNV.
/// </summary>
public class ConceptosCNVManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement cnvMenu;
    private Button cnv;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        cnvMenu = uiDocument2.rootVisualElement;
        // Encuentra el botón y el menú en el diseño.
        cnv = rootElement.Q<Button>("cnv");
        volver = cnvMenu.Q<Button>("volver");
        cnvMenu = cnvMenu.Q("CNVMenu");
        cnv.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la visualización del menú de pausa.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y cambialo.
        if (cnvMenu.resolvedStyle.display == DisplayStyle.None)
        {
            cnvMenu.style.display = DisplayStyle.Flex;
            cnv.style.display = DisplayStyle.None;
        }
        else
        {
            cnvMenu.style.display = DisplayStyle.None;
            cnv.style.display = DisplayStyle.Flex;
        }
    }
}
