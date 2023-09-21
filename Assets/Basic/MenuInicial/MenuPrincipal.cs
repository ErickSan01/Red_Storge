using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    UIDocument MenuPrincipalTemplate;
    Button btn_jugar;

    void OnEnable()
    {
        MenuPrincipalTemplate = GetComponent<UIDocument>();
        VisualElement root = MenuPrincipalTemplate.rootVisualElement;
        btn_jugar = root.Q<Button>("Jugar");

        // Agregar el evento de clic al botón "btn_jugar"
        btn_jugar.clicked += OnBtnJugarClick;
    }

    // Método que se ejecutará cuando se haga clic en el botón "btn_jugar"
    private void OnBtnJugarClick()
    {
        // Cambiar de escena a "nivel1"
        SceneManager.LoadScene("MenuPrincipal");
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
