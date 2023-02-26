using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;

public class ShipBullet : MonoBehaviour, IBullet
{
    [SerializeField] float speed = 10;
    private void OnEnable()
    {
       var ship= FindObjectOfType<Ship>();
        transform.position = ship.transform.position;
        Shoot();
    }

    public void Shoot()
    {
         transform.DOMove(Vector3.zero, speed).
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
