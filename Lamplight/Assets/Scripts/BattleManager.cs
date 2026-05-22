using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Player player;
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private CardUI UIcard;
    [SerializeField] private List<CardUI> UIcards;
    private List<Card> trueDeck;
    private List<LevelPiece> encounters;
    [SerializeField] private List<Card> deck = new List<Card>();
    [SerializeField] private List<Card> discard = new List<Card>();
    [SerializeField] private List<Card> hand = new List<Card>();
    [SerializeField] private bool isPlaying;
    private PersistentDataManager dataManager;
    public Camera camera;
    [SerializeField] private TMP_Text energy;
    private CursorControl input;
    private int activeIndex;
    private void Awake()
    {
        //Initializes key conponents
        input = new CursorControl();
        camera = Camera.main;
        dataManager = new PersistentDataManager();
    }
    public void setActiveIndex(int ind)
    {
        activeIndex = ind;
    }
    //Don't really know how these work but they are importent
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void endClick ()
    {
        if (isPlaying)
        {
            //Fires a ray then checks if it hits an object and whether it was an enemy or the player
            Ray ray = camera.ScreenPointToRay(input.Mouse.Position.ReadValue<Vector2>());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.GetComponent<Player>() != null)
                    {
                        if (!hand[activeIndex].getIsAttack())
                        {
                            playCard(activeIndex);
                        }
                    }
                    else if (hit.collider.GetComponent<Enemy>() != null)
                    {
                        if (hand[activeIndex].getIsAttack())
                        {
                            player.focus = hit.collider.GetComponent<Enemy>();
                            playCard(activeIndex);
                        }
                    }
                }
            }
        }
    }
    public List<Card> getDeck() { return deck; }
    public bool getPlaying() { return isPlaying; }
    public void setPlaying(bool state) { isPlaying = state; }
    public List<Card> getHand() { return hand; }
    public List<Enemy> getEnemies() { return enemies; }
    public List<Card> getDiscard() { return discard; }
    public void Start()
    {
        //Some more initailization, plus spawning cards on a delay(For testing)
        input.Mouse.Click.performed += _ => endClick();//Lamda expression 
        enemies = new List<Enemy>(FindObjectsOfType<Enemy>());
    }
    private void FixedUpdate()
    {
        if ((enemies != null) && (enemies.Count == 0))
        {
            endCombat();
        }
    }
    public void updateCardsInHand()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            Vector3 cardPosition = new Vector3(canvas.transform.position.x + ((i * 160) - (hand.Count * 70)), canvas.transform.position.y - 160, canvas.transform.position.z);
            UIcards[i].transform.position = cardPosition;
            UIcards[i].setUpCard(cardPosition, UIcards[i].transform.rotation, UIcards[i].transform.localScale, hand[i], this, i);
        }
        energy.text = player.getEnergy().ToString();
    }
    public void loadPlayerData()
    {
        RunData currentRun = dataManager.loadRun();
        if (currentRun != null)
        {
            player.initialize(currentRun.HP, currentRun.maxHP, currentRun.sanity);
            trueDeck = currentRun.deck;
            encounters = currentRun.nextEncounters;
        }
    }
    public void startCombat()
    {
        loadPlayerData();
        List<Card> setUp = new List<Card>();
        foreach (Card c in trueDeck)
        {
            setUp.Add(c);
        }
        shuffle(setUp);
        startTurn();
    }
    public void endCombat()
    {
        
        RunData runData = new RunData(player.getHealth(), player.getMaxHealth(), player.getSanity(), trueDeck, encounters);
        dataManager.saveRun(runData);
        SceneManager.LoadScene("Level_1_Map");
    }
    public void startTurn()
    {
        for (int i = 0; i < 5; i++)
        {
            draw();
        }
        sanityRandomizer();
        player.setEnergy(3);
        updateCardsInHand();
    }
    public void endTurn()
    {
        while(hand.Count > 0)
        {
            discardCard(0);
        }
        //Make so it works even with enemies dying during their own turns
        foreach (Enemy e in enemies)
        {
            e.takeTurn(player);
        }
        startTurn();
    }
    public void draw()
    {
        if (deck.Count == 0)
        {
            if (discard.Count != 0)
            {
                shuffle(discard);
            }
            else
            {
                return;
            }
        }
        Card drawn = deck[0];
        deck.RemoveAt(0);
        CardUI tempCard = Instantiate(UIcard, canvas.transform.position, canvas.transform.rotation, canvas.transform);
        hand.Add(drawn);
        UIcards.Add(tempCard);
        updateCardsInHand();
    }
    public void discardCard(int handPosition)
    {
        if (hand[handPosition] != null)
        {
            discard.Add(hand[handPosition]);
            hand.RemoveAt(handPosition);
            Destroy(UIcards[handPosition].gameObject);
            UIcards.RemoveAt(handPosition);
            updateCardsInHand();
        }
    }
    private void shuffle(List<Card> into)
    {
        //Shuffles cards into the deck
        int times = into.Count;
        for (int i = 0; i < times; i++)
        {
            int randomCard = Random.Range(0, into.Count);
            deck.Add(into[randomCard]);
            into.RemoveAt(randomCard);
        }
    }
    public void playCard(int handPosition)
    {
        if (hand[handPosition].getCost() <= player.getEnergy())
        {
            if (hand[handPosition] != null)
            {
                if (hand[handPosition].getIsX())
                {
                    hand[handPosition].play(player.getEnergy(), player);
                    player.setEnergy(0);
                }
                else
                {
                    hand[handPosition].play(hand[handPosition].getCost(), player);
                    player.setEnergy(player.getEnergy() - hand[handPosition].getCost());
                }
                if (!hand[handPosition].getIsBanished())
                {
                    discard.Add(hand[handPosition]);
                }
                hand.RemoveAt(handPosition);
                Destroy(UIcards[handPosition].gameObject);
                UIcards.RemoveAt(handPosition);
                updateCardsInHand();
            }
        }
    }
    public void sanityRandomizer()
    {
        foreach (Card c in hand)
        {
            c.resetCost();
        }
        if (player.getSanity() > 0)
        {
            int randoms = (int) (100f - player.getSanity()) / 25;
            for (int i = 0; i < randoms; i++)
            {
                int pos = Random.Range(0, hand.Count);
                hand[pos].setCost(Random.Range(1, 3));
            }
        }
        else
        {
            foreach (Card c in hand)
            {
                c.setCost(Random.Range(0, 6));
            }
        }
    }
}
