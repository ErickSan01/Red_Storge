using UnityEngine;
using UnityEngine.UIElements;
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
        // Encuentra el bot�n y el men� en el dise�o.
        cv = rootElement.Q<Button>("cv");
        volver = cvMenu.Q<Button>("volver");
        cvMenu = cvMenu.Q("cvMenu");
        cv.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    public void TogglePause()
    {
        // Comprueba el estado actual del men� y c�mbialo.
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
