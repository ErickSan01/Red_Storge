using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Clase que gestiona la interfaz de usuario para el menú de conceptos de NNAJ.
/// </summary>
public class ConceptosNNAJManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement nnajMenu;
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
        nnaj.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la visualización del menú de NNAJ.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y cambialo.
        if (nnajMenu.resolvedStyle.display == DisplayStyle.None)
        {
            nnajMenu.style.display = DisplayStyle.Flex;
            nnaj.style.display = DisplayStyle.None;
        }
        else
        {
            nnajMenu.style.display = DisplayStyle.None;
            nnaj.style.display = DisplayStyle.Flex;
        }
    }
}
