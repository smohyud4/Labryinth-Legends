using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField ]private GameObject swarmerPrefab;

    [SerializeField] private float swarmerInterval;

    [SerializeField] private int maxSpawns;
    private int spawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if(spawnCount < maxSpawns){
            yield return new WaitForSeconds(interval);
            Instantiate(enemy, transform.position, Quaternion.identity);
            spawnCount++;
            StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
   
}
