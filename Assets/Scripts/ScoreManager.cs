using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int Score { get; private set; }
    public static int FinalScore { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        if (FinalScore != 0)
        {
            Score = FinalScore;
        }
    }

    public void AddScore(int amount)
    {
        Score += amount;
        //Debug.Log("Score: " + Score);
    }

    public void RemoveScore(int amount)
    {
        Score -= amount;
        if (Score < 0)
        {
            Score = 0;
        }
        //Debug.Log("Score: " + Score);
    }

    public void SaveFinalScore()
    {
        FinalScore = Score;
    }

    public void Remove()
    {
        FinalScore = 0;
        Instance = null;
    }
}
