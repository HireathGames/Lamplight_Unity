using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class RestManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public Camera camera;
    public ParticleSystem system;
    private CursorControl input;
    private PersistentDataManager dataManager;
    private RunData run;
    [SerializeField] private Collider lamp;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject choicePanel;
    [SerializeField] private GameObject forgetPanel;
    [SerializeField] private Image fadeOut;
    private bool fadingOut;
    private float alpha;
    private int scrollIndex;
    [SerializeField] private RestCardUI restCard;
    private List<RestCardUI> UIdeck = new List<RestCardUI>();
    public bool draging;
    public int activeCard;
    
    private void Awake()
    {
        camera = Camera.main;
        dataManager = new PersistentDataManager();
        run = dataManager.loadRun();
        input = new CursorControl();
    }
    private void Start()
    {
        forgetPanel.SetActive(false);
        choicePanel.SetActive(true);
        input.Mouse.Click.performed += _ => endClick();//Lamda expression 
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void endClick()
    {
        if (draging && !fadingOut)
        {
            //Fires a ray then checks if it hits an object and whether it was an enemy or the player
            Ray ray = camera.ScreenPointToRay(input.Mouse.Position.ReadValue<Vector2>());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.collider != null) && (hit.collider == lamp))
                {
                    run.deck.RemoveAt(activeCard);
                    fadingOut = true;
                    system.Play();
                    foreach (RestCardUI card in UIdeck)
                    {
                        Destroy(card.gameObject);
                    }
                    Invoke("exit", 1);
                }
            }
        }
    }
    public void restore()
    {
        if (!fadingOut)
        {
            run.HP += run.maxHP / 4;
            if (run.HP > run.maxHP)
            {
                run.HP = run.maxHP;
            }
            run.sanity = 100f;
            fadingOut = true;
            Invoke("exit", 1);
        }
    }
    private void Update()
    {
        if (fadingOut)
        {
            alpha += (Time.deltaTime * 2);
            Color c = new Color(0, 0, 0, alpha);
            fadeOut.color = c;
        }
    }
    public void openForgetMenu()
    {
        forgetPanel.SetActive(true);
        choicePanel.SetActive(false);
        animator.SetBool("State", true);
        for (int i = 0; i < run.deck.Count; i++)
        {
            Vector3 cardPosition = new Vector3(canvas.transform.position.x + (i * 120) + (500 * (i / 2)) - (425 + (1480 * (i / 4))), canvas.transform.position.y + 200 - (200 * (i / 4)), canvas.transform.position.z);
            RestCardUI tempCard = Instantiate(restCard, canvas.transform.position, canvas.transform.rotation, canvas.transform);
            tempCard.transform.position = cardPosition;
            tempCard.setUpCard(cardPosition, tempCard.transform.rotation, tempCard.transform.localScale, run.deck[i], this, i);
            UIdeck.Add(tempCard);
        }
    }
    public void scroll(int direction)
    {
        if (UIdeck.Count != 0)
        {
            if (((direction + scrollIndex) >= 0) && ((direction + scrollIndex) <= UIdeck.Count / 4))
            {
                foreach (RestCardUI card in UIdeck)
                {
                    card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y + (direction * 200), card.transform.position.z);
                }
                scrollIndex += direction;
            }
        }
    }
    public void closeForgetMenu()
    {
        animator.SetBool("State", false);
        foreach (RestCardUI card in UIdeck)
        {
            Destroy(card.gameObject);
        }
        UIdeck.Clear();
        forgetPanel.SetActive(false);
        choicePanel.SetActive(true);
    }
    private void exit()
    {
        dataManager.saveRun(run);
        SceneManager.LoadScene("Level_1_Map");
    }
}
