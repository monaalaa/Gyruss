using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;

public class ShipBullet : MonoBehaviour, IBullet
{
    [SerializeField] float speed = 10;
    Vector3 _screenCenter = Vector3.zero;

    private void OnEnable()
    {
       MoveToTarget();
    }

    public void MoveToTarget()
    {
        transform.DOMove(_screenCenter, speed).
            SetSpeedBased(true).OnComplete(() => Release()).SetEase(Ease.Linear); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if collide with Enemy
        Release();
    }
    
    public void Release()
    {
         ServiceLocator.Get<ShipAmmoPool>().objPool.Release(gameObject);
    }
}
