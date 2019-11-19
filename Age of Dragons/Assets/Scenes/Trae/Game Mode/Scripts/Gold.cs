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

    public GameObject backGround;
    bool flash;
    Color gain;
    Color lost;
    Color orignal;
    Color flashColor;

    float timer = 2;

    private void Start()
    {
        gain = Color.green;
        lost = Color.red;
        orignal = backGround.GetComponent<Image>().color;
        UpdateUI();
    }

    private void Update()
    {
        if (flash)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                flash = false;
                timer = 2;
                backGround.GetComponent<Image>().color = orignal;
            }
            else if( timer < .25f)
            {
                backGround.GetComponent<Image>().color = flashColor;
            }
            else if(timer < .5f)
            {
                backGround.GetComponent<Image>().color = orignal;
            }
            else if (timer < 1f)
            {
                backGround.GetComponent<Image>().color = flashColor;
            }
            else if (timer < 1.5f)
            {
                backGround.GetComponent<Image>().color = orignal;
            }
            else if (timer < 2f)
            {
                backGround.GetComponent<Image>().color = flashColor;
            }
        }
    }

    public void GainGold(int _temp)
    {
        gold += _temp;
        flashColor = gain;
        flash = true;
        UpdateUI();
    }

    public int RemoveGold(int amount)
    {
        gold -= amount;
        flashColor = lost;
        flash = true;
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
