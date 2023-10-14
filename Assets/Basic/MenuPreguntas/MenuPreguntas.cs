using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MenuPreguntas : MonoBehaviour
{
    UIDocument MenuPregunta;

    Button btn_nivel1;

    public static string textoParaSegundaEscena;

    void OnEnable(){
        MenuPregunta = GetComponent<UIDocument>();
        VisualElement root = MenuPregunta.rootVisualElement;
        btn_nivel1 = root.Q<Button>("btn_nivel1");
        btn_nivel1.clicked += OnBtnNivel1Click;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBtnNivel1Click()
    {
        textoParaSegundaEscena = "Texto que quieres pasar a la segunda escena";
        SceneManager.LoadScene("ToolkitPrueba");
    }
}
