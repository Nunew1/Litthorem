using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 1;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        audioManager.PlaySFX(audioManager.Reload);
        Shoot weapon = collision.gameObject.GetComponentInChildren<Shoot>();
        if (weapon)
        {
            weapon.AddAmmo(ammoAmount);
            Destroy(gameObject);
            Debug.Log("The error is here!");            
        }
    }
}
