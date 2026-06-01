using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private Player player;
    [SerializeField] private bool eliteEncounter;
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private List<Player> players;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private List<Transform> enemySpawnPoints;
    [SerializeField] private List<List<Enemy>> encounters = new List<List<Enemy>>();
    [SerializeField] private List<List<Enemy>> eliteEncounters = new List<List<Enemy>>();
    [SerializeField] private List<Enemy> tempSolution;//I can't figure out how to do this properly so this is for testing
    [SerializeField] private CardUI UIcard;
    [SerializeField] private EmptyCard EmptyUIcard;
    [SerializeField] private List<CardUI> UIcards;
    [SerializeField] private List<Card> deck = new List<Card>();
    [SerializeField] private List<Card> discard = new List<Card>();
    [SerializeField] private List<Card> hand = new List<Card>();
    [SerializeField] private List<EmptyCard> UIdeck = new List<EmptyCard>();
    [SerializeField] private bool isPlaying;
    [SerializeField] private GameObject battlePanel;
    [SerializeField] private GameObject rewardsPanel;
    [SerializeField] private GameObject deckPanel;
    private PersistentDataManager dataManager;
    private RunData run;
    public Camera camera;
    [SerializeField] private TMP_Text energy;
    [SerializeField] private TMP_Text sorrows;
    private CursorControl input;
    private int activeIndex;
    private bool combatStarted = false;
    private bool combatOver = false;
    private int enemyCombatStep;
    private int scrollIndex;
    private void Awake()
    {
        //Initializes key conponents
        input = new CursorControl();
        camera = Camera.main;
        dataManager = new PersistentDataManager();
        List<Enemy> tempList = new List<Enemy>();
        tempList.Add(tempSolution[0]);
        tempList.Add(tempSolution[0]);
        tempList.Add(tempSolution[0]);
        encounters.Add(tempList);
        List<Enemy> tempList1 = new List<Enemy>();
        tempList1.Add(tempSolution[0]);
        tempList1.Add(tempSolution[1]);
        encounters.Add(tempList1);
        List<Enemy> tempList2 = new List<Enemy>();
        tempList2.Add(tempSolution[1]);
        tempList2.Add(tempSolution[2]);
        eliteEncounters.Add(tempList2);
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
        if (isPlaying && !combatOver)
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
                        if ((hand[activeIndex] != null) && (!hand[activeIndex].getIsAttack()))
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
    public bool actionAvailable()
    {
        if (player.getDelay() <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void showDeckUI()
    {
        if (actionAvailable() && ((!combatOver) && (enemies.Count != 0)))
        {
            deckPanel.SetActive(true);
            battlePanel.SetActive(false);
            for (int i = 0; i < run.deck.Count; i++)
            {
                Vector3 cardPosition = new Vector3(canvas.transform.position.x + (i * 120) - (400 + (840 * (i / 7))), canvas.transform.position.y + 200 - (200 * (i/7)), canvas.transform.position.z);
                EmptyCard tempCard = Instantiate(EmptyUIcard, canvas.transform.position, canvas.transform.rotation, canvas.transform);
                tempCard.transform.position = cardPosition;
                tempCard.setUpCard(run.deck[i]);
                UIdeck.Add(tempCard);
            }
            foreach (CardUI card in UIcards)
            {
                card.gameObject.SetActive(false);
            }
        }
    }
    public void scroll(int direction)
    {
        if (UIdeck.Count != 0)
        {
            if (((direction + scrollIndex) >= 0) && ((direction + scrollIndex) <= UIdeck.Count/7))
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
        foreach(EmptyCard card in UIdeck)
        {
            Destroy(card.gameObject);
        }
        UIdeck.Clear();
        foreach (CardUI card in UIcards)
        {
            card.gameObject.SetActive(true);
        }
        deckPanel.SetActive(false);
        battlePanel.SetActive(true);
    }
    public bool getPlaying() { return isPlaying; }
    public void setPlaying(bool state) { isPlaying = state; }
    public List<Card> getHand() { return hand; }
    public List<Enemy> getEnemies() { return enemies; }
    public List<Card> getDiscard() { return discard; }
    public void Start()
    {
        //Some more initailization, plus spawning cards on a delay(For testing)
        rewardsPanel.SetActive(false);
        deckPanel.SetActive(false);
        battlePanel.SetActive(true);
        input.Mouse.Click.performed += _ => endClick();//Lamda expression 
        startCombat();
    }
    private void FixedUpdate()
    {
        if (combatOver)
        {
            if (isPlaying)
            {
                run.deck.Add(hand[activeIndex]);
                exitCombatScene();
            }
        }
        else if (((enemies != null) && (enemies.Count == 0)) && (combatStarted))
        {
            endCombat();
        }
        else
        {
            enemies.RemoveAll(item => item == null);
        }
    }
    public void updateCardsInHand()
    {
        if (!combatOver)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                Vector3 cardPosition = new Vector3(canvas.transform.position.x + ((i * 160) - (hand.Count * 70)), canvas.transform.position.y - 160, canvas.transform.position.z);
                UIcards[i].transform.position = cardPosition;
                UIcards[i].setUpCard(cardPosition, UIcards[i].transform.rotation, UIcards[i].transform.localScale, hand[i], this, i);
            }
            energy.text = player.getEnergy().ToString();
        }
        else
        {
            for (int i = 0; i < hand.Count; i++)
            {
                Vector3 cardPosition = new Vector3(canvas.transform.position.x + ((i * 160) - (hand.Count * 55)), canvas.transform.position.y, canvas.transform.position.z);
                UIcards[i].transform.position = cardPosition;
                UIcards[i].setUpCard(cardPosition, UIcards[i].transform.rotation, UIcards[i].transform.localScale, hand[i], this, i);
            }
        }
    }
    private void initializeCombat()
    {
        run = dataManager.loadRun();
        if (run != null)
        {
            if (playerSpawnPoint != null)
            {
                Debug.Log(run.character);
                if (run.character.Equals("VF"))
                {
                    player = Instantiate(players[1], playerSpawnPoint);
                    player.initialize(run.HP, run.maxHP, run.sanity, this);
                }
                else if (run.character.Equals("HJ&EH"))
                {
                    player = Instantiate(players[2], playerSpawnPoint);
                    player.initialize(run.HP, run.maxHP, run.sanity, this);
                }
                else if (run.character.Equals("DG"))
                {
                    player = Instantiate(players[3], playerSpawnPoint);
                    player.initialize(run.HP, run.maxHP, run.sanity, this);
                }
                else
                {
                    player = Instantiate(players[0], playerSpawnPoint);
                    player.initialize(run.HP, run.maxHP, run.sanity, this);
                }
            }
            if (enemySpawnPoints != null && (((encounters != null) && !eliteEncounter) || ((eliteEncounters != null) && eliteEncounter)))
            {
                if (!eliteEncounter)
                {
                    int ran = Random.Range(0, encounters.Count);
                    for (int i = 0; i < encounters[ran].Count; i++)
                    {
                        Enemy e = Instantiate(encounters[ran][i], enemySpawnPoints[i]);
                        enemies.Add(e);
                    }
                }
                else
                {
                    int ran = Random.Range(0, eliteEncounters.Count);
                    for (int i = 0; i < eliteEncounters[ran].Count; i++)
                    {
                        Debug.Log("Successful");
                        Enemy e = Instantiate(eliteEncounters[ran][i], enemySpawnPoints[i]);
                        enemies.Add(e);
                    }
                }
            }
        }
        combatStarted = true;
    }
    public void startCombat()
    {
        initializeCombat();
        if (sorrows != null)
        {
            sorrows.text = "$" + run.sorrows;
        }
        List<Card> setUp = new List<Card>();
        foreach (Card c in run.deck)
        {
            setUp.Add(c);
        }
        shuffle(setUp);
        startTurn();
    }
    public void endCombat()
    {
        while (hand.Count > 0)
        {
            discardCard(0);
        }
        foreach (Card c in discard)
        {
            c.resetCost();
        }
        foreach (Card c in deck)
        {
            c.resetCost();
        }
        rewardsPanel.SetActive(true);
        battlePanel.SetActive(false);
        combatOver = true;
        isPlaying = false;
        if (!eliteEncounter)
        {
            foreach (Card c in run.rewardCards)
            {
                c.resetCost();
            }
            for (int i = 0; i < 3; i++)
            {
                Card reward = run.rewardCards[Random.Range(0, run.rewardCards.Count)];
                CardUI tempCard = Instantiate(UIcard, canvas.transform.position, canvas.transform.rotation, canvas.transform);
                hand.Add(reward);
                UIcards.Add(tempCard);
            }
            run.sorrows += Random.Range(20, 41);
        }
        else
        {
            List<Card> rewardCards = new List<Card>();
            foreach (Card c in run.rewardCards)
            {
                c.resetCost();
                rewardCards.Add(c);
            }
            foreach (Card c in run.legendaryRewardCards)
            {
                c.resetCost();
                rewardCards.Add(c);
            }
            for (int i = 0; i < 3; i++)
            {
                Card reward = rewardCards[Random.Range(0, rewardCards.Count)];
                CardUI tempCard = Instantiate(UIcard, canvas.transform.position, canvas.transform.rotation, canvas.transform);
                hand.Add(reward);
                UIcards.Add(tempCard);
            }
            run.sorrows += Random.Range(60, 81);
        }
        run.HP = player.getHealth();
        run.maxHP = player.getMaxHealth();
        run.sanity = player.getSanity();
        updateCardsInHand();
    }
    public void exitCombatScene()
    {
        if (run != null)
        {
            dataManager.saveRun(run);
        }
        SceneManager.LoadScene("Level_1_Map");
    }
    public void startTurn()
    {
        if (!combatOver)
        {
            if ((hand.Count < 5) && ((discard.Count != 0) || (deck.Count != 0)))
            {
                draw();
                player.setDelay(0.15f);
                Invoke("startTurn", 0.15f);
            }
            else
            {
                sanityRandomizer();
                player.setEnergy(3 + player.mania);
                player.turnModUpdate();
                updateCardsInHand();
            }
        }
    }
    public void endTurn()
    {
        while(hand.Count > 0)
        {
            discardCard(0);
        }
        enemyCombatStep = 0;
        enemyTurnStep();
    }
    public void enemyTurnStep()
    {
        if (enemyCombatStep < enemies.Count)
        {
            Debug.Log(enemies[enemyCombatStep] != null);
            if (enemies[enemyCombatStep] != null)
            {
                enemies[enemyCombatStep].takeTurn(player);
            }
            enemyCombatStep++;
            Invoke("enemyTurnStep", 1);
        }
        else
        {
            startTurn();
        }
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
                player.playCardModUpdate(hand[handPosition]);
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
        if (!combatOver)
        {
            if (player.getSanity() > 0)
            {
                int randoms = (int)(100f - player.getSanity()) / 25;
                for (int i = 0; i < randoms; i++)
                {
                    int pos = Random.Range(0, hand.Count);
                    if (!hand[pos].getIsX())
                    {
                        hand[pos].setCost(Random.Range(1, 3));
                    }
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
}
