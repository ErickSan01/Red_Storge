using UnityEngine;
using UnityEngine.UIElements;
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
        // Encuentra el bot�n y el men� en el dise�o.
        nnaj = rootElement.Q<Button>("nnaj");
        volver = nnajMenu.Q<Button>("volver");
        nnajMenu = nnajMenu.Q("nnajMenu");
        nnaj.clicked += TogglePause;
        volver.clicked += TogglePause;
    }

    public void TogglePause()
    {
        // Comprueba el estado actual del men� y c�mbialo.
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
