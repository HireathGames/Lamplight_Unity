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
    [SerializeField] private Animator animator;
    [SerializeField] private float[] times;
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
            Invoke("exit", times[0]);
        }
        else if (run.character.Equals("VF"))
        {
            animator.SetInteger("Ending", 1);
            Invoke("exit", times[1]);
        }
        else if (run.character.Equals("HJ&EH"))
        {
            animator.SetInteger("Ending", 2);
            Invoke("exit", times[2]);
        }
        else if (run.character.Equals("DG"))
        {
            animator.SetInteger("Ending", 3);
            Invoke("exit", times[3]);
        }
    }
    private void exit()
    {
        manager.saveRun(null);
        manager.saveFile(fileData);
        SceneManager.LoadScene("MainMenu");
    }
}
