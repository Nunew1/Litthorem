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
    public Renderer planeRenderer;  // Reference to the plane's renderer
    public Texture newTexture;

    public void OnCaptured()
    {
        Debug.Log(name + " has been captured!");
        Destroy(gameObject);
    }
}
