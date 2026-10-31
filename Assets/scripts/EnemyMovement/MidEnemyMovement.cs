using System;
using UnityEngine;

public class MidEnemyMovement : MonoBehaviour
{
    private float timer = 0f;
    public float speed = 5f;          // Скорость движения вперед
    public float verticalSpeed = 4f;  // Скорость покачивания вверх-вниз
    public float verticalHeight = 2f; // Амплитуда (высота) колебаний
    public GameOver gameOverCanvas;

    private Vector3 startPosition;
    private Vector3 moveDirection;

    private void Start()
    {
        gameOverCanvas = FindObjectOfType<GameOver>(); 

        startPosition = transform.position;
        moveDirection = -transform.forward;
        moveDirection.y = 0; 
        moveDirection = moveDirection.normalized;
    }

    void Update()
    {
        timer += Time.deltaTime; 
        if (timer >= 8f) 
        {
            Destroy(gameObject); 
        }

        startPosition += moveDirection * speed * Time.deltaTime;
        float newY = startPosition.y + Mathf.Sin(Time.time * verticalSpeed) * verticalHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOverCanvas.ShowGameOver();
}
    }
}
