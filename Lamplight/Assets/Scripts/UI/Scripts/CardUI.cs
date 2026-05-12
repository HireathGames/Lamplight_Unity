using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardUI : Drag
{
    public Vector3 initialPos;
    public Quaternion initialRot;
    public Vector3 initialSca;
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        float distance = Mathf.Sqrt(Mathf.Pow((transform.position.x - initialPos.x), 2) + Mathf.Pow((transform.position.y - initialPos.y), 2));
        Debug.Log(distance);
        transform.localScale = new Vector3(initialSca.x / (1 + (distance/850)), initialSca.y / (1 + (distance / 850)), initialSca.z);
        transform.rotation = new Quaternion(initialRot.x, initialRot.y, (initialPos.x - transform.position.x) / 800, initialRot.w);
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        transform.position = initialPos;
        transform.rotation = initialRot;
        transform.localScale = initialSca;
    }
}
