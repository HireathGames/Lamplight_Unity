using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private void click()
    {
        Ray ray = camera.ScreenPointToRay(input.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<LevelPiece>() != null)
            {
                LevelPiece encounter = hit.collider.GetComponent<LevelPiece>();
                run.nextEncounters = encounter.future;
                dataManager.saveRun(run);
                SceneManager.LoadScene(encounter.level);
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
                if (futurePieces.Count == 0)
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
    }
    public void hideFuture()
    {
        futureLight.intensity = 0;
        for (int i = 0; i < futureSpawnPositions.Count; i++)
        {
            Destroy(futurePieces[0]);
            futurePieces.RemoveAt(0);
        }
    }
}
