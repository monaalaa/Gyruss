using UnityEngine;

public class EnemyPool : ObjectPoolBase
{
    private void Awake()
    {
        ServiceLocator.Add<EnemyPool>(this);
    }
    private void OnDestroy()
    {
        ServiceLocator.Remove<EnemyPool>(this);
    }
}
