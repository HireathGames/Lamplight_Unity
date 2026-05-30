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
