using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    private PlayerCollision m_playerCollision;
    private void Awake()
    {
        m_playerCollision = FindAnyObjectByType<PlayerCollision>();
    }
    void OnTriggerEnter()
    {
        if (m_playerCollision.isAlive)
        {
            gameManager.CompleteLevel();
        }
    }
}
