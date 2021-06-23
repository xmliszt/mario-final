using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public IntVar score;
    
    public void AddScore(int value)
    {
        score.Add(value);
    }

    public int GetScore()
    {
        return score.Value;
    }
}
