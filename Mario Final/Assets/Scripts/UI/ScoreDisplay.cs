using UnityEngine;
using TMPro;
public class ScoreDisplay : MonoBehaviour
{
    public IntVar score;

    public TMP_Text text;

    private void Start() {
        DisplayScore();
    }

    public void DisplayScore()
    {
        text.text = string.Format("Your score is: {0}", score.Value);
    }
}
