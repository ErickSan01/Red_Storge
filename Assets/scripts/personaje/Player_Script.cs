using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public float moveSpeed = 5f; // speed at which the character moves

    private Vector3 targetPosition; // position the character is moving towards

    // Update is called once per frame
    void Update()
    {
        // check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // get the world position of the mouse click
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0; // set the z coordinate to 0 to ensure the character stays on the 2D plane

            // set the target position to the click position
            targetPosition = clickPosition;
        }

        // calculate the direction and distance to the target position
        Vector3 direction = targetPosition - transform.position;
        float distance = direction.magnitude;

        // check if the character has reached the target position
        if (distance > 0.1f)
        {
            // move the character towards the target position
            Debug.Log(direction.normalized);
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
        }
    }

}
