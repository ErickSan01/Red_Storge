using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Script : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad a la que se mueve el personaje

    private Vector3 targetPosition; // Direccion en la que el personaje se está moviendo
    private bool isMoving = false; // boolean para saber si el personaje se está moviendo

    public float maxHeight = -2.96f; // Altitud máxima donde el personaje se puede mover

    private Animator anim;

    public bool walk = false;

    // Update is called once per frame
    void Update()
    {
        // Checa si se hace click izquerdo en el mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Obtener la posición de donde se hizo click
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0; // Bloquea la coordenada z para que el personaje no cambie de plano
            clickPosition.y = maxHeight; // Bloquear la coordenada y para que el personaje no suba más de lo permitido

            // Asigna el destino a la posición donde se hizo click
            targetPosition = clickPosition;
            isMoving = true; // El personaje se empieza a mover
        }

        // Calcula la distancia y la dirección de el destino
        Vector3 direction = targetPosition - transform.position;
        float distance = direction.magnitude;

        if (isMoving)
        {
            // Checa si el personaje llegó al destino
            if (distance < 0.1f)
            {
                isMoving = false; // El personaje se deja de mover
            }
            else
            {
                // Se checan colisiones con otros objetos
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject != gameObject)
                    {
                        isMoving = false; // El personaje se deja de mover si se detecta alguna colisión

                        Action action1 = () =>{ Camera.main.backgroundColor = UnityEngine.Random.ColorHSV();};

                        Popup popup = UIController.Instance.CreatePopUp();

                        popup.Init(UIController.Instance.MainCanvas, "Hola", "Btn1", "Btn2", "Btn3", action1);
                    }
                }

                // El personaje se mueve hacia el destino
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
            }
            walk = true;
            anim.SetBool("walk",walk);
            // move the character towards the target position
            Debug.Log(direction.normalized);
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
        }else{
            walk = false;
            anim.SetBool("walk",walk);
        }

        flip(direction.x);
    }

    private void flip(float xValue){
        Vector3 theScale = transform.localScale;
        if (xValue< 0)
        {
            theScale.x = Mathf.Abs(theScale.x)*-1;
        }else
        {
            if (xValue> 0)
            {
                theScale.x = Mathf.Abs(theScale.x);
            }
        }
        transform.localScale = theScale;
    }

    private void Start() {
        transform.position = new Vector3(-8.68f,-2.96f,0f);
        anim = GetComponent<Animator>();
    }


}
