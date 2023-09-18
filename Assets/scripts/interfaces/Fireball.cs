using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Jugador"))
        {
            gameObject.SetActive(true);
            anim.SetBool("Choca",true);
        }
    }
}
