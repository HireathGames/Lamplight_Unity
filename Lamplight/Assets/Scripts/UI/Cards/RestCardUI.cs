using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class RestCardUI : Drag, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 initialPos;
    private Quaternion initialRot;
    private Vector3 initialSca;
    private RestManager manager;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text cost;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text disc;
    private int index;
    private Card card;

    
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        manager.draging = true;
        manager.activeCard = index;
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        //Gets distance from the start and current position
        float distance = Mathf.Sqrt(Mathf.Pow((transform.position.x - initialPos.x), 2) + Mathf.Pow((transform.position.y - initialPos.y), 2));
        //Shrinks the card and tilts it towards the movement
        transform.localScale = new Vector3((initialSca.x * 1.65f) / (1 + (distance / 150)), (initialSca.y * 1.65f) / (1 + (distance / 150)), initialSca.z);
        transform.rotation = new Quaternion(initialRot.x, initialRot.y, (initialPos.x - transform.position.x) / 800, initialRot.w);
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        //resets the card
        base.OnEndDrag(eventData);
        manager.draging = false;
        transform.position = initialPos;
        transform.rotation = initialRot;
        transform.localScale = initialSca;
    }
    public void setUpCard(Vector3 initP, Quaternion initR, Vector3 initS, Card card, RestManager rm, int ind)
    {
        if (card != null)
        {
            initialPos = initP;
            initialRot = initR;
            initialSca = initS;
            card.loadArt();
            this.card = card;
            image.sprite = card.getArt();
            if (!card.getIsX())
            {
                cost.text = card.getCost().ToString();
            } 
            else
            {
                cost.text = "X";
            }
            name.text = card.getName();
            if (!card.getIsBanished())
            {
                disc.text = card.getDiscription();
            }
            else
            {
                disc.text = card.getDiscription() + "\n Banish";
            }
            if (card.getType() == 't')
            {
                disc.color = new Color(355, 355, 355);
                cost.color = new Color(355, 355, 355);
                name.color = new Color(355, 355, 355);
            }
            manager = rm;
            index = ind;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(initialSca.x * 1.25f, initialSca.y * 1.25f, initialSca.z);
        transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = initialSca;
    }
}
