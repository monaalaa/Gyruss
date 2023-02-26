using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] GameOverView view;
    void Start()
    {
        Actions.GameOver += OnGameOver;
    }
    private void OnGameOver()
    {
        PauseGame();
        view.ShowGameOver();
    }
    private void OnDestroy()
    {
        Actions.GameOver -= OnGameOver;
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void Reload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
