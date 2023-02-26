using UnityEngine;

public class ShipAmmoPool : ObjectPoolBase
{
    private void Awake()
    {
        ServiceLocator.Add<ShipAmmoPool>(this);
    }
    protected override void OnGet(GameObject obj)
    {
        obj.transform.position = transform.position;
        base.OnGet(obj);
    }
}
