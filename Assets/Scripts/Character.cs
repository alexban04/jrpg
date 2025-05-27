using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character: ScriptableObject
{
    public String characterName;
    public Sprite portrait;
    public int LVL = 1;
    public int EXP = 0;
    public int nextLVLEXP = 100;
    public int maxHP;
    public int HP;
    public int maxMP;
    public int MP;
    public int ATK;
    public int DEF;
    public int SPD;
    public int growthHP;
    public int growthMP;
    public int growthATK;
    public int growthDEF;
    public int growthSPD;
    public List<PlayerItem> inventory = new List<PlayerItem>();
    public List<String> avaiableColors = new List<String>();
    public virtual void Initialize()
    {
        HP = maxHP;
        MP = maxMP;
        nextLVLEXPCalc();
    } 
    public void lvlup()
    {
        LVL++;
        maxHP += growthHP;
        HP += growthHP;
        maxMP += growthMP;
        MP += growthMP;
        ATK += growthATK;
        DEF += growthDEF;
        SPD += growthSPD;
    }
    public void nextLVLEXPCalc()
    {
        nextLVLEXP = LVL * 100;
    }
    public void addItem(PlayerItem item)
    {
        foreach (String color in avaiableColors)
        {
            if (color == item.color)
            {
                inventory.Add(item);
                break;
            }
        }
    }
    public void passiveEffect()
    {
        
    }
    public bool checkColor(String color)
    {
        foreach (String avaiableColor in avaiableColors)
        {
            if (avaiableColor == color) return true;
        }
        return false;
    }
}
