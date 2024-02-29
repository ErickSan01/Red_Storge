using UnityEngine;
using UnityEngine.UIElements;
public class ConceptosPSEManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement pseMenu;
    private Button pse;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        pseMenu = uiDocument2.rootVisualElement;
        // Encuentra el bot�n y el men� en el dise�o.
        pse = rootElement.Q<Button>("pse");
        volver = pseMenu.Q<Button>("volver");
        pseMenu = pseMenu.Q("pseMenu");
        pse.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    public void TogglePause()
    {
        // Comprueba el estado actual del men� y c�mbialo.
        if (pseMenu.resolvedStyle.display == DisplayStyle.None)
        {
            pseMenu.style.display = DisplayStyle.Flex;
            pse.style.display = DisplayStyle.None;

        }
        else
        {
            pseMenu.style.display = DisplayStyle.None;
            pse.style.display = DisplayStyle.Flex;

        }
    }
}
