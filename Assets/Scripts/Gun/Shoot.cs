using UnityEngine;
using TMPro;
using System.Collections;

public class Shoot : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    [Header("Ammo")]
    public int currentClip, maxClipSize = 10;
    public Shoot shoot;

    bool readyToThrow;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow && currentClip > 0)
        {
            Throw();
        }
    }

    private void Throw()
    {
        if (currentClip > 0)
        {
            readyToThrow = false;

            GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

            projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

            currentClip--;

            Invoke(nameof(ResetThrow), throwCooldown);

            audioManager.PlaySFX(audioManager.Shoot);

            //Destroy(objectToThrow, 5f);
        }
    }

    public void AddAmmo(int ammoAmount)
    {
        currentClip += ammoAmount;
        if (currentClip > maxClipSize)
        {
            currentClip = maxClipSize;
        }
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

}
