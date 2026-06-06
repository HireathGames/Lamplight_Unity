using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    private PersistentDataManager dataManager;
    private RunData run;
    public GameObject menuScreen;
    public GameObject helpScreen;
    private void Awake()
    {
        dataManager = new PersistentDataManager();
        run = dataManager.loadRun();
    }
    private void Start()
    {
        menuScreen.SetActive(false);
        helpScreen.SetActive(false);
    }
    public void openMenu()
    {
        menuScreen.SetActive(true);
        helpScreen.SetActive(false);
        transform.SetAsLastSibling();
    }
    public void openHelpMenu()
    {
        menuScreen.SetActive(false);
        helpScreen.SetActive(true);
        transform.SetAsLastSibling();
    }
    public void closeMenu()
    {
        menuScreen.SetActive(false);
        helpScreen.SetActive(false);
    }
    public void quit()
    {
        run.currentScene = SceneManager.GetActiveScene().name;
        dataManager.saveRun(run);
        SceneManager.LoadScene("MainMenu");
    }
}
