using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManaBar : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;
    float health = 100f;
    float maxhealth = 100f;
    float lerpSpeed;
    private void Start()
    {
        health = maxhealth;
    }
    private void Update()
    {
        healthText.text = "Health: " + health + "%";
        if (health > maxhealth) health = maxhealth;
        lerpSpeed = 3f * Time.deltaTime;
        HealthBarFiller();
        ColorChanger();
    }
    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxhealth, lerpSpeed);
    }
    void ColorChanger()
    {
        Color healthcolor = Color.Lerp(Color.red, Color.green, (health / maxhealth));
        healthBar.color = healthcolor;
    }

    public void Damage(float damageAmount)
    {
        if(health > 0)
        {
            health -= damageAmount;
        }
    }
    public void Heal(float healAmount)
    {
        if (health < maxhealth)
        {
            health += healAmount;
        }
    }

}
