using TMPro;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;   
    public Transform firePoint;      
    public float fireRate = 0.2f;      
    public int maxAmmo = 30;           
    private int currentAmmo;
    public TextMeshProUGUI ammoText;   
    private SoundController soundController;
    public ParticleSystem flash;

    private float nextFireTime = 0f;

    private void Start()
    {
        currentAmmo = maxAmmo;
        soundController = FindFirstObjectByType<SoundController>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            if (currentAmmo > 0)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
            else
            {
                Debug.Log("Патроны закончились!");
                // Здесь можно добавить звук пустого магазина
            }
        }
        ammoText.text = maxAmmo + " / " + currentAmmo;
    }

    void Shoot()
    {
        currentAmmo--;

        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            soundController.PlayShoot();
            flash.Play();
        }
    }

    public void AddAmmo(int amount)
    {
        int oldAmmo = currentAmmo;
        currentAmmo += amount;
        if(currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        Debug.Log($"Было {oldAmmo}, + {amount}, itogo {currentAmmo}");
    }
}
