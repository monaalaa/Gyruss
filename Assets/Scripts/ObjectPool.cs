using System;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{

    //    public ShipBullet prefab;
    //    private IObjectPool<ShipBullet> objectPool;

    //    void Start()
    //    {
    //        objectPool = new ObjectPool<ShipBullet>(InstantiateObject, OnObject, OnReleased);
    //    }

    //    private ShipBullet InstantiateObject()
    //    {
    //        var obj = Instantiate(prefab);
    //        obj.SetPool(objectPool);
    //        return obj;
    //    }

    //    public void OnObject(ShipBullet obj)
    //    {
    //        obj.gameObject.SetActive(true);
    //        obj.transform.position = transform.position;
    //    }

    //    public void OnReleased(ShipBullet obj)
    //    {
    //        obj.gameObject.SetActive(false);
    //    }

    //    void Update()
    //    {
    //        objectPool.Get();
    //        //Instantiate(prefab);
    //    }
    //}
    ////ToDO, add it to service
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
