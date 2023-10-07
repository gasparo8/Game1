using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonHealth : MonoBehaviour
{
    public Slider demonSlider;

    public void SetMaxHealthDemon(int health)
    {
        demonSlider.maxValue = health;
        demonSlider.value = health;
    }

    public void SetHealthDemon(int health)
    {
        demonSlider.value = health;
    }
}