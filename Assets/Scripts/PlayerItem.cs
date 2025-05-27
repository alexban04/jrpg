using UnityEngine;
[CreateAssetMenu(fileName = "New Player Item", menuName = "RPG/Player Item")]

public class PlayerItem: Item
{
    public int damage;
    public int cost;
    public override void Initialize()
    {
        base.Initialize();
    }
}
