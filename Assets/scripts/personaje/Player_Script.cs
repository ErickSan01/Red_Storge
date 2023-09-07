using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class Player_Script : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad a la que se mueve el personaje

    private Vector3 targetPosition; // Direccion en la que el personaje se está moviendo
    private bool isMoving = false; // boolean para saber si el personaje se está moviendo

    public float maxHeight = -2.96f; // Altitud máxima donde el personaje se puede mover

    private Animator anim;

    private AudioSource audioSource;

    public bool walk = false;

    public bool inPopUp = false;

    public bool ignorarColisiones = false;

    public AudioClip footstepSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!inPopUp){
            // Checa si se hace click izquerdo en el mouse
            if (Input.GetMouseButtonDown(0))
            {
                if (ignorarColisiones) {
                    ignorarColisiones = false;
                } else {
                    // Obtener la posición de donde se hizo click
                    Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    clickPosition.z = 0; // Bloquea la coordenada z para que el personaje no cambie de plano
                    clickPosition.y = maxHeight; // Bloquear la coordenada y para que el personaje no suba más de lo permitido

                    // Asigna el destino a la posición donde se hizo click
                    targetPosition = clickPosition;
                    isMoving = true; // El personaje se empieza a mover
                }
            }

            Vector3 direction = Vector3.zero;


            if (isMoving)
            {
                // Calcula la distancia y la dirección de el destino
                direction = targetPosition - transform.position;
                float distance = direction.magnitude;
                // Checa si el personaje llegó al destino
                if (distance < 0.1f)
                {
                    isMoving = false; // El personaje se deja de mover
                }
                else
                {
                    // El personaje se mueve hacia el destino
                    if(isMoving && !ignorarColisiones){
                        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
                    }
                }
                walk = true;
                anim.SetBool("walk",walk);
                // move the character towards the target position
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
            }else{
                walk = false;
                anim.SetBool("walk",walk);
            }

            flip(direction.x);
            HandleFootstepSound();
        }
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

    void HandleFootstepSound()
    {
        if (isMoving && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(footstepSound);
        }
        else if (!isMoving)
        {
            audioSource.Stop();
        }
    }

    private void Start() {
        transform.position = new Vector3(-8.68f,-2.96f,1f);
        anim = GetComponent<Animator>();
    }


}
