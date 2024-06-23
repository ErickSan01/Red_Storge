using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Controlador para arrastrar objetos en la interfaz.
/// </summary>
public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static GameObject itemDragging;

    private Vector3 startPosition;
    private Transform startParent;
    private Transform dragParent;

    private void Start() 
    {
        dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
    }

    #region DragFunctions

    /// <summary>
    /// Se llama cuando se comienza a arrastrar el objeto.
    /// </summary>
    /// <param name="eventData">Datos del evento de arrastre.</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        itemDragging = gameObject;

        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(dragParent);
    }

    /// <summary>
    /// Se llama mientras se arrastra el objeto.
    /// </summary>
    /// <param name="eventData">Datos del evento de arrastre.</param>
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    /// <summary>
    /// Se llama cuando se termina de arrastrar el objeto.
    /// </summary>
    /// <param name="eventData">Datos del evento de arrastre.</param>
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        itemDragging = null;

        if (transform.parent == dragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }

    #endregion

    private void Update()
    {

    }
}