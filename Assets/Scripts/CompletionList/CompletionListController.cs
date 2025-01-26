using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompletionListController : MonoBehaviour
{
    public GameObject panel; // CompletionListPanel

    [Header("Creature Images")]
    public RawImage[] normalImages;   // Array for Normal creature images
    public RawImage[] rareImages;     // Array for Rare creature images
    public RawImage[] superRareImages; // Array for Super Rare creature images

    [Header("Opacity Settings")]
    public float lowOpacity = 0.3f;  // Opacity when a creature is not collected
    public float fullOpacity = 1f;  // Opacity when a creature is collected

    public int normalCollected = 0;  // Counter for Normal creatures
    public int rareCollected = 0;    // Counter for Rare creatures
    public int superRareCollected = 0; // Counter for Super Rare creatures

    void Update()
    {
        // Check if the player is holding down the "E" key
        if (Input.GetKey(KeyCode.E))
        {
            panel.SetActive(true); // Show the panel
        }
        else
        {
            panel.SetActive(false); // Hide the panel
        }
    }

    void Start()
    {
        // Images opacity
        SetAllImagesOpacity(normalImages, lowOpacity);
        SetAllImagesOpacity(rareImages, lowOpacity);
        SetAllImagesOpacity(superRareImages, lowOpacity);
    }

    public void CaptureCreature(TargetRarity rarity)
    {
        // Based on rarity, call OnCreatureCollected to update the images opacity
        switch (rarity)
        {
            case TargetRarity.Common:
                if (normalCollected < normalImages.Length)
                {
                    OnCreatureCollected("Normal");
                }
                break;

            case TargetRarity.Rare:
                if (rareCollected < rareImages.Length)
                {
                    OnCreatureCollected("Rare");
                }
                break;

            case TargetRarity.Legendary:
                if (superRareCollected < superRareImages.Length)
                {
                    OnCreatureCollected("SuperRare");
                }
                break;

            default:
                Debug.LogError("Unknown rarity: " + rarity);
                break;
        }
    }

    // Update the panel when a creature is collected
    public void OnCreatureCollected(string type)
    {
        switch (type)
        {
            case "Normal":
                if (normalCollected < normalImages.Length)
                {
                    SetImageOpacity(normalImages[normalCollected], fullOpacity);
                    normalCollected++;
                }
                break;

            case "Rare":
                if (rareCollected < rareImages.Length)
                {
                    SetImageOpacity(rareImages[rareCollected], fullOpacity);
                    rareCollected++;
                }
                break;

            case "SuperRare":
                if (superRareCollected < superRareImages.Length)
                {
                    SetImageOpacity(superRareImages[superRareCollected], fullOpacity);
                    superRareCollected++;
                }
                break;

            default:
                Debug.LogError("Unknown creature type: " + type);
                break;
        }
    }

    public int GetNormalCollected()
    {
        return normalCollected;
    }

    public int GetRareCollected()
    {
        return rareCollected;
    }

    public int GetSuperRareCollected()
    {
        return superRareCollected;
    }

    // Check if the player has collected all creatures
    private void CheckWinCondition()
    {
        // Check if all creatures are collected (Normal, Rare, Super Rare)
        if (normalCollected == normalImages.Length && rareCollected == rareImages.Length && superRareCollected == superRareImages.Length)
        {
            // If all creatures are collected, trigger the win condition
            Debug.Log("All creatures collected! You Win!");
            // Replace "WinScene" with the name of your win scene
            SceneManager.LoadScene("WinScene");
        }
    }


    // Helper function to set all images in an array to a specific opacity
    private void SetAllImagesOpacity(RawImage[] images, float opacity)
    {
        foreach (RawImage image in images)
        {
            SetImageOpacity(image, opacity);
        }
    }

    // Helper function to set the opacity of a single image
    private void SetImageOpacity(RawImage image, float opacity)
    {
        Color color = image.color;
        color.a = opacity;
        image.color = color;
    }
}
