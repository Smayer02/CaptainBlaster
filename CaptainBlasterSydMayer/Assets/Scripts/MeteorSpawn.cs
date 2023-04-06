using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;
    public float spawnXLimit = 6f;

    public float speedUpMin = 0f;
    public float speedUpMax = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn() {
        float random = Random.Range(-spawnXLimit, spawnXLimit);
        Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

        Invoke("Spawn", Random.Range(minSpawnDelay - speedUpMin, maxSpawnDelay - speedUpMax));
    }

    // Update is called once per frame
    void Update()
    {
    //if Statements slowly increment speedUp value overtime
        if (speedUpMax < 3f)
            speedUpMax += Time.deltaTime / 70;
        if (speedUpMin < 1f)
            speedUpMax += Time.deltaTime / 70;
    }
}
