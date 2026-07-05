using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EventManager : MonoBehaviour
{
    private PersistentDataManager manager = new PersistentDataManager();
    private RunData run;
    private Event currentEvent;
    public TMP_Text discription;
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;
    public TMP_Text health;
    public TMP_Text sanity;
    public Image image;
    public GameObject option1_button;
    public GameObject option2_button;
    public GameObject option3_button;
    public GameObject exit_button;
    private void Awake()
    {
        run = manager.loadRun();
        int ran = Random.Range(0, run.events.Count);
        Debug.Log(run.events.Count);
        if (ran >= 0 && ran < run.events.Count)
        {
            currentEvent = run.events[ran];
        }
        run.events.Remove(currentEvent);
    }
    private void Start()
    {
        if (currentEvent != null)
        {
            discription.text = currentEvent.getDiscription();
            option1.text = currentEvent.getOptions()[0];
            option2.text = currentEvent.getOptions()[1];
            option3.text = currentEvent.getOptions()[2];
            image.sprite = currentEvent.getArt();
            option1_button.SetActive(true);
            option2_button.SetActive(true);
            if (currentEvent.isSpecialCharacter(run.character))
            {
                option3_button.SetActive(true);
            }
            else
            {
                option3_button.SetActive(false);
            }
            exit_button.SetActive(false);
        }
        else
        {
            option1_button.SetActive(false);
            option2_button.SetActive(false);
            option3_button.SetActive(false);
            exit_button.SetActive(true);
        }
    }
    private void Update()
    {
        health.text = "Health:" + run.HP + "/" + run.maxHP;
        sanity.text = "Sanity:" + run.sanity;
    }
    public void choice_1()
    {
        currentEvent.optionOne(run);
        discription.text = currentEvent.getOutcomes()[0];
        option1_button.SetActive(false);
        option2_button.SetActive(false);
        option3_button.SetActive(false);
        exit_button.SetActive(true);
    }
    public void choice_2()
    {
        currentEvent.optionTwo(run);
        discription.text = currentEvent.getOutcomes()[1];
        option1_button.SetActive(false);
        option2_button.SetActive(false);
        option3_button.SetActive(false);
        exit_button.SetActive(true);
    }
    public void choice_3()
    {
        currentEvent.optionThree(run);
        discription.text = currentEvent.getOutcomes()[2];
        option1_button.SetActive(false);
        option2_button.SetActive(false);
        option3_button.SetActive(false);
        exit_button.SetActive(true);
    }
    public void leave()
    {
        manager.saveRun(run);
        SceneManager.LoadScene(run.nextScene);
    }
}
