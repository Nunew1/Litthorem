using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BubbleBullet : MonoBehaviour
{
    public string targetTag = "Target";
    public string MimicTag = "Mimic";
    public Transform spawnLocation;
    public GameObject captureEffect;
    public GameObject failedCaptureEffect;

    private CountDown cd;
    private Target targetshot;
    public CompletionListController complist;

    [Header("Base Capture Rates by Rarity")]
    [Range(0f, 1f)] public float commonRate = 0.8f;
    [Range(0f, 1f)] public float rareRate = 0.5f;
    [Range(0f, 1f)] public float legendaryRate = 0.2f;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


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
        else if (other.CompareTag("Barrier"))
        {
            Destroy(gameObject);
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
            cd = GameObject.FindObjectOfType<CountDown>();
            cd.Missed();

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
        audioManager.PlaySFX(audioManager.Captured);
        complist = GameObject.FindObjectOfType<CompletionListController>();
        if (captureEffect != null)
        {
            Instantiate(captureEffect, transform.position, Quaternion.identity);
        }

        if (spawnLocation != null)
        {
            Instantiate(target, spawnLocation.position, Quaternion.identity);
        }
        targetshot = target.GetComponent<Target>();
        complist.OnCreatureCollected(targetshot.prefabName);
        Material material = targetshot.planeRenderer.material;
        material.SetTexture("_BaseMap", targetshot.newTexture);
        Destroy(target);
    }

}
