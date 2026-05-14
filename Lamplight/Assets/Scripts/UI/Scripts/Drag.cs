using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //This can be attatched to a UI element to make it dragable
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        //makes it so it is above everything else in the UI
        transform.SetAsLastSibling();
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        //Sets the objects position to that of the mouse
        transform.position = Input.mousePosition;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
