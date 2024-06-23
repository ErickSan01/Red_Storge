
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Clase que representa un grupo de elementos en un contenedor.
/// Implementa la interfaz IDropHandler para manejar eventos de arrastrar y soltar.
/// </summary>
public class ItemPool : MonoBehaviour, IDropHandler
{
    /// <summary>
    /// Método que se ejecuta cuando se suelta un elemento en el contenedor.
    /// Establece el padre del elemento arrastrado como el contenedor actual.
    /// </summary>
    /// <param name="eventData">Datos del evento de arrastrar y soltar.</param>
    public void OnDrop(PointerEventData eventData)
    {
        DragHandler.itemDragging.transform.SetParent(transform);
    }
}