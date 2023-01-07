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
    Transform spawnPoint;
    [SerializeField]
    Vector3 moveSpeed;
    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnNpc();
            spawnTimer = spawnTime;
        }
    }

    void SpawnNpc()
    {
        GameObject npc = Instantiate(npcPrefab, spawnPoint.position, spawnPoint.rotation);
        npc.GetComponent<WalkForward>().moveSpeed = moveSpeed;
    }
}
