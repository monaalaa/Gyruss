using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolBase : MonoBehaviour
{
    [SerializeField] protected GameObject model;
    public IObjectPool<GameObject> objPool;

    private void Start()
    {
        InitObjPool();
    }

    private void InitObjPool()
    {
        objPool = new ObjectPool<GameObject>(CreateObj, OnGet, OnRelease);
    }

    private void OnRelease(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    protected virtual void OnGet(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    private GameObject CreateObj()
    {
        return Instantiate(model);
    }

    public void Get()
    {
        objPool.Get();
    }
}
