using UnityEngine;
using UnityEngine.UIElements;
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
        // Encuentra el bot�n y el men� en el dise�o.
        dh = rootElement.Q<Button>("dh");
        volver = dhMenu.Q<Button>("volver");
        dhMenu = dhMenu.Q("dhMenu");
        dh.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    public void TogglePause()
    {
        // Comprueba el estado actual del men� y c�mbialo.
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
