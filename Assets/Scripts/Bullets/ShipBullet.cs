using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;

public class ShipBullet : MonoBehaviour, IBullet
{
    private IObjectPool<ShipBullet> objectPool;

    [SerializeField] float speed = 10;
    
    private Tween _movingTween;
   
    private void OnEnable()
    {
        Shoot();
    }

    public void Shoot()
    {
        Debug.Log(transform.position);
        _movingTween = transform.DOMove(Vector3.zero, speed).
            SetSpeedBased(true).OnComplete(() => Release()).SetEase(Ease.Linear); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if collide with Enemy
        Release();
    }
    //ToDO: On collide with enemy vanish
    public void Release()
    {
        ServiceLocator.Get<ObjectPool>().ammoPool.Release(this);
    }

    public void SetPool(IObjectPool<ShipBullet> pool)
    {
        objectPool = pool;
    }
}
