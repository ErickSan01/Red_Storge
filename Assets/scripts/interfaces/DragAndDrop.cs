using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que permite arrastrar y soltar un objeto en una posición específica.
/// </summary>
public class DragAndDrop : MonoBehaviour
{
    /// <summary>
    /// Objeto que se va a arrastrar.
    /// </summary>
    public GameObject objectToDrag;

    /// <summary>
    /// Objeto al que se debe arrastrar el objeto.
    /// </summary>
    public GameObject ObjectDragToPos;

    /// <summary>
    /// Distancia máxima permitida para soltar el objeto.
    /// </summary>
    public float DropDistance;

    /// <summary>
    /// Indica si el objeto está bloqueado y no se puede arrastrar.
    /// </summary>
    public bool isLocked;

    /// <summary>
    /// Posición original del objeto antes de ser arrastrado.
    /// </summary>
    Vector2 ObjectOriginalPosition;

    // Start is called before the first frame update
    void Start()
    {
        ObjectOriginalPosition = objectToDrag.transform.position;
        Debug.Log(ObjectOriginalPosition);
    }

    /// <summary>
    /// Método que se llama cuando se arrastra el objeto.
    /// </summary>
    public void DragObject()
    {
        if (!isLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }

    /// <summary>
    /// Método que se llama cuando se suelta el objeto.
    /// </summary>
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
            Debug.Log(ObjectOriginalPosition);
        }
    }
}
