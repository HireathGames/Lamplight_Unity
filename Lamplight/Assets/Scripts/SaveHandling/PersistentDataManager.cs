using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PersistentDataManager
{
    private string fileName = "game.current";
    private string directPath = Application.persistentDataPath;
    public RunData loadRun()
    {
        //Loads the current run's data from a json file
        string fullPath = Path.Combine(directPath, fileName);
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
        string fullPath = Path.Combine(directPath, fileName);
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
}
