using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Ability ideas:

-Upgrade gun Fire rate
-Upgrade movement speed

 */

public class Abilities : MonoBehaviour
{
    public Shooting shooting;


    int fireRateLevel = 0;
    int fireRateUpgradeCost = 10;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            heal();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            addFireRate();
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
        if (fireRateLevel < 3 && Coin.Coins > fireRateUpgradeCost)
        {
            shooting.coolTime -= 0.1f;
            Coin.Coins -= fireRateUpgradeCost;
            fireRateUpgradeCost = fireRateUpgradeCost * 2;
        }
    }

}