using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MenuPrincipalCodigo : MonoBehaviour
{
    UIDocument MenuPrincipalTemplate;
    Button btn_mapa;
    Button btn_material;
	Button btn_medallas;

    void OnEnable()
    {
        MenuPrincipalTemplate = GetComponent<UIDocument>();
        VisualElement root = MenuPrincipalTemplate.rootVisualElement;
        btn_material = root.Q<Button>("btn_material");
        btn_mapa = root.Q<Button>("btn_mapa");
		btn_medallas = root.Q<Button> ("btn_medallas");

        // Agregar el evento de clic al botón "btn_jugar"
        btn_mapa.clicked += OnBtnMapaClick;
        btn_material.clicked += OnBtnMaterialClick;
		btn_medallas.clicked += OnBtnMedallasClick;
    }
    // Start is called before the first frame update
     private void OnBtnMapaClick()
    {
        // Cambiar de escena a "nivel1"
        SceneManager.LoadScene("Mapa");
    }

    private void OnBtnMaterialClick(){
        SceneManager.LoadScene("MenuApoyo");
    }

	private void OnBtnMedallasClick(){
		SceneManager.LoadScene ("Menu Medallas");
	}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
