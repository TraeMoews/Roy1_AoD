using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public int gold;
    public Text holdingGoldText;
    public int hoardGold;
    public Text hoardGoldText;

    private void Start()
    {
        UpdateUI();
    }

    public void GainGold(int _temp)
    {
        gold += _temp;
        UpdateUI();
    }

    public int RemoveGold(int amount)
    {
        gold -= amount;
        UpdateUI();
        return gold;
    }

    public void GainHoardGold()
    {
        hoardGold += gold;
        gold = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        hoardGoldText.text = "Hoard Gold: " + hoardGold;
        holdingGoldText.text = "Gold: " + gold;
    }
}
