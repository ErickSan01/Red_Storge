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
    Button btn_modulo3;
    Button btn_modulo4;
    Button btn_modulo5;
    Button btn_jugar;

    // Start is called before the first frame update
    void OnEnable()
    {
        MapaTemplate = GetComponent<UIDocument>();
        VisualElement root = MapaTemplate.rootVisualElement;
        btn_modulo2 = root.Q<Button>("btn_modulo2");
        btn_modulo3 = root.Q<Button>("btn_modulo3");
        btn_modulo4 = root.Q<Button>("btn_modulo4");
        btn_modulo5 = root.Q<Button>("btn_modulo5");

        // Agregar el evento de clic al botón "btn_modulo2"
        btn_modulo2.clicked += OnBtnModulo2Click;
        // Agregar el evento de clic al botón "btn_modulo3"
        btn_modulo3.clicked += OnBtnModulo3Click;
        // Agregar el evento de clic al botón "btn_modulo4"
        btn_modulo4.clicked += OnBtnModulo4Click;
        // Agregar el evento de clic al botón "btn_modulo5"
        btn_modulo5.clicked += OnBtnModulo5Click;
    }

    private void OnBtnModulo2Click()
    {
        ProgresoGeneralJson.ActualizarProgreso(2);
        // Cambiar de escena a "nivel1"
        SceneManager.LoadScene("Modulo2Nivel");
    }

    private void OnBtnModulo3Click()
    {
        ProgresoGeneralJson.ActualizarProgreso(3);
        // Cambiar de escena a "nivel3"
        SceneManager.LoadScene("Modulo3Nivel");
    }

        private void OnBtnModulo4Click()
    {
        ProgresoGeneralJson.ActualizarProgreso(4);
        // Cambiar de escena a "nivel1"
        SceneManager.LoadScene("Modulo4Nivel");
    }

    private void OnBtnModulo5Click()
    {
        ProgresoGeneralJson.ActualizarProgreso(5);
        // Cambiar de escena a "nivel5"
        SceneManager.LoadScene("Modulo5Nivel");
    }


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}