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
    public void updateUI(Entity entity)
    {           
        healthSlider.maxValue = entity.getMaxHealth();
        healthSlider.value = entity.getHealth();
        armorSlider.maxValue = entity.getMaxHealth();
        armorSlider.value = entity.getArmor();
        sanityText.text = ((int) entity.getSanity()).ToString();
        healthText.text = entity.getHealth() + "/" + entity.getMaxHealth();
        if (entity.getArmor() != 0)
        {
            armorText.text = entity.getArmor().ToString();
        }
        else
        {
            armorText.text = "";
        }
    }
}
