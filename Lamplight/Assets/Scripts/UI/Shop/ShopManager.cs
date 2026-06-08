using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    private PersistentDataManager dataManager;
    private RunData run;
    private Artifact availableArtifact;
    [SerializeField] private TextBoxOnHover artifactIcon;
    [SerializeField] private TMP_Text artifactPrice;
    [SerializeField] private List<EmptyCard> UIdeck = new List<EmptyCard>();
    [SerializeField] private EmptyCard EmptyUIcard;
    [SerializeField] private ShopCardUI shopCard;
    [SerializeField] private GameObject deckPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject textBox;
    [SerializeField] private TMP_Text dialogue;
    [SerializeField] private List<string> harkerLines;
    [SerializeField] private List<string> frankensteinLines;
    [SerializeField] private List<string> jekyllLines;
    [SerializeField] private List<string> dorianLines;
    [SerializeField] private TMP_Text sorrows;
    [SerializeField] private Canvas canvas;
    private List<ShopCardUI> cardsForSale = new List<ShopCardUI>();
    private int scrollIndex;
    public TMP_Text health;
    public TMP_Text sanity;
    [SerializeField] private TextBoxOnHover OwnedArtifactIcon;
    private List<TextBoxOnHover> ArtifactIcons = new List<TextBoxOnHover>();
    private void Awake()
    {
        dataManager = new PersistentDataManager();
        run = dataManager.loadRun();
    }
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            ShopCardUI tempCard = Instantiate(shopCard, canvas.transform.position, canvas.transform.rotation, canvas.transform);
            float chance = Random.Range(0f, 1f);
            if (chance <= 0.75f)
            {
                Card chosenCard = run.rewardCards[Random.Range(0, run.rewardCards.Count)];
                tempCard.setUpCard(chosenCard, this, Random.Range(35, 66));
                cardsForSale.Add(tempCard);
            }
            else
            {
                Card chosenCard = run.legendaryRewardCards[Random.Range(0, run.legendaryRewardCards.Count)];
                tempCard.setUpCard(chosenCard, this, Random.Range(65, 111));
                cardsForSale.Add(tempCard);
            }
        }
        if (run.shopArtifacts != null && run.shopArtifacts.Count != 0)
        {
            availableArtifact = run.shopArtifacts[Random.Range(0, run.shopArtifacts.Count)];
            availableArtifact.randomizeCost();
            artifactIcon.initializeTextBox(availableArtifact.getName(), availableArtifact.getDiscription(), availableArtifact.getArt());
            artifactPrice.text = "$" + availableArtifact.getCost();
        }
        else
        {
            Destroy(artifactIcon.gameObject);
        }
        if (run.heldArtifacts != null && run.heldArtifacts.Count != 0)
        {
            for (int i = 0; i < run.heldArtifacts.Count; i++)
            {
                TextBoxOnHover icon = Instantiate(OwnedArtifactIcon, new Vector3(canvas.transform.position.x + (((i * 55) - (330 + (660 * (i / 12)))) * canvas.scaleFactor), canvas.transform.position.y + ((280 - (110 * (i / 12))) * canvas.scaleFactor), canvas.transform.position.z), canvas.transform.rotation, canvas.transform);
                icon.initializeTextBox(run.heldArtifacts[i].getName(), run.heldArtifacts[i].getDiscription(), run.heldArtifacts[i].getArt());
                ArtifactIcons.Add(icon);
            }
        }
        health.text = "Health:" + run.HP + "/" + run.maxHP;
        sanity.text = "Sanity:" + run.sanity;
        updateCardPositions();
        textBox.SetActive(false);
        Invoke("showTextBox", 2);
    }
    public void updateCardPositions()
    {
        sorrows.text = "$" + run.sorrows.ToString();
        for (int i = 0; i < cardsForSale.Count; i++)
        {
            Vector3 cardPosition = new Vector3(canvas.transform.position.x + (((i * 200) - 200) * canvas.scaleFactor), canvas.transform.position.y - (205 * canvas.scaleFactor), canvas.transform.position.z);
            cardsForSale[i].transform.position = cardPosition;
        }
    }
    public void buyArtifact()
    {
        if (availableArtifact.getCost() <= run.sorrows)
        {
            run.sorrows -= availableArtifact.getCost();
            run.heldArtifacts.Add(availableArtifact);
            if (availableArtifact.isUnique())
            {
                run.shopArtifacts.Remove(availableArtifact);
            }
            Destroy(artifactIcon.gameObject);
        }
    }
    public void buyCard(ShopCardUI cardUI)
    {
        if (cardUI.price <= run.sorrows)
        {
            run.sorrows -= cardUI.price;
            run.deck.Add(cardUI.getCard());
            cardsForSale.Remove(cardUI);
            Destroy(cardUI.gameObject);
        }
        updateCardPositions();
    }
    public void showDeckUI()
    {
        deckPanel.SetActive(true);
        shopPanel.SetActive(false);
        for (int i = 0; i < run.deck.Count; i++)
        {
            Vector3 cardPosition = new Vector3(canvas.transform.position.x + (((i * 120) - (400 + (840 * (i / 7)))) * canvas.scaleFactor), canvas.transform.position.y + ((200 - (200 * (i / 7))) * canvas.scaleFactor), canvas.transform.position.z);
            EmptyCard tempCard = Instantiate(EmptyUIcard, canvas.transform.position, canvas.transform.rotation, canvas.transform);
            tempCard.transform.position = cardPosition;
            tempCard.setUpCard(run.deck[i]);
            UIdeck.Add(tempCard);
        }
        hideMain();
    }
    public void hideMain()
    {
        foreach (ShopCardUI card in cardsForSale)
        {
            card.gameObject.SetActive(false);
        }
        foreach (TextBoxOnHover icon in ArtifactIcons)
        {
            icon.gameObject.SetActive(false);
        }
        artifactIcon.gameObject.SetActive(false);
        artifactPrice.gameObject.SetActive(false);
    }
    public void showMain()
    {
        foreach (ShopCardUI card in cardsForSale)
        {
            card.gameObject.SetActive(true);
        }
        foreach (TextBoxOnHover icon in ArtifactIcons)
        {
            icon.gameObject.SetActive(true);
        }
        artifactIcon.gameObject.SetActive(true);
        artifactPrice.gameObject.SetActive(true);
    }
    public void showTextBox()
    {
        textBox.SetActive(true);
        if (run.character.Equals("JH"))
        {
            dialogue.text = harkerLines[Random.Range(0, harkerLines.Count)];
        }
        else if (run.character.Equals("VF"))
        {
            dialogue.text = frankensteinLines[Random.Range(0, frankensteinLines.Count)];
        }
        else if (run.character.Equals("HJ&EH"))
        {
            dialogue.text = jekyllLines[Random.Range(0, jekyllLines.Count)];
        }
        else if (run.character.Equals("DG"))
        {
            dialogue.text = dorianLines[Random.Range(0, dorianLines.Count)];
        }
    }
    public void scroll(int direction)
    {
        if (UIdeck.Count != 0)
        {
            if (((direction + scrollIndex) >= 0) && ((direction + scrollIndex) <= UIdeck.Count / 7))
            {
                foreach (EmptyCard card in UIdeck)
                {
                    card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y + (direction * 200), card.transform.position.z);
                }
                scrollIndex += direction;
            }
        }
    }
    public void HideDeckUI()
    {
        foreach (EmptyCard card in UIdeck)
        {
            Destroy(card.gameObject);
        }
        UIdeck.Clear();
        deckPanel.SetActive(false);
        shopPanel.SetActive(true);
        showMain();
    }
    public void exit()
    {
        dataManager.saveRun(run);
        SceneManager.LoadScene("Level_1_Map");
    }
}
