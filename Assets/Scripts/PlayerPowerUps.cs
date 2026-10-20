using UnityEngine;

// Gives the player a speed boost for a limited time.
public class PlayerPowerUps : MonoBehaviour
{
    [SerializeField] private float boostMultiplier = 1.5f; // 50% faster

    // Seconds of boost left. The HUD reads it; only this script changes it.
    public float SpeedTimeLeft { get; private set; }

    public float JumpTimeLeft { get; private set; }

    public float ScoreTimeLeft { get; private set; }

    private PlayerMovement movement;
    private ScorePickup points;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        points = GetComponent<ScorePickup>();
    }

    // Called by the pickup. Collecting another boost restarts the timer.
    public void ActivateSpeedBoost(float duration)
    {
        SpeedTimeLeft = duration;
        movement.SpeedMultiplier = boostMultiplier;
    }

    public void ActivateJumpBoost(float duration)
    {
        JumpTimeLeft = duration;
        movement.JumpMultiplier = true;
    }

    public void ActivateScoreBoost(float duration)
    {
        ScoreTimeLeft = duration;
        points.PointsMultiplier = 2;
    }

    private void Update()
    {
        if (SpeedTimeLeft > 0f)
        {
            SpeedTimeLeft -= Time.deltaTime;
        }

        if (SpeedTimeLeft <= 0f)
        {
            movement.SpeedMultiplier = 1f; // back to normal speed
        }

        if (JumpTimeLeft > 0f)
        {
            JumpTimeLeft -= Time.deltaTime;
        }

        if (JumpTimeLeft <= 0f)
        {
            movement.JumpMultiplier = false;
        }

        // if (ScoreTimeLeft > 0f)
        // {
        //     ScoreTimeLeft -= Time.deltaTime;
        // }

        // if (ScoreTimeLeft <= 0f)
        // {
        //     points.PointsMultiplier = 1;
        // }
    }
}
