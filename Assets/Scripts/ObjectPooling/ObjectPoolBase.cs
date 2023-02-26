using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolBase : MonoBehaviour
{
    [SerializeField] protected GameObject model;
    public IObjectPool<GameObject> objPool;

    private void Start()
    {
        InitAmmoPool();
    }

    private void InitAmmoPool()
    {
        objPool = new ObjectPool<GameObject>(CreateAmmo, OnGet, OnRelease);
    }

    private void OnRelease(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    protected virtual void OnGet(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    private GameObject CreateAmmo()
    {
        return Instantiate(model);
    }

    public void Get()
    {
        objPool.Get();
    }
}
