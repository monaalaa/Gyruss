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
        obj.transform.rotation = transform.rotation;
        base.OnGet(obj);
    }

    private void OnDestroy()
    {
        ServiceLocator.Remove<ShipAmmoPool>(this);
    }
}
