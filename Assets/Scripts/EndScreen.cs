using UnityEngine;
using TMPro;

// Shows the score the player finished the level with.
public class EndScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // No ScoreManager object exists in this scene, but we can
        // still read the static FinalScore through the class name
        scoreText.text = "Final Score: " + ScoreManager.FinalScore;
        ScoreManager.Instance.Remove();
    }
}
