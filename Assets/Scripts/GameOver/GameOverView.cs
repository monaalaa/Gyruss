using UnityEngine;

public class GameOverView : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;

    public void ShowGameOver() => gameOverPanel.SetActive(true);
}
