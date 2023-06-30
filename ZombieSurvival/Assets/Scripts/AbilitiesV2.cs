using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using Unity.VisualScripting;

public class Shop : MonoBehaviour
{
    public Shooting shooting;
    public PlayerMovement playerMovement;
    public Canvas shopUI;


    [System.Serializable]
    public class Ability
    {
        public string name;
        public string abilityFunctionKey;
        public int cost;
        public int level = 0;

        public TextMeshProUGUI itemNameText;
        public TextMeshProUGUI itemCostText;
        public Image[] stars;
    }

    public Ability[] abilities;

    private Dictionary<string, Action> abilityFunctions;
    private void Awake()
    {
        // Initialize the ability functions dictionary
        abilityFunctions = new Dictionary<string, Action>
        {
            { "fireRate", fireRate},
            { "moveSpeed", moveSpeed}
        };
    }

    private void Start()
    {
        shopUI.enabled = false;
        setUI();
    }

    public void buyAbility(int abilityIndex)
    {
        Ability selectedAbility = abilities[abilityIndex];

        if (Coin.Coins >= selectedAbility.cost && selectedAbility.level < selectedAbility.stars.Length)
        {
            Action abilityFunction = abilityFunctions[selectedAbility.abilityFunctionKey];
            abilityFunction.Invoke();
            Coin.Coins -= selectedAbility.cost;

            selectedAbility.level++;
            selectedAbility.cost *= 2;

            if (selectedAbility.level <= selectedAbility.stars.Length)
            {
                selectedAbility.stars[selectedAbility.level - 1].color = Color.white;
            }

            // Update the cost text
            if (selectedAbility.level >= selectedAbility.stars.Length)
            {
                selectedAbility.itemCostText.text = "Max";
            }
            else
            {
                selectedAbility.itemCostText.text = selectedAbility.cost.ToString();
            }
        }
    }

    void setUI()
    {
        for(int i = 0; i < abilities.Length; i++)
        {
            Ability ability = abilities[i];
            ability.itemNameText.text = ability.name;
            ability.itemCostText.text = ability.cost.ToString();
        }
    }


    void fireRate()
    {
        shooting.coolTime -= 0.1f;
    }

    void moveSpeed()
    {
        playerMovement.speed += 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ShowShop();
        }
    }

    void ShowShop()
    {
        shopUI.enabled = !shopUI.enabled;

        if (shopUI.enabled )
        {
            shooting.enabled = false;
        }
        else
        {
            shooting.enabled = true;
        }

    }
}
