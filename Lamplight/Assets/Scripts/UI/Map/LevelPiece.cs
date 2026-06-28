using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelPiece : MonoBehaviour
{
    public MapManager manager;
    public List<LevelPiece> future;
    public string[] levels;
    public bool forShow;
    public virtual string getLevel(RunData run)
    {
        int ran = Random.Range(0, levels.Length);
        return (levels[ran]);
    }
}
