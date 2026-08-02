using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamIntegration : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        try
        {
            Steamworks.SteamClient.Init(4951430);
        }
        catch(System.Exception e)
        {
            Debug.Log(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Steamworks.SteamClient.RunCallbacks();
    }
    private void OnApplicationQuit()
    {
        Steamworks.SteamClient.Shutdown();
    }
    public void unlockAchievement(string id)
    {
        var ach = new Steamworks.Data.Achievement(id);
        if (!ach.State)
        {
            ach.Trigger();
            Debug.Log(id);
        }
    }
    public void debugClearAchievement(string id)
    {
        var ach = new Steamworks.Data.Achievement(id);
        ach.Clear();
        Debug.Log(id);
    }
}
