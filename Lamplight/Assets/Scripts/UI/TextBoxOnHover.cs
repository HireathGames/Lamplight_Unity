using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class TextBoxOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public GameObject textBox;
    public TMP_Text nameText;
    public TMP_Text discText;
    private ShopManager manager;
    [SerializeField] private string name;
    [SerializeField] private string disc;
    void Start()
    {
        textBox.SetActive(false);
        manager = FindAnyObjectByType<ShopManager>();
    }
    public void initializeTextBox(string n, string d)
    {
        name = n;
        disc = d;
    }
    public void initializeTextBox(string n, string d, Sprite sprite)
    {
        name = n;
        disc = d;
        if (gameObject.GetComponent<Image>() != null)
        {
            gameObject.GetComponent<Image>().sprite = sprite;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textBox.SetActive(true);
        nameText.text = name;
        discText.text = disc;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textBox.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (manager != null)
        {
            manager.buyArtifact();
        }
    }
}
