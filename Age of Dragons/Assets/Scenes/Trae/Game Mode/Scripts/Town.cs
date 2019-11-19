using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : MonoBehaviour
{
    public float health = 10f;
    float maxHealth = 10f;

    public float gold = 0f;

    public float loyalty = 0f;
    float maxLoyalty = 10f;

    bool underAttack;
    
    public GameObject attacker;
    public GameObject owner;
    public TextMesh goldText;
    public GameObject healthBar;
    public GameObject loyaltyBar;

    int townLevel = 1;
    float upgradeMod = 1;

    public TextMesh townLevelText;

    public GameObject goldCollection;

    GameObject totem;

    private void Start()
    {
        totem = GetComponentInChildren<CapsuleCollider>().gameObject;
        townLevelText.text = "Level: " + townLevel.ToString();
        goldText.text = "Gold: " + gold;
        loyaltyBar.transform.localScale = new Vector3(loyalty, .25f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (underAttack && (owner == null || attacker != owner))
        {
            health = health - (.1f / townLevel);
            healthBar.transform.localScale = new Vector3(health, .25f, 1);

            if(health <= 0)
            {
                Owner();
            }
        }
        else if(owner != null)
        {
            gold += .1f * upgradeMod;
            goldText.text = "Gold: " + gold.ToString("f0");
            loyalty -= .005f * townLevel;
            loyaltyBar.transform.localScale = new Vector3(loyalty, .25f, 1);
            if(loyalty <= 0)
            {
                LoyaltyLost();
            }
        }
        else if(!underAttack && health < maxHealth)
        {
            health = health - (.1f * townLevel);
        }
    }

    void LoyaltyLost()
    {
        owner = null;
        gold = 0f;
    }

    public void ResetLoyalty()
    {
        loyalty = maxLoyalty;
    }

    void Owner()
    {
        if (attacker.GetComponent<Movement>())
        {
            totem.GetComponent<MeshRenderer>().material.color = Color.black;
        }
        else if(attacker.GetComponent<PlayerTwoMove>())
        {
            totem.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        owner = attacker;
        health = maxHealth;
        healthBar.transform.localScale = new Vector3(health, .25f, 1);
    }

    public void AssignAttacker(GameObject _temp)
    {
        attacker = _temp;
        underAttack = true;
    }

    public void RemoveAttacker()
    {
        attacker = null;
        underAttack = false;
    }

    public void PickUpGold()
    {
        owner.GetComponent<Gold>().GainGold(Mathf.RoundToInt(gold));
        Instantiate(goldCollection, owner.transform);
        gold = 0f;
    }

    public void UpgradeTown()
    {
        if(owner != null && owner.GetComponent<Gold>().gold >= townLevel * 100 && townLevel <= 4)
        {
            owner.GetComponent<Gold>().RemoveGold(townLevel * 100);
            townLevel++;
            switch (townLevel)
            {
                case 0:
                    upgradeMod = 1;
                    break;
                case 1:
                    upgradeMod = 1f;
                    break;
                case 2:
                    upgradeMod = 1.2f;
                    break;
                case 3:
                    upgradeMod = 1.5f;
                    break;
                case 4:
                    upgradeMod = 1.8f;
                    break;
                case 5:
                    upgradeMod = 2f;
                    break;
                    
            }
            townLevelText.text = "Level: " + townLevel.ToString();
        }
       
    }
}
