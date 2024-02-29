using UnityEngine;
using UnityEngine.UIElements;
public class ConceptosCEGOManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement cegoMenu;
    private Button cego;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        cegoMenu = uiDocument2.rootVisualElement;
        // Encuentra el bot�n y el men� en el dise�o.
        cego = rootElement.Q<Button>("cego");
        volver = cegoMenu.Q<Button>("volver");
        cegoMenu = cegoMenu.Q("cegoMenu");
        cego.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    public void TogglePause()
    {
        // Comprueba el estado actual del men� y c�mbialo.
        if (cegoMenu.resolvedStyle.display == DisplayStyle.None)
        {
            cegoMenu.style.display = DisplayStyle.Flex;
            cego.style.display = DisplayStyle.None;

        }
        else
        {
            cegoMenu.style.display = DisplayStyle.None;
            cego.style.display = DisplayStyle.Flex;

        }
    }
}
