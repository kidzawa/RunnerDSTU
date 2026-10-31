using UnityEngine;

public class SoundController : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip shootSound;
    public AudioClip jumpSound;
    public AudioClip stepSound;

    private void Awake()
    {
        // Если AudioSource не привязан через инспектор, берем его автоматически
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Метод для воспроизведения выстрела
    public void PlayShoot()
    {
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }

    // Метод для воспроизведения прыжка
    public void PlayJump()
    {
        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    // Метод для шагов
    public void PlayStep()
    {
        if (stepSound != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(stepSound);
        }
    }
}
