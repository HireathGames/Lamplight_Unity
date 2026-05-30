using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopCardUI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text cost;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text disc;
    [SerializeField] private TMP_Text priceText;
    private Card card;
    public int price;
    public ShopManager manager;
    public void setUpCard(Card card, ShopManager sm, int price)
    {
        if (card != null)
        {
            card.loadArt();
            this.card = card;
            this.price = price;
            manager = sm;
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
            priceText.text = "$" + price.ToString();
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
        }
    }
    public Card getCard() { return card; }
    public void OnPointerDown(PointerEventData eventData)
    {
        manager.buyCard(this);
    }
}
