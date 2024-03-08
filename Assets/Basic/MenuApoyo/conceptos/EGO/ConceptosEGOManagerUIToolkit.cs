using UnityEngine;
using UnityEngine.UIElements;
public class ConceptosEGOManagerUIToolkit : MonoBehaviour
{
    public UIDocument uiDocument; // Referencia al UIDocument en la escena.
    public UIDocument uiDocument2;
    private VisualElement rootElement;
    private VisualElement egoMenu;
    private Button ego;
    private Button volver;

    private void Start()
    {
        rootElement = uiDocument.rootVisualElement;
        egoMenu = uiDocument2.rootVisualElement;
        // Encuentra el bot�n y el men� en el dise�o.
        ego = rootElement.Q<Button>("ego");
        volver = egoMenu.Q<Button>("volver");
        egoMenu = egoMenu.Q("egoMenu");
        ego.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    public void TogglePause()
    {
        // Comprueba el estado actual del men� y c�mbialo.
        if (egoMenu.resolvedStyle.display == DisplayStyle.None)
        {
            egoMenu.style.display = DisplayStyle.Flex;
            ego.style.display = DisplayStyle.None;

        }
        else
        {
            egoMenu.style.display = DisplayStyle.None;
            ego.style.display = DisplayStyle.Flex;

        }
    }
}
