using UnityEngine;

public class LifesController : MonoBehaviour
{
    [SerializeField] LifesView view;
    
    int lifesCount = 3;
    private void Start()
    {
        Actions.LoseLife += LoseLife;
    }
    private void LoseLife()
    {
        lifesCount--;
        if (lifesCount >= 0)
        {
            view.DecreaseLife(lifesCount);
        }
        else {
            Actions.GameOver?.Invoke();
            Debug.Log("Game Over");
        }
    }
    private void OnDisable()
    {
        Actions.LoseLife -= LoseLife;
    }
}
