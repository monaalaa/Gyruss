using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected ShipBullet ammo;
    public IObjectPool<ShipBullet> ammoPool;
    int count = 0;
    private void Start()
    {
        ServiceLocator.Add<ObjectPool>(this);
        InitAmmoPool();
    }

    private void InitAmmoPool()
    {
        ammoPool = new ObjectPool<ShipBullet>(CreateAmmo, OnGet, OnRelease);
    }

    private void OnRelease(ShipBullet obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnGet(ShipBullet obj)
    {
        Debug.Log("OnGet" + ammo.name);
        obj.transform.position = transform.position;
        obj.gameObject.SetActive(true);
    }

    private ShipBullet CreateAmmo()
    {
        var currentAmmo = Instantiate(ammo, transform.position, Quaternion.identity);
        return currentAmmo;
    }

    public void GetAmmo()
    {
        ammoPool.Get();
    }
}
