using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy: ScriptableObject
{
    public String characterName;
    public Sprite portrait;
    public int LVL = 1;
    public int EXP = 0;
    public int maxHP;
    public int HP;
    public int maxMP;
    public int MP;
    public int ATK;
    public int DEF;
    public int SPD;
    public List<Item> attacks = new List<Item>();
    public virtual void Initialize()
    {
        HP = maxHP;
        MP = maxMP;
    } 
}
