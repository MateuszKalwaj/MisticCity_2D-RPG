﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour {

    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseEXP = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int[] mpLvlBonus;
    public int strength;
    public int defence;
    public int wpnPwr;
    public int armorPwr;
    public string equippedWpn;
    public string equippedArmor;
    public Sprite charImage;

    // Start is called before the first frame update
    void Start() {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for(int i = 2; i < expToNextLevel.Length; i++) {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update() {
        //testing player leveling

        if(Input.GetKeyDown(KeyCode.K)) {
            AddExp(1000);
        }
        
    }

    public void AddExp(int expToAdd) {
        currentEXP += expToAdd;

        if(playerLevel < maxLevel) {

            if(currentEXP > expToNextLevel[playerLevel]) {
                currentEXP -= expToNextLevel[playerLevel];
                playerLevel++;

                //if there's even number-add strength, if odd-add defence
                if(playerLevel%2 == 0) {
                    strength++;
                } else {
                    defence++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f); //int*float possible because of Mathf.FloorToInt
                currentHP = maxHP;

                maxMP += mpLvlBonus[playerLevel];
                currentMP = maxMP;
            }
        }

        if(playerLevel >= maxLevel) {
            currentEXP = 0;
        }
    }
}
