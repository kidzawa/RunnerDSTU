using UnityEngine;

public class AmmoPick : MonoBehaviour
{
    public int ammoAmount = 10;
    public float rotationSpeed = 90f;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Kasanie");

        if (other.CompareTag("Player"))
        {
            PlayerShooting playerShooting = other.GetComponentInParent<PlayerShooting>();
            if (playerShooting != null)
            {
                playerShooting.AddAmmo(ammoAmount);
                Destroy(gameObject); 
                Debug.Log("Подбор успешен");
            }
        }
    }
}
