using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que representa el código del menú principal.
/// </summary>
public class ApoyoScene : MonoBehaviour
{
    UIDocument Menu_Apoyo;
    Button volver;

    void OnEnable()
    {
        Menu_Apoyo = GetComponent<UIDocument>();
        VisualElement apoMenu = Menu_Apoyo.rootVisualElement;
        apoMenu = apoMenu.Q("contenedor");
        volver = apoMenu.Q<Button>("Jugar");
        // Comprueba el estado actual del menú y cámbialo.
        if (apoMenu.resolvedStyle.display == DisplayStyle.None)
        {
            apoMenu.style.display = DisplayStyle.Flex;
        }
        else
        {
            apoMenu.style.display = DisplayStyle.None;
        }
        volver.clicked += volverClick;
    }
    // Start is called before the first frame update
     private void volverClick()
    {

        // Cambiar de escena a "mapa"
        Menu_Apoyo = GetComponent<UIDocument>();
        VisualElement apoMenu = Menu_Apoyo.rootVisualElement;
        apoMenu = apoMenu.Q("contenedor");        
        apoMenu.style.display = DisplayStyle.None;
        SceneManager.LoadScene("MenuPrincipal");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
