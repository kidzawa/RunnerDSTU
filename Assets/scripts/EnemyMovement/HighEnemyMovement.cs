using UnityEngine;

public class HighEnemyMovement : MonoBehaviour
{
    private float timer = 0f;
    public float speed = 5f;          
    public float sideSpeed = 4f;        
    public float sideWidth = 2f;       
    public GameOver gameOverCanvas;

    private Vector3 startPosition;
    private Vector3 moveDirection;
    private Vector3 rightVector;      

    private void Start()
    {
        gameOverCanvas = FindObjectOfType<GameOver>();

        startPosition = transform.position;
        moveDirection = -transform.forward;
        moveDirection.y = 0;
        moveDirection = moveDirection.normalized;
        rightVector = Vector3.Cross(Vector3.up, moveDirection);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 8f)
        {
            Destroy(gameObject);
        }

        startPosition += moveDirection * speed * Time.deltaTime;
        float sideOffset = Mathf.Sin(Time.time * sideSpeed) * sideWidth;
        transform.position = startPosition + (rightVector * sideOffset);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOverCanvas.ShowGameOver();
        }
    }
}
