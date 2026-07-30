using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PersistentDataManager
{
    private string runFileName = "game.current";
    private string saveFileFileName = "game.save";
    private string directPath;

    public static void unlockChecks(SaveFileData saveFile, RunData run)
    {
        saveFile.unlocks = new List<Unlock>();
        if (!saveFile.characterUnlocks[1])
        {
            saveFile.characterUnlocks[1] = true;
            saveFile.unlocks.Add(new Unlock("Victor Frankenstein", Resources.Load<Sprite>("Sprites/Characters/Frankenstein")));
        }
        if (!saveFile.characterUnlocks[2])
        {
            HashSet<Char> elements = new HashSet<char>();
            foreach(Card card in run.deck)
            {
                elements.Add(card.getType());
            }
            Debug.Log(elements.Count);
            if (elements.Count >= 4)
            {
                saveFile.characterUnlocks[2] = true;
                saveFile.unlocks.Add(new Unlock("Dr. Jekyll & Mr. Hyde", Resources.Load<Sprite>("Sprites/Characters/Jekyll")));
            }
        }
        if (run.progessionLevel >= 2)
        {
            if (!childExist<Card, Determination>(saveFile.basicLegendaryRewards))
            {
                saveFile.basicLegendaryRewards.Add(new Determination());
                saveFile.unlocks.Add(new Unlock(new Determination()));
            }
            if (run.character.Equals("JH"))
            {
                if (!childExist<Card, Judgment>(saveFile.harkerLegendaryRewards))
                {
                    saveFile.harkerLegendaryRewards.Add(new Judgment());
                    saveFile.unlocks.Add(new Unlock(new Judgment()));
                }
            }
            else if (run.character.Equals("VF"))
            {
                if (!childExist<Card, Melancholia>(saveFile.frankensteinLegendaryRewards))
                {
                    saveFile.frankensteinLegendaryRewards.Add(new Melancholia());
                    saveFile.unlocks.Add(new Unlock(new Melancholia()));
                }
            }
            else if (run.character.Equals("HJ&EH"))
            {
                if (!childExist<Card, DoubleLife>(saveFile.jekyllLegendaryRewards))
                {
                    saveFile.jekyllLegendaryRewards.Add(new DoubleLife());
                    saveFile.unlocks.Add(new Unlock(new DoubleLife()));
                }
            }
            else if (run.character.Equals("DG"))
            {
                if (!childExist<Card, PrinceCharming>(saveFile.dorianLegendaryRewards))
                {
                    saveFile.dorianLegendaryRewards.Add(new PrinceCharming());
                    saveFile.unlocks.Add(new Unlock(new PrinceCharming()));
                }
            }
            if (run.progessionLevel >= 3)
            {
                if (!childExist<Artifact, AbsintheArtifact>(saveFile.shopArtifacts))
                {
                    saveFile.shopArtifacts.Add(new AbsintheArtifact());
                    saveFile.unlocks.Add(new Unlock(new AbsintheArtifact()));
                }
                if (run.character.Equals("JH"))
                {
                    if (!childExist<Artifact, CrucifixArtifact>(saveFile.shopArtifacts))
                    {
                        saveFile.shopArtifacts.Add(new CrucifixArtifact());
                        saveFile.unlocks.Add(new Unlock(new CrucifixArtifact()));
                    }
                }
                else if (run.character.Equals("VF"))
                {
                    if (!childExist<Artifact, BunsenBurnerArtifact>(saveFile.shopArtifacts))
                    {
                        saveFile.shopArtifacts.Add(new BunsenBurnerArtifact());
                        saveFile.unlocks.Add(new Unlock(new BunsenBurnerArtifact()));
                    }
                }
                else if (run.character.Equals("HJ&EH"))
                {
                    if (!childExist<Artifact, ChemicalSaltArtifact>(saveFile.shopArtifacts))
                    {
                        saveFile.shopArtifacts.Add(new ChemicalSaltArtifact());
                        saveFile.unlocks.Add(new Unlock(new ChemicalSaltArtifact()));
                    }
                }
                else if (run.character.Equals("DG"))
                {
                    if (!childExist<Artifact, PaletteKnifeArtifact>(saveFile.shopArtifacts))
                    {
                        saveFile.shopArtifacts.Add(new PaletteKnifeArtifact());
                        saveFile.unlocks.Add(new Unlock(new PaletteKnifeArtifact()));
                    }
                }
                if (run.progessionLevel >= 4)
                {
                    if (!saveFile.characterUnlocks[3])
                    {
                        saveFile.characterUnlocks[3] = true;
                        saveFile.unlocks.Add(new Unlock("Dorian Gray", Resources.Load<Sprite>("Sprites/Characters/Dorian")));
                    }
                }
            }
        }
    }
    public static bool childExist <T, t> (List<T> list)
    {
        foreach (T elem in list)
        {
            if (elem is t)
            {
                return true;
            }
        }
        return false;
    } 
    public void setUp()
    {
        directPath = Application.persistentDataPath;
    }
    public RunData loadRun()
    {
        //Loads the current run's data from a json file
        setUp();
        string fullPath = Path.Combine(directPath, runFileName);
        RunData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<RunData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data to file: " + fullPath + e);
            }
        }
        return loadedData;
    }
    public bool saveRun(RunData run)
    {
        //Saves the current run as a json file
        setUp();
        string fullPath = Path.Combine(directPath, runFileName);
        Debug.Log(fullPath);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToStore = JsonUtility.ToJson(run, true);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                    return true;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return false;
        }
    }
    public SaveFileData loadFile()
    {
        //Loads the saveFiles data from a json file
        setUp();
        string fullPath = Path.Combine(directPath, saveFileFileName);
        SaveFileData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<SaveFileData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data to file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }
    public bool saveFileExists()
    {
        setUp();
        string fullPath = Path.Combine(directPath, saveFileFileName);
        if (File.Exists(fullPath))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool saveFile(SaveFileData save)
    {
        //Saves the save file as a json file
        setUp();
        string fullPath = Path.Combine(directPath, saveFileFileName);
        Debug.Log(fullPath);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToStore = JsonUtility.ToJson(save, true);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                    return true;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return false;
        }
    }
}
