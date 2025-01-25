using UnityEngine;

public enum TargetRarity
{
    Common,
    Rare,
    Legendary
}

public class Target : MonoBehaviour
{
    public TargetRarity rarity;

    public void OnCaptured()
    {
        Debug.Log(name + " has been captured!");
    }
}
