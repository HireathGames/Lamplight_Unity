using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Player player;
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private CardUI UIcard;
    [SerializeField] private List<CardUI> UIcards;
    [SerializeField] private List<Card> deck = new List<Card>();
    [SerializeField] private List<Card> discard = new List<Card>();
    [SerializeField] private List<Card> hand = new List<Card>();
    [SerializeField] private bool isPlaying;
    public Camera camera;
    private CursorControl input;
    private int activeIndex;
    private void Awake()
    {
        //Initializes key conponents
        input = new CursorControl();
        camera = Camera.main;
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
    public List<Card> getDiscard() { return discard; }
    public void Start()
    {
        //Some more initailization, plus spawning cards on a delay(For testing)
        input.Mouse.Click.performed += _ => endClick();//Lamda expression 
        enemies = new List<Enemy>(FindObjectsOfType<Enemy>());
    }
    public void updateCardsInHand()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            Vector3 cardPosition = new Vector3(canvas.transform.position.x + ((i * 160) - (hand.Count * 70)), canvas.transform.position.y - 160, canvas.transform.position.z);
            UIcards[i].transform.position = cardPosition;
            UIcards[i].setUpCard(cardPosition, UIcards[i].transform.rotation, UIcards[i].transform.localScale, hand[i], this, i);
        }
    }
    public void startCombat()
    {
        List<Card> setUp = deck;
        shuffle(setUp);
        startTurn();
    }
    public void startTurn()
    {
        for (int i = 0; i < 5; i++)
        {
            draw();
        }
        player.setEnergy(3);
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
}
