using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 3f;
    public static int enemyKill = 0;
    public GameObject ammoPrefab;
    public static TextMeshProUGUI enemyDeath;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AmmoBox"))
        {
            return;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyKill++;
            enemyDeath.text = enemyKill.ToString();
            if (enemyKill % 3 == 0)
            {
                Instantiate(ammoPrefab, other.transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject); 
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
