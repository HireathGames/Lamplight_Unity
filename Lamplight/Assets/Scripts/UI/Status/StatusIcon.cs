using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public abstract class StatusIcon : MonoBehaviour
{
    public TMP_Text number;
    public Image image;
    public abstract bool updateState(Entity entity);
    public void visibility(bool vis)
    {
        image.gameObject.SetActive(vis);
        number.gameObject.SetActive(vis);
    }
}
