using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] private int hp = 1;
    [SerializeField] private int points = 30;
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthManager.Instance.RemoveHealth(hp);
            ScoreManager.Instance.RemoveScore(points);
            other.transform.position = respawnPoint.position;
        }
    }
}
