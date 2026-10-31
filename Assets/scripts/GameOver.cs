using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel; 

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); 
        Time.timeScale = 0f;   
        Cursor.lockState = CursorLockMode.None;
        
    }

    // Этот метод вешаем на кнопку перезапуска
    public void RestartGame()
    {
        Time.timeScale = 1f;
        Bullet.enemyKill = 0;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
