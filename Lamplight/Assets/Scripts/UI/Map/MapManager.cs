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
    [SerializeField] private Light futureLight;
    [SerializeField] private List<Transform> choicesSpawnPositions;
    [SerializeField] private List<Transform> futureSpawnPositions;
    public Camera camera;
    private CursorControl input;
    private PersistentDataManager dataManager;
    private RunData run;
    [SerializeField] private List<EmptyCard> UIdeck = new List<EmptyCard>();
    [SerializeField] private EmptyCard EmptyUIcard;
    [SerializeField] private GameObject deckPanel;
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private TMP_Text sorrows;
    [SerializeField] private Canvas canvas;
    private int scrollIndex;
    private void Awake()
    {
        camera = Camera.main;
        dataManager = new PersistentDataManager();
        run = dataManager.loadRun();
        input = new CursorControl();
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
                LevelPiece encounter = run.nextEncounters[i];
                actual = Instantiate(encounter, choicesSpawnPositions[i]);
                actual.manager = this;
            }
            for (int j = 0; j < futureSpawnPositions.Count; j++)
            {
                LevelPiece futureEncounter = encounters[Random.Range(0, encounters.Count)];
                actual.future.Add(futureEncounter);
            }
        }
    }
    public void showDeckUI()
    {
        deckPanel.SetActive(true);
        mapPanel.SetActive(false);
        for (int i = 0; i < run.deck.Count; i++)
        {
            Vector3 cardPosition = new Vector3(canvas.transform.position.x + (i * 120) - (400 + (840 * (i / 7))), canvas.transform.position.y + 200 - (200 * (i / 7)), canvas.transform.position.z);
            EmptyCard tempCard = Instantiate(EmptyUIcard, canvas.transform.position, canvas.transform.rotation, canvas.transform);
            tempCard.transform.position = cardPosition;
            tempCard.setUpCard(run.deck[i]);
            UIdeck.Add(tempCard);
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
        mapPanel.SetActive(true);
    }
    private void click()
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
                    dataManager.saveRun(run);
                    SceneManager.LoadScene(encounter.level);
                }
                else
                {
                    MysteryPiece encounter = hit.collider.GetComponent<MysteryPiece>();
                    run.nextEncounters = encounter.future;
                    dataManager.saveRun(run);
                    SceneManager.LoadScene(encounter.getLevel(run));
                }
            }
        }
    }
    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(input.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<LevelPiece>() != null) 
            {
                if ((futurePieces.Count == 0) && (!hit.collider.GetComponent<LevelPiece>().forShow))
                {
                    showFuture(hit.collider.GetComponent<LevelPiece>().future);
                }
            }
            else if (futurePieces.Count != 0)
            {
                hideFuture();
            }
        }
    }
    public void showFuture(List<LevelPiece> future)
    {
        futureLight.intensity = 2;
        for (int i = 0; i < futureSpawnPositions.Count; i++)
        {
            LevelPiece actual = Instantiate(future[i], futureSpawnPositions[i]);
            futurePieces.Add(actual);
        }
        Debug.Log(futurePieces.Count);
    }
    public void hideFuture()
    {
        futureLight.intensity = 0;
        foreach (LevelPiece lp in futurePieces)
        {
            Destroy(lp.gameObject);
        }
        futurePieces.Clear();
        Debug.Log(futurePieces.Count);
    }
}
