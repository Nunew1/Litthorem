using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditiion : MonoBehaviour
{
    public CompletionListController completionListController; // Reference to CompletionListController

    void Update()
    {
        // Check if all creatures are collected
        if (completionListController.GetNormalCollected() == completionListController.normalImages.Length &&
            completionListController.GetRareCollected() == completionListController.rareImages.Length &&
            completionListController.GetSuperRareCollected() == completionListController.superRareImages.Length)
        {
            Debug.Log("All creatures collected! You Win!");
            // Load the Win Scene (change "WinScene" to your actual scene name)
            UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
        }
    }
}
