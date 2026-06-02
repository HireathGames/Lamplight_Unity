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
    public void loadOut()
    {
        if (!reversing)
        {
            reversing = true;
            Invoke("exit", 1.25f);
        }
    }
    public void exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
