using UnityEngine;

public class ShipAmmoPool : ObjectPoolBase
{
    [SerializeField] Transform spawnPoint;
    private void Awake()
    {
        ServiceLocator.Add<ShipAmmoPool>(this);
    }
    protected override void OnGet(GameObject obj)
    {
        obj.transform.position = spawnPoint.position;
        base.OnGet(obj);
    }
}
