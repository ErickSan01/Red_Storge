using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MapaCodigo : MonoBehaviour
{
    UIDocument MapaTemplate;
    Button btn_modulo2;
    Button btn_jugar;

    // Start is called before the first frame update
    void OnEnable()
    {
        MapaTemplate = GetComponent<UIDocument>();
        VisualElement root = MapaTemplate.rootVisualElement;
        btn_modulo2 = root.Q<Button>("btn_modulo2");

        // Agregar el evento de clic al botón "btn_jugar"
        btn_modulo2.clicked += OnBtnModulo2Click;


        btn_jugar = root.Q<Button>("Jugar");

        // Agregar el evento de clic al botón "btn_jugar"
        btn_jugar.clicked += OnBtnJugarClick;
    }
    private void OnBtnJugarClick()
    {
        // Cambiar de escena a "nivel1"
        SceneManager.LoadScene("MenuPrincipal");
        
    }
    private void OnBtnModulo2Click()
    {
        // Cambiar de escena a "nivel1"
        SceneManager.LoadScene("Modulo2Nivel");
    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
