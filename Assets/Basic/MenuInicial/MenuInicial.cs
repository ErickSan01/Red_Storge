using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    UIDocument MenuInicialTemplate;
    Button btn_jugar;

    void OnEnable()
    {
        MenuInicialTemplate = GetComponent<UIDocument>();
        VisualElement root = MenuInicialTemplate.rootVisualElement;
        btn_jugar = root.Q<Button>("btn_jugar");
        btn_jugar.clicked += OnBtnJugarClick;
    }

    private void OnBtnJugarClick()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    void Start()
    {
        
    }
}