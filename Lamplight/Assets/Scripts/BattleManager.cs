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
    private void Awake()
    {
        //Initializes key conponents
        input = new CursorControl();
        camera = Camera.main;
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
                        Debug.Log("Player");
                    }
                    else if (hit.collider.GetComponent<Enemy>() != null)
                    {
                        Debug.Log("Enemy");
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
        Invoke("spawnCards", 1);
    }
    public void spawnCards()
    {
        //Spawns cards and sets positions. NOTE: This should pretty much be fully reworked (Except the position setting code)
        //Try to attatch this to the draw
        for (int i = 0; i < hand.Count; i++)
        {
            Vector3 cardPosition = new Vector3(canvas.transform.position.x + ((i * 160) - (hand.Count * 70)), canvas.transform.position.y - 160, canvas.transform.position.z);
            CardUI tempCard = Instantiate(UIcard, cardPosition, canvas.transform.rotation, canvas.transform);
            tempCard.initialPos = cardPosition;
            tempCard.initialSca = tempCard.transform.localScale;
            tempCard.initialRot = tempCard.transform.rotation;
            tempCard.manager = this;
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
        hand.Add(drawn);
    }
    public void discardCard(int handPosition)
    {
        if (hand[handPosition] != null)
        {
            discard.Add(hand[handPosition]);
            hand.RemoveAt(handPosition);
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
        }
    }
}
