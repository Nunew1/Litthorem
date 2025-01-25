using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 1;

    private void OnTriggerEnter(Collider collision)
    {
        Shoot weapon = collision.gameObject.GetComponentInChildren<Shoot>();
        if (weapon)
        {
            weapon.AddAmmo(ammoAmount);
            Destroy(gameObject);
        }
    }
}
