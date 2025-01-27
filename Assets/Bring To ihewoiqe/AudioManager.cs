using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip Shoot;
    public AudioClip Captured;
    public AudioClip ButtonClick;
    public AudioClip Stunned;
    public AudioClip Reload;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
