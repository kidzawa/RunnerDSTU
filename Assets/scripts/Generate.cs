using UnityEngine;

public class Generate : MonoBehaviour
{
        [Header("Настройки бесконечного коридора")]
        public GameObject nextCorridorPrefab;
        public float corridorLength = 20f;

        [Header("Коррекция смещения")]
        public Vector3 spawnOffset = Vector3.zero; // Здесь мы укажем минус по Y

        private bool spawned = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !spawned)
            {
                SpawnNextCorridor();
                spawned = true;
                Destroy(gameObject, 5f);
            }
        }

        void SpawnNextCorridor()
        {
            if (nextCorridorPrefab != null)
            {
                Vector3 spawnPosition = transform.position + new Vector3(0, 0, corridorLength) + spawnOffset;
                Instantiate(nextCorridorPrefab, spawnPosition, transform.rotation);
            }
        }
    }
