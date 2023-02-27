using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float radious= 0.3f;
   
    private Vector3 _screenCenter = Vector3.zero;
    private float _incrementalRadious = 0.01f;
    private float _minRadious;
    
    private int _maxRadious = 4;
    private int increment = 1;

    private void Start()
    {
        _minRadious = radious;
    }
    
    private void OnEnable()
    {
        StartCoroutine(UpdateRadious());
    }
    
    private void Update()
    {
        RotateWithenRadious();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Actions.UpdateScore?.Invoke(radious);
            Reset();
        }
    }
    
    private void RotateWithenRadious()
    {
        transform.position = radious * Vector3.Normalize(transform.position - _screenCenter) ;
        var direction = new Vector3(0, 0, EnemySpawner.direction);
        transform.RotateAround(_screenCenter, direction, Time.deltaTime * 100);
    }
    
    private IEnumerator UpdateRadious()
    {
        radious += ((_incrementalRadious + Time.deltaTime) * increment);
       
        if (radious >= _maxRadious)
        {
            increment = -1;
        }
        
        else if (radious <= _minRadious)
        {
            Reset();
        }

        yield return new WaitForFixedUpdate();
        
        StartCoroutine(UpdateRadious());
    }
    
    private void Reset()
    {
        StopCoroutine(UpdateRadious());
        ServiceLocator.Get<EnemyPool>().objPool.Release(gameObject);
        increment = 1;
        radious = _minRadious+ _incrementalRadious;
    }

}
