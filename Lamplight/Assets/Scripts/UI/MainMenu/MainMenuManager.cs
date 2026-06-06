using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    private PersistentDataManager dataManager;
    private RunData run;
    private SaveFileData fileData;
    [SerializeField] private string[] characterNames;
    [SerializeField] private string[] characterDiscription;
    private int characterIndex;
    private int rotationTracker;
    public TMP_Text nameText;
    public TMP_Text discText;
    public RunStartManager runStartManager;
    public GameObject continueButton;
    public GameObject title;
    public GameObject select;
    public Transform rotator;
    public Camera titleCam;
    public Camera selectCam;
    private void Awake()
    {
        dataManager = new PersistentDataManager();
        run = dataManager.loadRun();
        if (dataManager.saveFileExists())
        {
            fileData = dataManager.loadFile();
        }
        else
        {
            fileData = new SaveFileData();
            dataManager.saveFile(fileData);
        }
    }
    void Start()
    {
        selectCam.enabled = false;
        title.SetActive(true);
        select.SetActive(false);
        if ((run != null) && (run.currentScene != null) && (run.currentScene.Length != 0) && (SceneManager.GetSceneByName(run.currentScene) != null) && (run.HP > 0))
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }
    public void continueRun()
    {
        if ((run != null) && (run.currentScene != null) && (run.currentScene.Length != 0) && (SceneManager.GetSceneByName(run.currentScene) != null) && (run.HP > 0))
        {
            SceneManager.LoadScene(run.currentScene);
        }
    }
    public void openCharacterSelectionScreen()
    {
        selectCam.enabled = true;
        titleCam.enabled = false;
        title.SetActive(false);
        select.SetActive(true);
        characterIndex = 0;
        rotator.rotation = new Quaternion(0, 0, 0, 0);
        rotationTracker = 0;
        nameText.text = characterNames[0];
        discText.text = characterDiscription[0];
    }
    public void openTitle()
    {
        selectCam.enabled = false;
        titleCam.enabled = true;
        title.SetActive(true);
        select.SetActive(false);
    }
    public void selectedCharacter()
    {
        if (characterIndex == 0)
        {
            runStartManager.startHarkerRun();
        }
        else if (characterIndex == 1)
        {
            runStartManager.startFrankensteinRun();
        }
        else if (characterIndex == 2)
        {
            runStartManager.startJekyllRun();
        }
        else if (characterIndex == 3)
        {
            runStartManager.startDorianRun();
        }
    }
    public void rotate(int direction)
    {
        characterIndex += direction;
        if (characterIndex < 0)
        {
            characterIndex = 3;
        }
        else if (characterIndex > 3)
        {
            characterIndex = 0;
        }
        rotator.Rotate(new Vector3(0, 90 * direction, 0));
        nameText.text = characterNames[characterIndex];
        discText.text = characterDiscription[characterIndex];
    }
    public void quit()
    {
        Application.Quit();
    }
}
