using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
   [SerializeField]
    GameObject npcPrefab;
    [SerializeField]
    float spawnTime;
    [SerializeField]
    float spawnTimeVariance = 0;
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    Vector3 moveSpeed;
    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnTime + Random.Range(-spawnTimeVariance, spawnTimeVariance);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnNpc();
            spawnTimer = spawnTime + Random.Range(-spawnTimeVariance, spawnTimeVariance);
        }
    }

    void SpawnNpc()
    {
        GameObject npc = Instantiate(npcPrefab, spawnPoint.position, spawnPoint.rotation);
        if(npc.GetComponent<WalkForward>() != null)
        {
npc.GetComponent<WalkForward>().moveSpeed = moveSpeed;
        } else
        if(npc.GetComponent<CarDriving>() != null)
        {
            npc.GetComponent<CarDriving>().moveSpeed = moveSpeed;
        }
    }
}
