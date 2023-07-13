using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    public GameObject objectToDrag;
    public GameObject ObjectDragToPos;
    public float DropDistance;
    public bool isLocked;
    Vector2 ObjectOriginalPosition;


    // Start is called before the first frame update
    void Start()
    {
        ObjectOriginalPosition = objectToDrag.transform.position;
    }

    public void DragObject()
    {
        if (!isLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }


    public void DropObject()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, ObjectDragToPos.transform.position);

        if (Distance < DropDistance)
        {
            isLocked = true;
            objectToDrag.transform.position = ObjectDragToPos.transform.position;
        }
        else
        {
            objectToDrag.transform.position = ObjectOriginalPosition;
        }
    }
}
