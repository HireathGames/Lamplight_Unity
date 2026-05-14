using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardUI : Drag, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 initialPos;
    public Quaternion initialRot;
    public Vector3 initialSca;
    public BattleManager manager;
    
    public override void OnBeginDrag(PointerEventData eventData)
    {
        //Makes override to make sure the manager is aware of the card moving
        base.OnBeginDrag(eventData);
        manager.setPlaying(true);
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        //Gets distance from the start and current position
        float distance = Mathf.Sqrt(Mathf.Pow((transform.position.x - initialPos.x), 2) + Mathf.Pow((transform.position.y - initialPos.y), 2));
        //Shrinks the card and tilts it towards the movement
        transform.localScale = new Vector3(initialSca.x / (1 + (distance/850)), initialSca.y / (1 + (distance / 850)), initialSca.z);
        transform.rotation = new Quaternion(initialRot.x, initialRot.y, (initialPos.x - transform.position.x) / 800, initialRot.w);
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        //resets the card
        base.OnEndDrag(eventData);
        manager.setPlaying(false);
        transform.position = initialPos;
        transform.rotation = initialRot;
        transform.localScale = initialSca;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Grows the card when hovered
        transform.localScale = new Vector3(initialSca.x * 1.35f, initialSca.y * 1.35f, initialSca.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = initialSca;
    }
}
