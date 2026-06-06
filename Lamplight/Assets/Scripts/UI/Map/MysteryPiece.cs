using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MysteryPiece : LevelPiece
{
    public string[] alternateDestinations;
    public string getLevel(RunData run)
    {
        float ran = Random.Range(0f, 1f);
        if (ran < 0.6f)
        {
            if (run.events.Count != 0)
            {
                return level;
            }            
            else
            {
                Debug.Log("Ranout");
                return alternateDestinations[0];
            }
        }
        else if (ran < 0.85f)
        {
            return alternateDestinations[0];
        }
        else if (ran < 0.95f)
        {
            return alternateDestinations[1];
        }
        else
        {
            return alternateDestinations[2];
        }

    }
}
