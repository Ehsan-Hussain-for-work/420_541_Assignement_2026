using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }
    public int Health { get; private set; } = 3;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void AddHealth(int amount)
    {
        Health += amount;
        //Debug.Log("Score: " + Score);
    }

    public void RemoveHealth(int amount)
    {
        Health -= amount;
        //Debug.Log("Score: " + Score);
    }
}
