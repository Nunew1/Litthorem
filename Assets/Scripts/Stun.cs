using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stun : MonoBehaviour
{
    private PlayerMovement mvP1;

    public CanvasGroup myCG;
    public bool flash = false;

    private bool isMovementRestricted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Obsolete]
    void Start()
    {
        mvP1 = GameObject.FindObjectOfType<PlayerMovement>();
        myCG = GameObject.FindObjectOfType<CanvasGroup>();
    }

    public void getStunned()
    {
        StartCoroutine(RestrictMovement(gameObject));
    }

    private IEnumerator RestrictMovement(GameObject mimic)
    {
        flash = true;
        myCG.alpha = 1;
        isMovementRestricted = true;
        mvP1.enabled = false; // Disable the movement script

        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        float fadeDuration = 1f; // Duration for the fade-out effect
        float elapsedTime = 0f; // Time elapsed since the start of fading

        while (elapsedTime < fadeDuration)
        {
            myCG.alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        myCG.alpha = 0; // Ensure it reaches 0 at the end
        mvP1.enabled = true; // Re-enable the movement script
        isMovementRestricted = false;
        Debug.Log("End Flashbang");
        flash = false;
        Destroy(mimic);
    }
}
