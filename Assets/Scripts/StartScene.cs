using UnityEngine;
using TMPro;

// Shows the score the player finished the level with.
public class StartScreen : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
