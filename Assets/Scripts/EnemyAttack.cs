using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy Attack", menuName = "RPG/Enemy Attack")]

public class EnemyAttack: Item
{
    public int damage;
    public int cost;
    public override void Initialize()
    {
        base.Initialize();
    }
}
