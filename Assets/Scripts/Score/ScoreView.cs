using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;

    public void UpdateScore(int value)
    {
        score.text = value.ToString();
    }
}
