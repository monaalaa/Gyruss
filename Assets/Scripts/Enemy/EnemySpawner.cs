using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemy;

    private void Start()
    {
        StartCoroutine( InitEnemy(10));
    }

    IEnumerator InitEnemy(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            var obj = Instantiate(enemy);
            obj.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
