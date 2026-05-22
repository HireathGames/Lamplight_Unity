using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelPiece : MonoBehaviour
{
    public MapManager manager;
    public List<LevelPiece> future;
    public string level;
}
