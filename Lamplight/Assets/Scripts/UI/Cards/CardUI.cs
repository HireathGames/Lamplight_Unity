using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CardUI : Drag, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 initialPos;
    private Quaternion initialRot;
    private Vector3 initialSca;
    private BattleManager manager;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text cost;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text disc;
    [SerializeField] private Image insanityFilter;
    private int index;
    private float randomizeColor;
    private Card card;

    private void Update()
    {
        if (card.getRandomized())
        {
            randomizeColor += Time.deltaTime;
            insanityFilter.color = new Color(0, 0, 0, Mathf.Abs(Mathf.Sin(randomizeColor * 1.15f) * 0.85f));
            cost.color = new Color(Mathf.Abs(Mathf.Cos(randomizeColor * 1.325f)), Mathf.Abs(Mathf.Cos(randomizeColor * 1.325f)), Mathf.Abs(Mathf.Cos(randomizeColor * 1.325f)));
        }
    }
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (manager.actionAvailable())
        {
            //Makes override to make sure the manager is aware of the card moving
            base.OnBeginDrag(eventData);
            manager.setActiveIndex(index);
            manager.setPlaying(true);
        }
    }
    public override void OnDrag(PointerEventData eventData)
    {
        if (manager.actionAvailable())
        {
            base.OnDrag(eventData);
            //Gets distance from the start and current position
            float distance = Mathf.Sqrt(Mathf.Pow((transform.position.x - initialPos.x), 2) + Mathf.Pow((transform.position.y - initialPos.y), 2));
            //Shrinks the card and tilts it towards the movement
            transform.localScale = new Vector3((initialSca.x * 1.65f) / (1 + (distance / 150)), (initialSca.y * 1.65f) / (1 + (distance / 150)), initialSca.z);
            transform.rotation = new Quaternion(initialRot.x, initialRot.y, (initialPos.x - transform.position.x) / 800, initialRot.w);
        }
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (manager.actionAvailable())
        {
            //resets the card
            base.OnEndDrag(eventData);
            manager.setPlaying(false);
            transform.position = initialPos;
            transform.rotation = initialRot;
            transform.localScale = initialSca;
        }
    }
    public void setUpCard(Vector3 initP, Quaternion initR, Vector3 initS, Card card, BattleManager bm, int ind)
    {
        if (card != null)
        {
            card.loadArt();
            initialPos = initP;
            initialRot = initR;
            initialSca = initS;
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
            manager = bm;
            index = ind;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Grows the card when hovered
        if (manager.actionAvailable())
        {
            transform.localScale = new Vector3(initialSca.x * 1.65f, initialSca.y * 1.65f, initialSca.z);
            transform.SetAsLastSibling();
            image.sprite = card.getAlt();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (manager.actionAvailable())
        {
            transform.localScale = initialSca;
            image.sprite = card.getArt();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        manager.setPlaying(true);
        manager.setActiveIndex(index);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        manager.setPlaying(false);
    }
}
