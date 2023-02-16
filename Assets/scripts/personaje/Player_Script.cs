using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement2D : MonoBehaviour
{
    //La variable moveSpeed determina la velocidad del movimiento.
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    //En el método Start(), obtenemos una referencia al componente Rigidbody2D del objeto en el que se agrega este script.
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //En el método Update(), verificamos si el botón izquierdo del mouse está siendo presionado (con Input.GetMouseButton(0))
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Si se está presionando el botón izquierdo del mouse, obtenemos la posición del mouse en el mundo (mousePos) 
            //utilizando Camera.main.ScreenToWorldPoint().
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Calculamos la dirección en la que se mueve el objeto restando la posición del mouse (mousePos) a la posición 
            //actual del objeto (transform.position) y normalizando el resultado para tener una dirección de longitud 1.            
            Vector2 direction = (mousePos - transform.position).normalized;
            //Asignamos la velocidad del objeto utilizando rb.velocity, 
            //que se calcula como la dirección multiplicada por la velocidad (moveSpeed).
            rb.velocity = direction * moveSpeed;
        }
    }
}