using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UnlockManager : MonoBehaviour
{
    [SerializeField] private GameObject unlockScreen;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image unlockImageArtifact;
    [SerializeField] private Image unlockImageCard;
    [SerializeField] private MainMenuManager manager;
    void Start()
    {
        showUnlock();
    }
    public void showUnlock()
    {
        if (manager.fileData.unlocks != null && manager.fileData.unlocks.Count > 0)
        {
            unlockScreen.SetActive(true);
            if (manager.fileData.unlocks[0].cardCheck())
            {
                unlockImageCard.sprite = manager.fileData.unlocks[0].getArt();
                unlockImageArtifact.gameObject.SetActive(false);
                unlockImageCard.gameObject.SetActive(true);
            }
            else
            {
                unlockImageArtifact.sprite = manager.fileData.unlocks[0].getArt();
                unlockImageArtifact.gameObject.SetActive(true);
                unlockImageCard.gameObject.SetActive(false);
            }
            nameText.text = manager.fileData.unlocks[0].getName();
            manager.fileData.unlocks.RemoveAt(0);
        }
        else
        {
            unlockScreen.SetActive(false);
        }
    }
}
