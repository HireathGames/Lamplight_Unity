using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Unlock
{
    [SerializeField] private bool isCard;
    [SerializeReference] private Sprite sprite;
    [SerializeReference] private string name;
    public Unlock(Artifact artifact)
    {
        isCard = false;
        name = artifact.getName();
        sprite = artifact.getArt();
    }
    public Unlock(Card card)
    {
        isCard = true;
        name = card.getName();
        card.loadArt();
        sprite = card.getArt();
    }
    public Unlock (string name, Sprite sprite)
    {
        isCard = false;
        this.name = name;
        this.sprite = sprite;
    }
    public Sprite getArt()
    {
        return sprite;
    }
    public string getName() { return name; }
    public bool cardCheck() { return isCard; }
}
