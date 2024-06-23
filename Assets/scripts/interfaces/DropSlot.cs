using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Clase que representa un espacio de soltado para arrastrar objetos.
/// Implementa la interfaz IDropHandler para manejar eventos de soltado.
/// </summary>
public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;

    /// <summary>
    /// Método que se llama cuando se suelta un objeto en el espacio de soltado.
    /// </summary>
    /// <param name="eventData">Datos del evento de soltado.</param>
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");

        if (!item)
        {
            item = DragHandler.itemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
        }
    }

    private void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            Debug.Log("Remover");
            item = null;
        }
    }
}