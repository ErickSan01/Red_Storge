using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public float moveSpeed = 5f; // speed at which the character moves
    
    public float maxHeight = -3.18f; // altura máxima permitida
    public  Rigidbody2D rb; // referencia al Rigidbody del personaje

    private Vector3 targetPosition; // position the character is moving towards
    private Animator anim;

    public bool walk = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY; // congela la posición en el eje Y
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (transform.position.y > maxHeight)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY; // congela la posición en el eje Y
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None; // permite el movimiento en el eje Y
        }
    }

    // Update is called once per frame
    void Update()
    {
        // check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // get the world position of the mouse click
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0; // set the z coordinate to 0 to ensure the character stays on the 2D plane
            clickPosition.y = maxHeight;
            // set the target position to the click position
            targetPosition = clickPosition;
        }

        // calculate the direction and distance to the target position
        Vector3 direction = targetPosition - transform.position;
        float distance = direction.magnitude;

        // check if the character has reached the target position
        if (distance > 0.1f)
        {
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

}
