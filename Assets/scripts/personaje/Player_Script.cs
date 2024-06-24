using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//  using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;


/// <summary>
/// Clase que controla el comportamiento del jugador en el juego.
/// </summary>
public class Player_Script : MonoBehaviour
{
    UIDocument TeclasTemplate;

    public float moveSpeed = 5f; // Velocidad a la que se mueve el personaje

    private float horizontalSpeed;

    private Animator anim;

    private AudioSource audioSource;

    public bool moveRight = false;

    public bool moveLeft = false;

    // public bool walk;

    public AudioClip footstepSound;

    private Rigidbody2D rb;

    private bool isPlayingFootstepSound = false;


    private void Start() {
        transform.position = new Vector3(-8.68f,-2.96f,1f);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Usuario que tiene la sesion iniciada: " + StateNameController.nombre_usuario);

        // walk = true;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        // HandleFootstepSound();
    }

    /// <summary>
    /// Método que se llama cuando se presiona el botón de mover hacia la izquierda.
    /// </summary>
    public void PointerDownLeft(){
        moveLeft = true;
    }

    /// <summary>
    /// Método que se llama cuando se suelta el botón de mover hacia la izquierda.
    /// </summary>
    public void PointerUpLeft(){
        moveLeft = false;
    }

    /// <summary>
    /// Método que se llama cuando se presiona el botón de mover hacia la derecha.
    /// </summary>
    public void PointerDownRight(){
        moveRight = true;
    }

    /// <summary>
    /// Método que se llama cuando se suelta el botón de mover hacia la derecha.
    /// </summary>
    public void PointerUpRight(){
        moveRight = false;
    }

        
    
    private IEnumerator PlayFootstepSound()
    {
        isPlayingFootstepSound = true;
        audioSource.PlayOneShot(footstepSound, 1f);
        yield return new WaitForSeconds(footstepSound.length);
        isPlayingFootstepSound = false;
    }
    
    private void MovePlayer()
    {
        if (moveRight)
        {
            horizontalSpeed = moveSpeed;
            anim.SetBool("walk", true);
    
            if (!isPlayingFootstepSound)
            {
                StartCoroutine(PlayFootstepSound());
            }
    
            flip(1);
        }
        else if (moveLeft)
        {
            horizontalSpeed = -moveSpeed;
            anim.SetBool("walk", true);
    
            if (!isPlayingFootstepSound)
            {
                StartCoroutine(PlayFootstepSound());
            }
    
            flip(-1);
        }
        else
        {
            anim.SetBool("walk", false);
            horizontalSpeed = 0;
            StopAllCoroutines();
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

    /// <summary>
    /// Método que se llama cuando el jugador colisiona con otro objeto.
    /// </summary>
    /// <param name="collision">El objeto con el que el jugador colisiona.</param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            moveRight = false;
            moveLeft = false;
            rb.velocity = Vector3.zero;
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
    }


    void HandleFootstepSound()
    {
		if (moveLeft || moveLeft)
        {
            audioSource.PlayOneShot(footstepSound);
        }
        else
        {
            audioSource.Stop();
        }
    }
}
