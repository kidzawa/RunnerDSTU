using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI kills;
    void Update()
    {
        Bullet.enemyDeath = kills;
    }
}
