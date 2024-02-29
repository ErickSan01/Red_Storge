using UnityEngine;
using UnityEngine.UIElements;
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
        // Encuentra el bot�n y el men� en el dise�o.
        mego = rootElement.Q<Button>("mego");
        volver = megoMenu.Q<Button>("volver");
        megoMenu = megoMenu.Q("megoMenu");
        mego.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    public void TogglePause()
    {
        // Comprueba el estado actual del men� y c�mbialo.
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
