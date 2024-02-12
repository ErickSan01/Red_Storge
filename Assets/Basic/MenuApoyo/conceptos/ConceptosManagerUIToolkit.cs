using UnityEngine;
using UnityEngine.UIElements;
public class ConceptosManagerUIToolkit : MonoBehaviour
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
        // Encuentra el bot�n y el men� en el dise�o.
        cnv = rootElement.Q<Button>("cnv");
        volver = cnvMenu.Q<Button>("volver");

        cnv.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    public void TogglePause()
    {
        // Comprueba el estado actual del men� y c�mbialo.
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
