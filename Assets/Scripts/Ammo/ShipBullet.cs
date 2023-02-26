using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;

public class ShipBullet : MonoBehaviour, IBullet
{
    [SerializeField] float speed = 10;
    private Vector3 _screenCenter = Vector3.zero;
    private Tween _moveTween;
    private void OnEnable()
    {
       MoveToTarget();
    }

    public void MoveToTarget()
    {
        _moveTween = transform.DOMove(_screenCenter, speed).
            SetSpeedBased(true).OnComplete(() => Release()).SetEase(Ease.Linear);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            _moveTween.Kill();
            Release();
        }
    }
    
    public void Release()
    {
         ServiceLocator.Get<ShipAmmoPool>().objPool.Release(gameObject);
    }
}
