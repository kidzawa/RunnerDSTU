using System;
using UnityEngine;

public class LowEnemyMovement : MonoBehaviour
{
    private float timer = 0f;
    public float speed = 5f;
    public float rotationSpeed = 2f; 
    public GameOver gameOverCanvas;

    private Transform player;
    private Vector3 currentDirection;

    private void Start()
    {
        gameOverCanvas = FindObjectOfType<GameOver>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            Vector3 toPlayer = player.position - transform.position;
            toPlayer.y = 0;
            currentDirection = toPlayer.normalized;
        }
        else
        {
            currentDirection = transform.forward;
            currentDirection.y = 0;
            currentDirection = currentDirection.normalized;
        }
    }

    void Update()
    {
        timer += Time.deltaTime; 
        if (timer >= 8f) 
        {
            Destroy(gameObject); 
        }

        if (player != null)
        {
            Vector3 toPlayer = player.position - transform.position;
            toPlayer.y = 0; 
            Vector3 toPlayerNormalized = toPlayer.normalized;


            if (timer < 1.5f)
            {
                currentDirection = Vector3.RotateTowards(currentDirection, toPlayerNormalized, rotationSpeed * Time.deltaTime, 0.0f);
                currentDirection.y = 0; // Держимся на плоскости
            }
        }

        transform.Translate(currentDirection * speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOverCanvas.ShowGameOver();
}
    }
}
