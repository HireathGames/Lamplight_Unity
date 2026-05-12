using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Player player;
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private GameObject UIcard;
    [SerializeField] private List<GameObject> UIcards;
    public void Start()
    {
        enemies = new List<Enemy>(FindObjectsOfType<Enemy>());
        Invoke("spawnCards", 1);
    }
    public void spawnCards()
    {
        for (int i = 0; i < player.getHand().Count; i++)
        {
            Vector3 cardPosition = new Vector3(canvas.transform.position.x + ((i * 160) - (player.getHand().Count * 70)), canvas.transform.position.y - 160, canvas.transform.position.z);
            Instantiate(UIcard, cardPosition, canvas.transform.rotation, canvas.transform);
        }
    }
}
