using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 2f;
    private float timer = 0f;
    public float spawnRadius = 5f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }

    }

    void SpawnObject()
    {
        float randomAngle = Random.Range(0f, Mathf.PI);
        float randomDistance = Random.Range(0f, spawnRadius);
        float x = Mathf.Cos(randomAngle) * randomDistance;
        float z = Mathf.Sin(randomAngle) * randomDistance;
        Vector3 spawnPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        Instantiate(prefabToSpawn, spawnPosition, transform.rotation);
    }
}
