using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] private int points = 1;
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.position;
            HealthManager.Instance.RemoveHealth(points);
        }
    }
}
