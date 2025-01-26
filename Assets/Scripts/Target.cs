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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCaptured();

            // Locate the CompletionListController in the scene
            var completionController = FindObjectOfType<CompletionListController>();
            if (completionController != null)
            {
                completionController.CaptureCreature(rarity); // Call the method
            }
            else
            {
                Debug.LogError("CompletionListController not found in the scene!");
            }

            Destroy(gameObject); // Remove the creature after capture
        }
    }


    public void OnCaptured()
    {
        Debug.Log(name + " has been captured!");
        Destroy(gameObject);
    }
}
