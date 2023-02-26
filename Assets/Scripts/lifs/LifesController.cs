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
        view.DecreaseLife(lifesCount);
        if (lifesCount <= 0)
        {
            Actions.GameOver?.Invoke();
        }
        
    }
    private void OnDisable()
    {
        Actions.LoseLife -= LoseLife;
    }
}
