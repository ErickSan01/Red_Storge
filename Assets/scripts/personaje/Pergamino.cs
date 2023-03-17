using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pergamino : MonoBehaviour
{

    public static Pergamino Instance;

    public string numeroPregunta = "1";
    public string textoPregunta;
    public string opcion1 = "Opcion A";
    public string opcion2 = "Opcion B";
    public string opcion3 = "Opcion C";
    public Action boton1;
    public Action boton2;
    public Action boton3;
    Player_Script player;

    private void Start()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public void crearPergamino(Action boton1, Action boton2, Action boton3, Player_Script player)
    {
        
            player.GetComponent<Renderer>().enabled = false;

            Popup popup = UIController.Instance.CreatePopUp();

            popup.Init(UIController.Instance.MainCanvas, "Pregunta " + numeroPregunta, opcion1, opcion2, opcion3, boton1, boton2, boton3, player);

    }
}
