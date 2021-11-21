using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int maxEnemy , enemyCount;
    
    public GameObject[] enemyPref;
    public Transform[] SpawnPoint;
    public GameObject giantPref;
    public int maxGiant, giantCount;

    public PlayerState playerState;
    bool spawnDelay = false;
    bool giantSpawnDelay = false;
    void Update()
    {
        maxEnemy = 5 * playerState.multiplyer;
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        giantCount = GameObject.FindGameObjectsWithTag("GiantEnemy").Length;
        if (spawnDelay == false)
        { 
            if (maxEnemy > enemyCount)
            {
                StartCoroutine(Spawn());
            }     
        }
        if(giantSpawnDelay == false)
        {
            if (playerState.multiplyer >= 5)
            {
                maxGiant = playerState.multiplyer - 4;
                if (maxGiant > giantCount)
                {
                    giantSpawnDelay = true;
                    StartCoroutine(GiantSpawn());
                }
            }
        }

    }
    IEnumerator Spawn()
    {
        spawnDelay = true;
        yield return new WaitForSeconds(0.625f);
        Instantiate(enemyPref[Random.Range(0, 3)], SpawnPoint[Random.Range(0, 2)].position ,Quaternion.identity);
        spawnDelay = false;
    }

    IEnumerator GiantSpawn()
    {
        yield return new WaitForSeconds(0.625f);
        Instantiate(giantPref, SpawnPoint[Random.Range(0, 2)].position, Quaternion.identity);
        giantSpawnDelay = false;
    }

}
