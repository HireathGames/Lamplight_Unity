using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MysteryPiece : LevelPiece
{
    public override string getLevel(RunData run)
    {
        float ran = Random.Range(0f, 1f);
        if (ran < 0.6f)
        {
            if (run.events.Count != 0)
            {
                return levels[0];
            }            
            else
            {
                return levels[1];
            }
        }
        else if (ran < 0.75f)
        {
            return levels[1];
        }
        else if (ran < 0.85f)
        {
            return levels[2];
        }
        else if (ran < 0.95f)
        {
            return levels[3];
        }
        else
        {
            return levels[4];
        }

    }
}
