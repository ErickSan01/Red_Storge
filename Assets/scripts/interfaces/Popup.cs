using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    //Instancias de los botones:
    [SerializeField] Button _button1;
    [SerializeField] Button _button2;
    [SerializeField] Button _button3;
    [SerializeField] Button _buttonCerrar;
    [SerializeField] Text _buttonText1;
    [SerializeField] Text _buttonText2;
    [SerializeField] Text _buttonText3;
    [SerializeField] Text _popupText;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Init(Transform canvas, string popupMessage, string btn1text, string btn2text, string btn3text, System.Action action1){
        //asignar textos a los botones
        _popupText.text = popupMessage;
        _buttonText1.text = btn1text;
        _buttonText2.text = btn2text;
        _buttonText3.text = btn3text;
        //Inicializar Canvas
        transform.SetParent(canvas);
        transform.localScale = Vector3.one;

        //agregar acción a botones
        //Boton de cerrar, cerrará la ventana. 
        _buttonCerrar.onClick.AddListener(() =>{
            GameObject.Destroy(this.gameObject);
        });
        //La acción que pasamos por parametro es asignada al boton. 
        _button1.onClick.AddListener(() =>{
            action1();
        });
    }
}
