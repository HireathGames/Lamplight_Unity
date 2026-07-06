using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public List<LevelPiece> encounters;
    private List<LevelPiece> futurePieces = new List<LevelPiece>();
    public LevelPiece bossPiece;
    [SerializeField] private Light futureLight;
    [SerializeField] private List<Transform> choicesSpawnPositions;
    [SerializeField] private List<Transform> futureSpawnPositions;
    public Camera camera;
    private CursorControl input;
    private PersistentDataManager dataManager;
    private RunData run;
    public TMP_Text health;
    public TMP_Text sanity;
    [SerializeField] private TextBoxOnHover ArtifactIcon;
    private List<TextBoxOnHover> ArtifactIcons = new List<TextBoxOnHover>();
    [SerializeField] private List<EmptyCard> UIdeck = new List<EmptyCard>();
    [SerializeField] private EmptyCard EmptyUIcard;
    [SerializeField] private GameObject deckPanel;
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private TMP_Text sorrows;
    [SerializeField] private Canvas canvas;
    public TMP_Text introductionText;
    private float introductionAlpha;
    private int scrollIndex;
    private void Awake()
    {
        camera = Camera.main;
        dataManager = new PersistentDataManager();
        run = dataManager.loadRun();
        input = new CursorControl();
        run.currentScene = SceneManager.GetActiveScene().name;
        run.nextScene = SceneManager.GetActiveScene().name;
        if (run.mapProgress == 0)
        {
            introductionAlpha = 3;
        }
        else
        {
            introductionAlpha = 0;
            introductionText.color = new Color(255, 0, 0, introductionAlpha);
        }
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
    private void Start()
    {
        futureLight.intensity = 0;
        input.Mouse.Click.started += _ => click();
        Debug.Log(run.mapProgress);
        if (sorrows != null)
        {
            sorrows.text = "$" + run.sorrows;
        }
        for (int i = 0; i < choicesSpawnPositions.Count; i++)
        {
            LevelPiece actual;
            if ((run.nextEncounters == null) || (run.nextEncounters.Count <= 0))
            {
                LevelPiece encounter = encounters[Random.Range(0, encounters.Count)];
                actual = Instantiate(encounter, choicesSpawnPositions[i]);
                actual.manager = this;
            }
            else
            {
                if (run.nextEncounters[i] != null)
                {
                    LevelPiece encounter = run.nextEncounters[i];
                    actual = Instantiate(encounter, choicesSpawnPositions[i]);
                    actual.manager = this;
                }
                else
                {
                    actual = null;
                }
            }
            if (actual != null)
            {
                if (run.mapProgress < 9)
                {
                    for (int j = 0; j < futureSpawnPositions.Count; j++)
                    {
                        LevelPiece futureEncounter = encounters[Random.Range(0, encounters.Count)];
                        actual.future.Add(futureEncounter);
                    }
                }
                else if (run.mapProgress == 9)
                {
                    actual.future.Add(null);
                    actual.future.Add(bossPiece);
                    actual.future.Add(null);
                }
                else
                {
                    actual.future = null;
                }
            }

        }
        if (run.heldArtifacts != null && run.heldArtifacts.Count != 0)
        {
            for (int i = 0; i < run.heldArtifacts.Count; i++)
            {
                TextBoxOnHover icon = Instantiate(ArtifactIcon, new Vector3(canvas.transform.position.x + (((i * 55) - (330 + (660 * (i / 12)))) * canvas.scaleFactor), canvas.transform.position.y + ((265 - (110 * (i / 12))) * canvas.scaleFactor), canvas.transform.position.z), canvas.transform.rotation, canvas.transform);
                icon.initializeTextBox(run.heldArtifacts[i].getName(), run.heldArtifacts[i].getDiscription(), run.heldArtifacts[i].getArt());
                ArtifactIcons.Add(icon);
            }
        }
        health.text = "Health:" + run.HP + "/" + run.maxHP;
        sanity.text = "Sanity:" + run.sanity;
    }
    public void showDeckUI()
    {
        deckPanel.SetActive(true);
        mapPanel.SetActive(false);
        for (int i = 0; i < run.deck.Count; i++)
        {
            Vector3 cardPosition = new Vector3(canvas.transform.position.x + (((i * 120) - (400 + (840 * (i / 7)))) * canvas.scaleFactor), canvas.transform.position.y + ((200 - (200 * (i / 7))) * canvas.scaleFactor), canvas.transform.position.z);
            EmptyCard tempCard = Instantiate(EmptyUIcard, canvas.transform.position, canvas.transform.rotation, canvas.transform);
            tempCard.transform.position = cardPosition;
            tempCard.setUpCard(run.deck[i]);
            UIdeck.Add(tempCard);
        }
        foreach (TextBoxOnHover icon in ArtifactIcons)
        {
            icon.gameObject.SetActive(false);
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
        foreach (TextBoxOnHover icon in ArtifactIcons)
        {
            icon.gameObject.SetActive(true);
        }
        UIdeck.Clear();
        deckPanel.SetActive(false);
        mapPanel.SetActive(true);
    }
    private void click()
    {
        if (introductionAlpha <= 0)
        {
            Ray ray = camera.ScreenPointToRay(input.Mouse.Position.ReadValue<Vector2>());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<LevelPiece>() != null)
                {
                    if (hit.collider.GetComponent<MysteryPiece>() == null)
                    {
                        LevelPiece encounter = hit.collider.GetComponent<LevelPiece>();
                        run.nextEncounters = encounter.future;
                        run.mapProgress += 1;
                        Debug.Log(run.mapProgress);
                        dataManager.saveRun(run);
                        SceneManager.LoadScene(encounter.getLevel(run));
                    }
                    else
                    {
                        MysteryPiece encounter = hit.collider.GetComponent<MysteryPiece>();
                        run.nextEncounters = encounter.future;
                        run.mapProgress += 1;
                        Debug.Log(run.mapProgress);
                        dataManager.saveRun(run);
                        SceneManager.LoadScene(encounter.getLevel(run));
                    }
                }
            }
        }
    }
    private void Update()
    {
        if (introductionAlpha <= 0)
        {
            Ray ray = camera.ScreenPointToRay(input.Mouse.Position.ReadValue<Vector2>());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<LevelPiece>() != null)
                {
                    if ((futurePieces.Count == 0) && (!hit.collider.GetComponent<LevelPiece>().forShow))
                    {
                        if (run.mapProgress <= 9)
                        {
                            showFuture(hit.collider.GetComponent<LevelPiece>().future);
                        }
                    }
                }
                else if (futurePieces.Count != 0)
                {
                    hideFuture();
                }
            }
        }
        else
        {
            introductionAlpha -= Time.deltaTime;
            introductionText.color = new Color(255, 0, 0, introductionAlpha);
        }
    }
    public void showFuture(List<LevelPiece> future)
    {
        futureLight.intensity = 2;
        for (int i = 0; i < futureSpawnPositions.Count; i++)
        {
            if ((i < future.Count) && (future[i] != null))
            {
                LevelPiece actual = Instantiate(future[i], futureSpawnPositions[i]);
                futurePieces.Add(actual);
            }
        }
    }
    public void hideFuture()
    {
        futureLight.intensity = 0;
        foreach (LevelPiece lp in futurePieces)
        {
            Destroy(lp.gameObject);
        }
        futurePieces.Clear();
    }
}
