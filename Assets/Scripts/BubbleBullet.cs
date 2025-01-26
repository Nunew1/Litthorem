using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BubbleBullet : MonoBehaviour
{
    public string targetTag = "Target";
    public string MimicTag = "Mimic";
    public Transform spawnLocation;
    public GameObject captureEffect;
    public GameObject failedCaptureEffect;

    private Target targetshot;

    [Header("Base Capture Rates by Rarity")]
    [Range(0f, 1f)] public float commonRate = 0.8f;
    [Range(0f, 1f)] public float rareRate = 0.5f;
    [Range(0f, 1f)] public float legendaryRate = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Target target = other.GetComponent<Target>();
            if (target != null)
            {
                AttemptCapture(target);
            }
        }
        else if (other.CompareTag(MimicTag))
        {
            Stun  mimic = other.GetComponent<Stun>();
            if (mimic != null)
            {
                mimic.getStunned();
            }
        }
    }

    private void AttemptCapture(Target target)
    {
        float captureRate = GetCaptureRate(target.rarity);
        float roll = Random.value;

        if (roll <= captureRate)
        {
            CaptureTarget(target.gameObject);
        }
        else
        {
            Debug.Log(target.name + " (" + target.rarity + ") failed to capture!");
        }

        Destroy(gameObject);
    }

    private float GetCaptureRate(TargetRarity rarity)
    {
        switch (rarity)
        {
            case TargetRarity.Common:
                return commonRate;
            case TargetRarity.Rare:
                return rareRate;
            case TargetRarity.Legendary:
                return legendaryRate;
            default:
                return 0f;
        }
    }

    private void CaptureTarget(GameObject target)
    {

        if (captureEffect != null)
        {
            Instantiate(captureEffect, transform.position, Quaternion.identity);
        }

        if (spawnLocation != null)
        {
            Instantiate(target, spawnLocation.position, Quaternion.identity);
        }
        targetshot = target.GetComponent<Target>();

        Material material = targetshot.planeRenderer.material;
        material.SetTexture("_BaseMap", targetshot.newTexture);
        Invoke(nameof(DestroyTarget), 1f);
    }

    private IEnumerator DestroyAfterDelay(GameObject target, float delay)
    {
        yield return new WaitForSeconds(delay);

        Debug.Log($"Destroying target: {target.name}");
        Destroy(target);
    }

    private void DestroyTarget(GameObject target)
    {
        if (target != null)
        {
            Debug.Log($"Destroying target: {target.name}");
            targetshot.OnCaptured();
        }
        else
        {
            Debug.LogWarning("Target is null, cannot destroy!");
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
      //  if (other.gameObject.CompareTag("Target"))
        //{
          //  Destroy(other);
            //Debug.Log("Destroy target");
        //}
    //}
}
