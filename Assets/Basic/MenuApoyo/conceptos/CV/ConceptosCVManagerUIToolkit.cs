using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Clase que gestiona el menú de conceptos de CV en el UI Toolkit.
/// </summary>
public class ConceptosCVManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement cvMenu;
    private Button cv;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        cvMenu = uiDocument2.rootVisualElement;
        // Encuentra el botón y el menú en el diseño.
        cv = rootElement.Q<Button>("cv");
        volver = cvMenu.Q<Button>("volver");
        cvMenu = cvMenu.Q("cvMenu");
        cv.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    /// <summary>
    /// Alterna la visibilidad del menú de conceptos de CV.
    /// </summary>
    public void TogglePause()
    {
        // Comprueba el estado actual del menú y cambialo.
        if (cvMenu.resolvedStyle.display == DisplayStyle.None)
        {
            cvMenu.style.display = DisplayStyle.Flex;
            cv.style.display = DisplayStyle.None;
        }
        else
        {
            cvMenu.style.display = DisplayStyle.None;
            cv.style.display = DisplayStyle.Flex;
        }
    }
}
