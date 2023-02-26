using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float waitingTimeBetweenGroups = 1.2f;
    [SerializeField] float waitingTimeBetweenElements = 0.5f;
    [SerializeField] Enemy enemy;
    [SerializeField] EnemyPool enemyPool;

    private void Start()
    {
        StartCoroutine(InitEnemy());
    }
    IEnumerator InitEnemy()
    {
        int numberOfEnemies = Random.Range(2, 10);
        for (int i = 0; i < numberOfEnemies; i++)
        {
              enemyPool.Get();
             yield return new WaitForSeconds(waitingTimeBetweenElements);
        }

        yield return new WaitForSeconds(waitingTimeBetweenGroups);
        StartCoroutine(InitEnemy());
    }
    
}
