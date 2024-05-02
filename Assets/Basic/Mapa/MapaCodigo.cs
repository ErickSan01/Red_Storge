using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using JsonUtils;
public class MapaCodigo : MonoBehaviour
{
    UIDocument MapaTemplate;
    Button btn_modulo2;
    Button btn_modulo4;
    Button btn_jugar;

    // Start is called before the first frame update
    void OnEnable()
    {
        MapaTemplate = GetComponent<UIDocument>();
        VisualElement root = MapaTemplate.rootVisualElement;
        btn_modulo2 = root.Q<Button>("btn_modulo2");
        btn_modulo4 = root.Q<Button>("btn_modulo4");

        // Agregar el evento de clic al botón "btn_jugar"
        btn_modulo2.clicked += OnBtnModulo2Click;

        btn_modulo4.clicked += OnBtnModulo4Click;


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
        ProgresoGeneralJson.ActualizarProgreso(2);
        // Cambiar de escena a "nivel1"
        SceneManager.LoadScene("Modulo2Nivel");
    }

        private void OnBtnModulo4Click()
    {
        ProgresoGeneralJson.ActualizarProgreso(4);
        // Cambiar de escena a "nivel1"
        SceneManager.LoadScene("Modulo4Nivel");
    }


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
