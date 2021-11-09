using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMaxHealth(float health)
    {
        slider.value = health;
        slider.minValue = 0;
        slider.maxValue = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void TakeDamage(float damage)
    {
        slider.value -= damage;
    }

    public void UseHealthPotion(float health)
    {
        slider.value += health;
    }

}
