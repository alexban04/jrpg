using System;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Item : ScriptableObject
{
    public String name;
    public String color;
    public String effect;
    public virtual void Initialize()
    {
        
    }
}
