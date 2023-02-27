using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] ScoreView view;

    private int _score = 0;
    private void Start()
    {
        Actions.UpdateScore += UpdateScore;
    }

    private void UpdateScore(float radious)
    {
        _score += GetScore(radious);
        view.UpdateScore(_score);
    }

    private int GetScore(float radious)
    {

        //Note We cam make equation based on game desigen mul radious by value
        int score = 0;
        if (radious > 3 && radious <= 5)
        {
            score = 2;
        }
        else if (radious > 2 && radious <= 3)
        {
            score = 5;
        }
        else if (radious > 1 && radious <= 2)
        {
            score = 10;
        }
        else if (radious > 0 && radious <= 1)
        {
            score = 15;
        }
        return score;
    }

    private void OnDisable()
    {
        Actions.UpdateScore -= UpdateScore;

    }
}
