using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que representa una bola de fuego en el juego.
/// </summary>
public class Fireball : MonoBehaviour
{

    private Animator anim;
    public GameObject target;
    public float rango_vision;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.SetActive(false);
        target= GameObject.Find("Jugador");
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x - target.transform.position.x) > rango_vision )
        {
            gameObject.SetActive(true);
            anim.SetBool("Choca",true);
        }
    }

    /// <summary>
    /// Método que se llama cuando el objeto colisiona con otro objeto.
    /// </summary>
    /// <param name="collision">El objeto con el que colisionó.</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Jugador"))
        {
            gameObject.SetActive(true);
            anim.SetBool("Choca",true);
        }
    }
}
