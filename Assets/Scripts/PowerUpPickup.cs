using UnityEngine;

// A speed boost pickup. When the player touches it, it gives the boost,
// plays a sound and particles, hides, and comes back a few seconds later.
public class PowerUpPickup : MonoBehaviour
{
    [SerializeField] private bool jumpBoost = false;
    [SerializeField] private bool speedBoost = false;
    [SerializeField] private bool scoreBoost = false;
    [SerializeField] private float duration = 10f;    // boost length
    [SerializeField] private float respawnDelay = 5f; // time hidden
    [SerializeField] private GameObject visuals;      // child to hide
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private GameObject pickupEffect; // particle prefab

    private void OnTriggerEnter(Collider other)
    {
        // Only the player has a PlayerPowerUps component
        PlayerPowerUps powerUps = other.GetComponent<PlayerPowerUps>();
        if (powerUps == null) return;

        if (speedBoost)
        {
            powerUps.ActivateSpeedBoost(duration);
        }

        if (jumpBoost)
        {
            powerUps.ActivateJumpBoost(duration);
        }

        if (scoreBoost)
        {
            powerUps.ActivateScoreBoost(duration);
        }

        // Sound and particles
        GetComponent<AudioSource>().PlayOneShot(pickupSound);

        Instantiate(pickupEffect, transform.position, Quaternion.identity);

        // Disappear, and call Reappear() after respawnDelay seconds
        visuals.SetActive(false);
        GetComponent<Collider>().enabled = false;
        Invoke(nameof(Reappear), respawnDelay);
    }

    private void Reappear()
    {
        if (scoreBoost)
        {
            Destroy(visuals);
            return;
        }

        visuals.SetActive(true);
        GetComponent<Collider>().enabled = true;
    }
}
