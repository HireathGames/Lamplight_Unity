using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndingManager : MonoBehaviour
{
    private PersistentDataManager manager;
    private RunData run;
    private SaveFileData fileData;
    private string achievement;
    [SerializeField] private SteamIntegration steam;
    [SerializeField] private Animator animator;
    [SerializeField] private float[] times;

    [SerializeField] private float[] soundDelayHarker;
    [SerializeField] private float[] soundDelayVictor;
    [SerializeField] private float[] soundDelayJekyll;
    [SerializeField] private float[] soundDelayDorian;
    [SerializeField] private AudioSource[] soundHarker;
    [SerializeField] private AudioSource[] soundVictor;
    [SerializeField] private AudioSource[] soundJekyll;
    [SerializeField] private AudioSource[] soundDorian;
    void Start()
    {
        manager = new PersistentDataManager();
        run = manager.loadRun();
        fileData = manager.loadFile();
        run.progessionLevel = 4;
        PersistentDataManager.unlockChecks(fileData, run);
        if (run.character.Equals("JH"))
        {
            animator.SetInteger("Ending", 0);
            playHarker();
            achievement = "HARKER_WIN";
            Invoke("exit", times[0]);
        }
        else if (run.character.Equals("VF"))
        {
            animator.SetInteger("Ending", 1);
            playVictor();
            achievement = "FRANKENSTEIN_WIN";
            Invoke("exit", times[1]);
        }
        else if (run.character.Equals("HJ&EH"))
        {
            animator.SetInteger("Ending", 2);
            playJekyll();
            achievement = "HARKER_JEKYLL";
            Invoke("exit", times[2]);
        }
        else if (run.character.Equals("DG"))
        {
            animator.SetInteger("Ending", 3);
            playDorian();
            achievement = "DORIAN_WIN";
            Invoke("exit", times[3]);
        }
    }
    private void exit()
    {
        manager.saveRun(null);
        manager.saveFile(fileData);
        steam.unlockAchievement(achievement);
        SceneManager.LoadScene("MainMenu");
    }
    private void playHarker()
    {
        for (int i = 0; i < soundHarker.Length; i++)
        {
            if (soundDelayHarker.Length > i)
            {
                soundHarker[i].PlayDelayed(soundDelayHarker[i]);
            }
            else
            {
                break;
            }
        }
    }
    private void playVictor()
    {
        for (int i = 0; i < soundVictor.Length; i++)
        {
            if (soundDelayVictor.Length > i)
            {
                soundVictor[i].PlayDelayed(soundDelayVictor[i]);
            }
            else
            {
                break;
            }
        }
    }
    private void playJekyll()
    {
        for (int i = 0; i < soundJekyll.Length; i++)
        {
            if (soundDelayJekyll.Length > i)
            {
                soundJekyll[i].PlayDelayed(soundDelayJekyll[i]);
            }
            else
            {
                break;
            }
        }
    }
    private void playDorian()
    {
        for (int i = 0; i < soundDorian.Length; i++)
        {
            if (soundDelayDorian.Length > i)
            {
                soundDorian[i].PlayDelayed(soundDelayDorian[i]);
            }
            else
            {
                break;
            }
        }
    }
}
