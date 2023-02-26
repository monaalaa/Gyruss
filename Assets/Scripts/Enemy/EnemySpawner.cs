using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] EnemyPool enemyPool;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(InitEnemy(10));
        }
    }
    IEnumerator InitEnemy(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
              enemyPool.Get();
             yield return new WaitForSeconds(0.5f);
        }
    }
}
