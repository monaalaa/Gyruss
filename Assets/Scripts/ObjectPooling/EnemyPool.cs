using UnityEngine;

public class EnemyPool : ObjectPoolBase
{
    private void Awake()
    {
        ServiceLocator.Add<EnemyPool>(this);
    }
    protected override void OnGet(GameObject obj)
    {
        obj.transform.position = transform.position;
        base.OnGet(obj);
    }
}
