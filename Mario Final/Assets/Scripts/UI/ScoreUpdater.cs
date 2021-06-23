using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    public TMP_Text text;
    public IntVar score;

    private void Update() {
        text.text = score.Value.ToString();
    }
}
