using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* 
Ability ideas:

-Upgrade gun Fire rate
-Upgrade movement speed

 */

public class Abilities : MonoBehaviour
{
    public Shooting shooting;

    public TextMeshProUGUI fireRatePriceText;
    public Image FireRateStar1;
    public Image FireRateStar2;
    public Image FireRateStar3;

    int fireRateLevel = 0;
    int fireRateUpgradeCost = 10;

    private void Start()
    {
        fireRatePriceText.text = fireRateUpgradeCost.ToString();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            heal();
        }
    }


    public void heal()
    {
        if (PlayerHealth.currentHealth < 100 && Coin.Coins > 4)
        {
            PlayerHealth.currentHealth += 5;
            Coin.Coins -= 5;
        }
    }

    public void addFireRate()
    {
        if (fireRateLevel < 3 && Coin.Coins >= fireRateUpgradeCost)
        {
            shooting.coolTime -= 0.1f;
            Coin.Coins -= fireRateUpgradeCost;
            fireRateUpgradeCost = fireRateUpgradeCost * 2;
            fireRatePriceText.text = fireRateUpgradeCost.ToString();
            fireRateLevel++;
        }
        if (fireRateLevel == 1)
        {
            FireRateStar1.color = Color.white;
        }
        if(fireRateLevel == 2)
        {
            FireRateStar2.color = Color.white;
        }
        if (fireRateLevel == 3)
        { 
            FireRateStar3.color = Color.white;
            fireRatePriceText.text = "MAX";
        }

    }

}