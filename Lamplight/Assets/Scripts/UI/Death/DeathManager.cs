using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class DeathManager : MonoBehaviour
{
    public GameObject hourHand;
    public GameObject minuteHand;
    public Image fadeOut;
    public AudioSource music;
    private float alpha;
    private float speed = -1;
    private bool reversing;
    private PersistentDataManager manager;
    private RunData run;
    private SaveFileData saveFile;
    // Update is called once per frame
    void Update()
    {
        hourHand.transform.Rotate(new Vector3((Time.deltaTime * 6) * speed, 0, 0));
        minuteHand.transform.Rotate(new Vector3((Time.deltaTime * 360) * speed, 0, 0));
        if (reversing)
        {
            speed += Time.deltaTime * 30;
            alpha += Time.deltaTime / 1.25f;
            music.pitch -= Time.deltaTime * 5.5f;
            fadeOut.color = new Color(255, 255, 255, alpha);
        }
    }
    private void Start()
    {
        manager = new PersistentDataManager();
        run = manager.loadRun();
        saveFile = manager.loadFile();
    }
    public void loadOut()
    {
        if (!reversing)
        {
            reversing = true;
            unlockChecks();
            Invoke("exit", 1.25f);
        }
    }
    public void unlockChecks ()
    {
        if (run.progessionLevel == 3)
        {
            if (!saveFile.shopArtifacts.Contains(new AbsintheArtifact()))
            {
                saveFile.shopArtifacts.Add(new AbsintheArtifact());
                saveFile.unlocks.Add(new Unlock(new AbsintheArtifact()));
            }
            if (run.character.Equals("JH"))
            {
                if (!saveFile.shopArtifacts.Contains(new CrucifixArtifact()))
                {
                    saveFile.shopArtifacts.Add(new CrucifixArtifact());
                    saveFile.unlocks.Add(new Unlock(new CrucifixArtifact()));
                }
            }
            else if (run.character.Equals("VF"))
            {

            }
            else if (run.character.Equals("HJ&EH"))
            {
                if (!saveFile.shopArtifacts.Contains(new ChemicalSaltArtifact()))
                {
                    saveFile.shopArtifacts.Add(new ChemicalSaltArtifact());
                    saveFile.unlocks.Add(new Unlock(new ChemicalSaltArtifact()));
                }
            }
            else if (run.character.Equals("DG"))
            {

            }
        }
        else if (run.progessionLevel == 2)
        {
            if (!saveFile.basicLegendaryRewards.Contains(new Determination()))
            {
                saveFile.basicLegendaryRewards.Add(new Determination());
                saveFile.unlocks.Add(new Unlock(new Determination()));
            }
            if (run.character.Equals("JH"))
            {
                if (!saveFile.harkerLegendaryRewards.Contains(new Judgment()))
                {
                    saveFile.harkerLegendaryRewards.Add(new Judgment());
                    saveFile.unlocks.Add(new Unlock(new Judgment()));
                }
            }
            else if (run.character.Equals("VF"))
            {
                if (!saveFile.frankensteinLegendaryRewards.Contains(new Melancholia()))
                {
                    saveFile.frankensteinLegendaryRewards.Add(new Melancholia());
                    saveFile.unlocks.Add(new Unlock(new Melancholia()));
                }
            }
            else if (run.character.Equals("HJ&EH"))
            {
                if (!saveFile.jekyllLegendaryRewards.Contains(new DoubleLife()))
                {
                    saveFile.jekyllLegendaryRewards.Add(new DoubleLife());
                    saveFile.unlocks.Add(new Unlock(new DoubleLife()));
                }
            }
            else if (run.character.Equals("DG"))
            {
                if (!saveFile.dorianLegendaryRewards.Contains(new PrinceCharming()))
                {
                    saveFile.dorianLegendaryRewards.Add(new PrinceCharming());
                    saveFile.unlocks.Add(new Unlock(new PrinceCharming()));
                }
            }
        }

    }
    public void exit()
    {
        manager.saveRun(null);
        manager.saveFile(saveFile);
        SceneManager.LoadScene("MainMenu");
    }
}
