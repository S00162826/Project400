using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawning : MonoBehaviour
{
    private float nextSpawnTime;

    [SerializeField]
    private GameObject AmmoPrefab;

    [SerializeField]
    private float spawnDelay = 15;

    void Update()
    {
        if (ShouldSpawn())
        {
            SpawnAmmo();
        }
    }

    public void SpawnAmmo()
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(AmmoPrefab, transform.position, transform.rotation);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
