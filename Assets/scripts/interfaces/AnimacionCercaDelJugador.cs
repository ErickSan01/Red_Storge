using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla la activación de una animación cuando el jugador se acerca a un objeto animado.
/// </summary>
public class AnimacionCercaDelJugador : MonoBehaviour
{
    public Transform jugador;
    public Transform objetoAnimado;
    public float distanciaActivacion = 5f;

    private Animator animator; // Necesitarás una referencia al componente Animator si estás utilizando animaciones.

    private void Start()
    {
        animator = objetoAnimado.GetComponent<Animator>(); // Obtén el componente Animator del objeto animado.
        
    }

    private void Update()
    {
        float distanciaAlJugador = Vector2.Distance(jugador.position, objetoAnimado.position);

        if (distanciaAlJugador <= distanciaActivacion)
        {
            // Activa la animación si estás utilizando un Animator.
            if (animator != null)
            {
                gameObject.SetActive(true);
                animator.SetBool("ActivarAnimacion", true); // "ActivarAnimacion" debe ser el nombre del parámetro de la animación.
            }

            // Si no estás utilizando Animator y solo quieres mover el objeto, puedes hacerlo de esta manera:
            // objetoAnimado.Translate(Vector2.up * Time.deltaTime);
        }
        else if (distanciaAlJugador - distanciaActivacion==0f)
        {
            // Desactiva la animación si estás utilizando un Animator.
            if (animator != null)
            {
                animator.SetBool("ActivarAnimacion", false);
                gameObject.SetActive(false);
            }
        }
        else
        {
            // Desactiva la animación si estás utilizando un Animator.
            if (animator != null)
            {
                animator.SetBool("ActivarAnimacion", false);
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
