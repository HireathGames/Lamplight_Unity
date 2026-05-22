using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class EntityHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider armorSlider;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text armorText;
    [SerializeField] private TMP_Text sanityText;
    [SerializeField] private List<StatusIcon> statuses;
    [SerializeField] private bool player = false;
    public void updateUI(Entity entity)
    {           
        if (entity != null)
        {
            healthSlider.maxValue = entity.getMaxHealth();
            healthSlider.value = entity.getHealth();
            armorSlider.maxValue = entity.getMaxHealth();
            armorSlider.value = entity.getArmor();
            sanityText.text = ((int)entity.getSanity()).ToString();
            healthText.text = entity.getHealth() + "/" + entity.getMaxHealth();
            if (entity.getArmor() != 0)
            {
                armorText.text = entity.getArmor().ToString();
            }
            else
            {
                armorText.text = "";
            }
            statusCheck(entity);
        }
    }
    public void statusCheck(Entity entity)
    {
        if (entity != null)
        {
            List<StatusIcon> visibleStats = new List<StatusIcon>();
            foreach (StatusIcon status in statuses)
            {
                if (status != null)
                {
                    bool b = status.updateState(entity);
                    status.visibility(b);
                    if (b)
                    {
                        visibleStats.Add(status);
                    }
                }
            }
            for (int i = 0; i < visibleStats.Count; i++)
            {
                if (player)
                {
                    visibleStats[i].transform.localPosition = new Vector3(-70.0f + ((140.0f / 3.0f) * (i - (4 * (i / 4)))), -35 * (1 + (i / 4)), 0);
                }
                else
                {
                    visibleStats[i].transform.localPosition = new Vector3(-35.0f + ((105.0f / 2.0f) * (i - (3 * (i / 3)))), -35 * (1 + (i / 3)), 0);
                }
            }
        }
    }
}
