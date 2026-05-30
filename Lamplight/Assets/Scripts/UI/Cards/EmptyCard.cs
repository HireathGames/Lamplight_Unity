using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmptyCard : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text cost;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text disc;
    private Card card;
    public void setUpCard(Card card)
    {
        if (card != null)
        {
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
        }
    }

}
