using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clase que representa una ventana emergente en el juego.
/// </summary>
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

    /// <summary>
    /// Inicializa la ventana emergente con los elementos necesarios.
    /// </summary>
    /// <param name="canvas">El transform del canvas donde se mostrará la ventana emergente.</param>
    /// <param name="popupMessage">El mensaje de la ventana emergente.</param>
    /// <param name="btn1text">El texto del primer botón.</param>
    /// <param name="btn2text">El texto del segundo botón.</param>
    /// <param name="btn3text">El texto del tercer botón.</param>
    /// <param name="action1">La acción a ejecutar cuando se presiona el primer botón.</param>
    /// <param name="action2">La acción a ejecutar cuando se presiona el segundo botón.</param>
    /// <param name="action3">La acción a ejecutar cuando se presiona el tercer botón.</param>
    /// <param name="jugador">El script del jugador asociado a la ventana emergente.</param>
    public void Init(Transform canvas, string popupMessage, string btn1text, string btn2text, string btn3text, System.Action action1, System.Action action2, System.Action action3, Player_Script jugador)
    {
        //asignar textos a los botones
        _popupText.text = popupMessage;
        _buttonText1.text = btn1text;
        _buttonText2.text = btn2text;
        _buttonText3.text = btn3text;

        //Inicializar Canvas
        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        //agregar acción a botones
        //Boton de cerrar, cerrará la ventana. 
        _buttonCerrar.onClick.AddListener(() =>
        {
            jugador.GetComponent<Renderer>().enabled = true;
            // jugador.inPopUp = false;
            GameObject.Destroy(this.gameObject);
        });

        //La acción que pasamos por parametro es asignada al boton. 
        _button1.onClick.AddListener(() =>
        {
            action1();
        });

        _button2.onClick.AddListener(() =>
        {
            action2();
        });

        _button3.onClick.AddListener(() =>
        {
            action3();
        });
    }
}
