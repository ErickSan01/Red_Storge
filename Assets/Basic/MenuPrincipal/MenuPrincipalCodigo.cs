using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MenuPrincipalCodigo : MonoBehaviour
{
    UIDocument MenuPrincipalTemplate;
    Button btn_mapa;

    void OnEnable()
    {
        MenuPrincipalTemplate = GetComponent<UIDocument>();
        VisualElement root = MenuPrincipalTemplate.rootVisualElement;
        btn_mapa = root.Q<Button>("btn_mapa");

        // Agregar el evento de clic al botón "btn_jugar"
        btn_mapa.clicked += OnBtnMapaClick;
    }
    // Start is called before the first frame update
     private void OnBtnMapaClick()
    {
        // Cambiar de escena a "nivel1"
        SceneManager.LoadScene("Mapa");
        
        

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
