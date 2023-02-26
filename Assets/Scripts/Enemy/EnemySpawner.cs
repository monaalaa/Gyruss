using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float waitingTimeBetweenGroups = 1.2f;
    [SerializeField] float waitingTimeBetweenElements = 0.5f;
    [SerializeField] Enemy enemy;
    [SerializeField] EnemyPool enemyPool;

    public static int direction = 1;

    private void Start()
    {
        StartCoroutine(InitEnemy());
    }
    private IEnumerator InitEnemy()
    {
        ChangeDirection();
        int numberOfEnemies = Random.Range(2, 10);
        for (int i = 0; i < numberOfEnemies; i++)
        {
            enemyPool.Get();
            yield return new WaitForSeconds(waitingTimeBetweenElements);
        }

        yield return new WaitForSeconds(waitingTimeBetweenGroups);
        StartCoroutine(InitEnemy());
    }
    private void ChangeDirection()
    {
        var rand = Random.Range(0, 10);
        direction = rand % 2 == 1 ? 1 : -1;
    }
}
