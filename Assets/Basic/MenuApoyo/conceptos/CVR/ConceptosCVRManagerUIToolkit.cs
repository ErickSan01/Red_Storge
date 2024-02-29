using UnityEngine;
using UnityEngine.UIElements;
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
        // Encuentra el bot�n y el men� en el dise�o.
        cvr = rootElement.Q<Button>("cvr");
        volver = cvrMenu.Q<Button>("volver");
        cvrMenu = cvrMenu.Q("cvrMenu");
        cvr.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    public void TogglePause()
    {
        // Comprueba el estado actual del men� y c�mbialo.
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
