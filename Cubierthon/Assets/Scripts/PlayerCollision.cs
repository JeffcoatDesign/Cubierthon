using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public bool isAlive = true;
    void OnCollisionEnter (Collision collsionInfo)
    {
        if (collsionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            isAlive = false;
            FindFirstObjectByType<GameManager>().EndGame();
        }
    }
}
